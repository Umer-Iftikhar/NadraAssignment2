namespace NadraSystem.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private static Label MakeLabel(string text, int x, int y) =>
        new Label { Text = text, Location = new Point(x, y), AutoSize = true };

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        mnuFile = new ToolStripMenuItem("&File");
        mnuExit = new ToolStripMenuItem("E&xit");
        mnuRecords = new ToolStripMenuItem("&Records");
        mnuRegister = new ToolStripMenuItem("&Register Citizen");
        mnuSearch = new ToolStripMenuItem("&Search Records");
        mnuTools = new ToolStripMenuItem("&Tools");
        mnuOpenCv = new ToolStripMenuItem("&OpenCV Image Lab");
        mnuHelp = new ToolStripMenuItem("&Help");
        mnuAbout = new ToolStripMenuItem("&About");
        statusStrip1 = new StatusStrip();
        lblRecords = new ToolStripStatusLabel();
        lblClock = new ToolStripStatusLabel();
        timer1 = new System.Windows.Forms.Timer(components);
        tabControl1 = new TabControl();
        tabRegister = new TabPage("Register Citizen");
        tabSearch = new TabPage("Search Records");
        grpPersonal = new GroupBox();
        txtName = new TextBox();
        txtFather = new TextBox();
        grpGender = new GroupBox();
        rbMale = new RadioButton();
        rbFemale = new RadioButton();
        dtpDob = new DateTimePicker();
        lblAge = new Label();
        cmbProvince = new ComboBox();
        cmbMarital = new ComboBox();
        nudHeight = new NumericUpDown();
        chkDisabled = new CheckBox();
        grpContact = new GroupBox();
        mtxtPhone = new MaskedTextBox();
        rtbAddress = new RichTextBox();
        grpCnic = new GroupBox();
        mtxtCnic = new MaskedTextBox();
        dtpIssue = new DateTimePicker();
        lblExpiry = new Label();
        grpPhoto = new GroupBox();
        picPhoto = new PictureBox();
        btnBrowse = new Button();
        btnSave = new Button();
        btnUpdate = new Button();
        btnClear = new Button();
        txtSearch = new TextBox();
        pnlSearchTop = new Panel();
        pnlSearchBottom = new Panel();
        btnSearch = new Button();
        dgvCitizens = new DataGridView();
        gridMenu = new ContextMenuStrip(components);
        mnuGridEdit = new ToolStripMenuItem("Edit");
        mnuGridDelete = new ToolStripMenuItem("Delete");
        btnEdit = new Button();
        btnDelete = new Button();
        lblCount = new Label();
        errorProvider1 = new ErrorProvider(components);
        toolTip1 = new ToolTip(components);
        openFileDialog1 = new OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)nudHeight).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvCitizens).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // ===== MenuStrip
        mnuFile.DropDownItems.Add(mnuExit);
        mnuRecords.DropDownItems.AddRange(new ToolStripItem[] { mnuRegister, mnuSearch });
        mnuTools.DropDownItems.Add(mnuOpenCv);
        mnuHelp.DropDownItems.Add(mnuAbout);
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuRecords, mnuTools, mnuHelp });
        mnuRegister.ShortcutKeys = Keys.Control | Keys.N;
        mnuSearch.ShortcutKeys = Keys.Control | Keys.F;
        mnuOpenCv.ShortcutKeys = Keys.Control | Keys.O;
        mnuExit.Click += mnuExit_Click;
        mnuRegister.Click += mnuRegister_Click;
        mnuSearch.Click += mnuSearch_Click;
        mnuOpenCv.Click += mnuOpenCv_Click;
        mnuAbout.Click += mnuAbout_Click;

        // ===== StatusStrip + Timer
        lblRecords.Spring = true;
        lblRecords.TextAlign = ContentAlignment.MiddleLeft;
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblRecords, lblClock });
        timer1.Interval = 1000;
        timer1.Tick += timer1_Tick;

        // ===== TabControl
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Controls.Add(tabRegister);
        tabControl1.Controls.Add(tabSearch);

        // ===== Personal information
        grpPersonal.Text = "Personal Information";
        grpPersonal.Location = new Point(12, 12);
        grpPersonal.Size = new Size(470, 330);
        txtName.SetBounds(130, 27, 310, 23);
        txtFather.SetBounds(130, 62, 310, 23);
        grpGender.Text = "Gender";
        grpGender.SetBounds(15, 92, 425, 52);
        rbMale.Text = "Male"; rbMale.SetBounds(15, 20, 80, 24);
        rbFemale.Text = "Female"; rbFemale.SetBounds(115, 20, 90, 24);
        grpGender.Controls.AddRange(new Control[] { rbMale, rbFemale });
        dtpDob.Format = DateTimePickerFormat.Short;
        dtpDob.SetBounds(130, 157, 150, 23);
        dtpDob.ValueChanged += dtpDob_ValueChanged;
        lblAge.SetBounds(290, 160, 150, 20);
        cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProvince.SetBounds(130, 192, 200, 23);
        cmbMarital.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMarital.SetBounds(130, 227, 200, 23);
        nudHeight.Minimum = 100; nudHeight.Maximum = 230; nudHeight.Value = 170;
        nudHeight.SetBounds(130, 262, 80, 23);
        chkDisabled.Text = "Person with disability";
        chkDisabled.SetBounds(130, 294, 200, 24);
        grpPersonal.Controls.AddRange(new Control[]
        {
            MakeLabel("Full Name *", 15, 30), txtName, MakeLabel("Father Name *", 15, 65), txtFather, grpGender,
            MakeLabel("Date of Birth *", 15, 160), dtpDob, lblAge, MakeLabel("Province *", 15, 195), cmbProvince,
            MakeLabel("Marital Status", 15, 230), cmbMarital, MakeLabel("Height (cm)", 15, 265), nudHeight, chkDisabled
        });

        // ===== Contact
        grpContact.Text = "Contact Details";
        grpContact.SetBounds(12, 352, 470, 140);
        mtxtPhone.Mask = "0000-0000000";
        mtxtPhone.SetBounds(130, 27, 150, 23);
        rtbAddress.SetBounds(130, 62, 310, 64);
        grpContact.Controls.AddRange(new Control[]
            { MakeLabel("Phone *", 15, 30), mtxtPhone, MakeLabel("Address *", 15, 65), rtbAddress });

        // ===== CNIC
        grpCnic.Text = "CNIC Details";
        grpCnic.SetBounds(495, 12, 470, 130);
        mtxtCnic.Mask = "00000-0000000-0";
        mtxtCnic.Font = new Font("Consolas", 10F, FontStyle.Bold);
        mtxtCnic.SetBounds(130, 26, 160, 23);
        dtpIssue.Format = DateTimePickerFormat.Short;
        dtpIssue.SetBounds(130, 62, 150, 23);
        dtpIssue.ValueChanged += dtpIssue_ValueChanged;
        lblExpiry.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblExpiry.SetBounds(130, 96, 250, 20);
        grpCnic.Controls.AddRange(new Control[]
            { MakeLabel("CNIC Number *", 15, 30), mtxtCnic, MakeLabel("Issue Date", 15, 65), dtpIssue, lblExpiry });

        // ===== Photo
        grpPhoto.Text = "Photograph";
        grpPhoto.SetBounds(495, 150, 470, 240);
        picPhoto.BorderStyle = BorderStyle.FixedSingle;
        picPhoto.BackColor = Color.Gainsboro;
        picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        picPhoto.SetBounds(15, 25, 160, 200);
        btnBrowse.Text = "Browse...";
        btnBrowse.SetBounds(190, 25, 120, 30);
        btnBrowse.Click += btnBrowse_Click;
        grpPhoto.Controls.AddRange(new Control[] { picPhoto, btnBrowse });

        // ===== Buttons
        btnSave.Text = "Save"; btnSave.SetBounds(495, 410, 145, 40);
        btnSave.BackColor = Color.FromArgb(0, 104, 71); btnSave.ForeColor = Color.White; btnSave.FlatStyle = FlatStyle.Flat;
        btnUpdate.Text = "Update"; btnUpdate.SetBounds(657, 410, 145, 40);
        btnClear.Text = "Clear"; btnClear.SetBounds(819, 410, 145, 40);
        btnSave.Click += btnSave_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnClear.Click += btnClear_Click;
        tabRegister.Controls.AddRange(new Control[] { grpPersonal, grpContact, grpCnic, grpPhoto, btnSave, btnUpdate, btnClear });

        // ===== Search tab (top panel + grid + bottom panel, using Dock)
        pnlSearchTop.Dock = DockStyle.Top;
        pnlSearchTop.Height = 50;
        txtSearch.SetBounds(110, 14, 300, 23);
        txtSearch.PlaceholderText = "Name, father name or CNIC";
        btnSearch.Text = "Search"; btnSearch.SetBounds(420, 12, 100, 28);
        btnSearch.Click += btnSearch_Click;
        pnlSearchTop.Controls.AddRange(new Control[] { MakeLabel("Search citizen:", 10, 17), txtSearch, btnSearch });
        pnlSearchBottom.Dock = DockStyle.Bottom;
        pnlSearchBottom.Height = 50;
        btnEdit.Text = "Edit Selected"; btnEdit.SetBounds(10, 8, 140, 34);
        btnDelete.Text = "Delete Selected"; btnDelete.SetBounds(160, 8, 140, 34);
        btnDelete.ForeColor = Color.Firebrick;
        btnEdit.Click += btnEdit_Click;
        btnDelete.Click += btnDelete_Click;
        lblCount.SetBounds(320, 16, 250, 20);
        pnlSearchBottom.Controls.AddRange(new Control[] { btnEdit, btnDelete, lblCount });
        dgvCitizens.Dock = DockStyle.Fill;
        dgvCitizens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCitizens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCitizens.ReadOnly = true;
        dgvCitizens.AllowUserToAddRows = false;
        dgvCitizens.MultiSelect = false;
        dgvCitizens.BackgroundColor = Color.White;
        dgvCitizens.ContextMenuStrip = gridMenu;
        gridMenu.Items.AddRange(new ToolStripItem[] { mnuGridEdit, mnuGridDelete });
        mnuGridEdit.Click += btnEdit_Click;
        mnuGridDelete.Click += btnDelete_Click;
        tabSearch.Controls.Add(dgvCitizens);          // Fill control is added first
        tabSearch.Controls.Add(pnlSearchTop);
        tabSearch.Controls.Add(pnlSearchBottom);

        // ===== Components
        errorProvider1.ContainerControl = this;
        openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

        // ===== MainForm
        ClientSize = new Size(990, 640);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Font = new Font("Segoe UI", 9F);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NADRA Citizen Database System";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)nudHeight).EndInit();
        ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvCitizens).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuFile, mnuExit, mnuRecords, mnuRegister, mnuSearch, mnuTools, mnuOpenCv, mnuHelp, mnuAbout;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblRecords, lblClock;
    private System.Windows.Forms.Timer timer1;
    private TabControl tabControl1;
    private TabPage tabRegister, tabSearch;
    private GroupBox grpPersonal, grpGender, grpContact, grpCnic, grpPhoto;
    private TextBox txtName, txtFather, txtSearch;
    private RadioButton rbMale, rbFemale;
    private DateTimePicker dtpDob, dtpIssue;
    private Label lblAge, lblExpiry, lblCount;
    private ComboBox cmbProvince, cmbMarital;
    private NumericUpDown nudHeight;
    private CheckBox chkDisabled;
    private MaskedTextBox mtxtPhone, mtxtCnic;
    private RichTextBox rtbAddress;
    private PictureBox picPhoto;
    private Button btnBrowse, btnSave, btnUpdate, btnClear, btnSearch, btnEdit, btnDelete;
    private DataGridView dgvCitizens;
    private Panel pnlSearchTop, pnlSearchBottom;
    private ContextMenuStrip gridMenu;
    private ToolStripMenuItem mnuGridEdit, mnuGridDelete;
    private ErrorProvider errorProvider1;
    private ToolTip toolTip1;
    private OpenFileDialog openFileDialog1;
}
