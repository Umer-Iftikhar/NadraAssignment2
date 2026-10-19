using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace NadraSystem.Forms;

public partial class MainForm : Form
{
    // first digit of a CNIC tells the province
    private readonly Dictionary<string, char> provinceCodes = new()
    {
        ["Khyber Pakhtunkhwa"] = '1', ["Punjab"] = '3', ["Sindh"] = '4', ["Balochistan"] = '5',
        ["Islamabad"] = '6', ["Gilgit-Baltistan"] = '7', ["Azad Kashmir"] = '8'
    };
    private byte[] photo;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        cmbProvince.Items.AddRange(provinceCodes.Keys.ToArray());
        cmbMarital.Items.AddRange(new object[] { "Single", "Married", "Divorced", "Widowed" });
        cmbMarital.SelectedIndex = 0;
        dtpDob.Value = DateTime.Today.AddYears(-20);
        dtpDob.MaxDate = DateTime.Today;
        toolTip1.SetToolTip(mtxtCnic, "First digit = province code, last digit odd for male / even for female");
        toolTip1.SetToolTip(btnBrowse, "Choose the citizen's photograph");
        timer1.Start();
        LoadGrid();
    }

    // ---------------- helpers
    private int Age
    {
        get
        {
            int age = DateTime.Today.Year - dtpDob.Value.Year;
            if (dtpDob.Value.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
    }

    private DateTime Expiry => Age >= 60 ? DateTime.MaxValue.Date : dtpIssue.Value.Date.AddYears(10);

    private void LoadGrid()
    {
        var list = Database.Search(txtSearch.Text.Trim());
        dgvCitizens.DataSource = list.Select(c => new
        {
            c.Cnic, c.Name, Father = c.FatherName, c.Gender, DOB = c.DateOfBirth.ToString("dd-MM-yyyy"),
            c.Province, c.Phone, Expiry = c.ExpiryDate == DateTime.MaxValue.Date ? "Lifetime" : c.ExpiryDate.ToString("dd-MM-yyyy")
        }).ToList();
        lblCount.Text = $"{list.Count} record(s) found";
        lblRecords.Text = $"Total citizens: {Database.Search("").Count}";
    }

    // ---------------- events
    private void timer1_Tick(object sender, EventArgs e) => lblClock.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

    private void dtpDob_ValueChanged(object sender, EventArgs e)
    {
        lblAge.Text = $"Age: {Age} years";
        lblAge.ForeColor = Age < 18 ? Color.Red : Color.Green;
        dtpIssue_ValueChanged(sender, e);
    }

    private void dtpIssue_ValueChanged(object sender, EventArgs e)
    {
        lblExpiry.Text = Age >= 60 ? "Expiry: LIFETIME" : $"Expiry: {Expiry:dd-MM-yyyy}";
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
        using var img = Image.FromFile(openFileDialog1.FileName);
        using var resized = new Bitmap(img, 240, 300);
        using var ms = new MemoryStream();
        resized.Save(ms, ImageFormat.Jpeg);
        photo = ms.ToArray();
        picPhoto.Image = Image.FromStream(new MemoryStream(photo));
    }

    // ---------------- validation
    private bool ValidateForm()
    {
        errorProvider1.Clear();
        bool ok = true;
        void Error(Control c, string msg) { errorProvider1.SetError(c, msg); ok = false; }

        if (!Regex.IsMatch(txtName.Text.Trim(), @"^[A-Za-z ]{3,50}$")) Error(txtName, "Name must contain 3-50 letters only");
        if (!Regex.IsMatch(txtFather.Text.Trim(), @"^[A-Za-z ]{3,50}$")) Error(txtFather, "Father name must contain 3-50 letters only");
        if (!rbMale.Checked && !rbFemale.Checked) Error(grpGender, "Select gender");
        if (Age < 18) Error(dtpDob, "Citizen must be at least 18 years old");
        if (cmbProvince.SelectedIndex < 0) Error(cmbProvince, "Select province");
        if (!mtxtPhone.MaskCompleted) Error(mtxtPhone, "Enter phone as 03XX-XXXXXXX");
        if (rtbAddress.Text.Trim().Length < 10) Error(rtbAddress, "Enter complete address");

        if (!mtxtCnic.MaskCompleted) Error(mtxtCnic, "Enter CNIC as 12345-1234567-1");
        else
        {
            bool oddLastDigit = (mtxtCnic.Text[^1] - '0') % 2 == 1;
            if (rbMale.Checked && !oddLastDigit) Error(mtxtCnic, "Male CNIC must end with an odd digit");
            if (rbFemale.Checked && oddLastDigit) Error(mtxtCnic, "Female CNIC must end with an even digit");
            if (cmbProvince.SelectedIndex >= 0 && mtxtCnic.Text[0] != provinceCodes[cmbProvince.Text])
                Error(mtxtCnic, $"CNIC for {cmbProvince.Text} must start with {provinceCodes[cmbProvince.Text]}");
        }
        return ok;
    }

    private Citizen ReadForm() => new Citizen
    {
        Cnic = mtxtCnic.Text,
        Name = txtName.Text.Trim(),
        FatherName = txtFather.Text.Trim(),
        Gender = rbMale.Checked ? "Male" : "Female",
        DateOfBirth = dtpDob.Value.Date,
        Province = cmbProvince.Text,
        MaritalStatus = cmbMarital.Text,
        Phone = mtxtPhone.Text,
        Address = rtbAddress.Text.Trim(),
        HeightCm = (int)nudHeight.Value,
        IsDisabled = chkDisabled.Checked,
        IssueDate = dtpIssue.Value.Date,
        ExpiryDate = Expiry,
        Photo = photo
    };

    // ---------------- CRUD buttons
    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;
        if (Database.Exists(mtxtCnic.Text))
        {
            errorProvider1.SetError(mtxtCnic, "This CNIC is already registered");
            return;
        }
        Database.Insert(ReadForm());
        MessageBox.Show("Citizen registered successfully.\nCNIC: " + mtxtCnic.Text, "Saved",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearForm();
        LoadGrid();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;
        if (!Database.Exists(mtxtCnic.Text))
        {
            MessageBox.Show("No record with this CNIC. Use Save to register.");
            return;
        }
        Database.Update(ReadForm());
        MessageBox.Show("Record updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearForm();
        LoadGrid();
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        txtName.Clear(); txtFather.Clear(); rtbAddress.Clear(); mtxtPhone.Clear();
        mtxtCnic.Clear(); mtxtCnic.ReadOnly = false;
        rbMale.Checked = rbFemale.Checked = chkDisabled.Checked = false;
        cmbProvince.SelectedIndex = -1;
        nudHeight.Value = 170;
        dtpDob.Value = DateTime.Today.AddYears(-20);
        photo = null; picPhoto.Image = null;
        errorProvider1.Clear();
    }

    private void btnSearch_Click(object sender, EventArgs e) => LoadGrid();

    private string SelectedCnic => dgvCitizens.CurrentRow?.Cells["Cnic"].Value?.ToString();

    // loads the selected record into the Register tab for editing
    private void btnEdit_Click(object sender, EventArgs e)
    {
        var c = Database.GetByCnic(SelectedCnic);
        if (c == null) return;
        ClearForm();
        mtxtCnic.Text = c.Cnic; mtxtCnic.ReadOnly = true;     // CNIC can't be changed
        txtName.Text = c.Name; txtFather.Text = c.FatherName;
        rbMale.Checked = c.Gender == "Male"; rbFemale.Checked = c.Gender == "Female";
        dtpDob.Value = c.DateOfBirth; cmbProvince.Text = c.Province; cmbMarital.Text = c.MaritalStatus;
        mtxtPhone.Text = c.Phone; rtbAddress.Text = c.Address; nudHeight.Value = c.HeightCm;
        chkDisabled.Checked = c.IsDisabled; dtpIssue.Value = c.IssueDate;
        photo = c.Photo;
        picPhoto.Image = photo == null ? null : Image.FromStream(new MemoryStream(photo));
        tabControl1.SelectedTab = tabRegister;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (SelectedCnic == null) return;
        if (MessageBox.Show($"Delete citizen {SelectedCnic}?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            Database.Delete(SelectedCnic);
            LoadGrid();
        }
    }

    // ---------------- menu
    private void mnuRegister_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabRegister;
    private void mnuSearch_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabSearch;
    private void mnuOpenCv_Click(object sender, EventArgs e) => new OpenCvForm().ShowDialog();
    private void mnuExit_Click(object sender, EventArgs e) => Close();
    private void mnuAbout_Click(object sender, EventArgs e) =>
        MessageBox.Show("NADRA Citizen Database System\nVisual Programming - Assignment 2", "About");
}
