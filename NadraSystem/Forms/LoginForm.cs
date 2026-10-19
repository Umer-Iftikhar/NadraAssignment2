namespace NadraSystem.Forms;

public partial class LoginForm : Form
{
    private int attempts = 0;

    public LoginForm()
    {
        InitializeComponent();
    }

    private void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShow.Checked;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
        {
            DialogResult = DialogResult.OK;
            return;
        }

        attempts++;
        lblError.Text = $"Invalid username or password ({3 - attempts} attempts left)";
        if (attempts == 3)
        {
            MessageBox.Show("Too many failed attempts. The application will close.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
            DialogResult = DialogResult.Cancel;
        }
    }

    private void btnExit_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
}
