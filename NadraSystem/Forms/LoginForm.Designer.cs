namespace NadraSystem.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblUser = new Label();
        txtUsername = new TextBox();
        lblPass = new Label();
        txtPassword = new TextBox();
        chkShow = new CheckBox();
        btnLogin = new Button();
        btnExit = new Button();
        lblError = new Label();
        SuspendLayout();
        // lblTitle
        lblTitle.BackColor = Color.FromArgb(0, 104, 71);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Size = new Size(380, 60);
        lblTitle.Text = "NADRA Login";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // lblUser
        lblUser.Location = new Point(40, 82);
        lblUser.Size = new Size(100, 20);
        lblUser.Text = "Username";
        // txtUsername
        txtUsername.Location = new Point(40, 104);
        txtUsername.Size = new Size(300, 23);
        txtUsername.PlaceholderText = "admin";
        // lblPass
        lblPass.Location = new Point(40, 138);
        lblPass.Size = new Size(100, 20);
        lblPass.Text = "Password";
        // txtPassword
        txtPassword.Location = new Point(40, 160);
        txtPassword.Size = new Size(300, 23);
        txtPassword.UseSystemPasswordChar = true;
        // chkShow
        chkShow.Location = new Point(40, 190);
        chkShow.Size = new Size(140, 24);
        chkShow.Text = "Show password";
        chkShow.CheckedChanged += chkShow_CheckedChanged;
        // btnLogin
        btnLogin.BackColor = Color.FromArgb(0, 104, 71);
        btnLogin.ForeColor = Color.White;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Location = new Point(40, 225);
        btnLogin.Size = new Size(145, 34);
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;
        // btnExit
        btnExit.Location = new Point(195, 225);
        btnExit.Size = new Size(145, 34);
        btnExit.Text = "Exit";
        btnExit.Click += btnExit_Click;
        // lblError
        lblError.ForeColor = Color.Firebrick;
        lblError.Location = new Point(40, 268);
        lblError.Size = new Size(300, 22);
        // LoginForm
        AcceptButton = btnLogin;
        ClientSize = new Size(380, 300);
        Controls.AddRange(new Control[] { lblTitle, lblUser, txtUsername, lblPass, txtPassword, chkShow, btnLogin, btnExit, lblError });
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NADRA Citizen Database";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle, lblUser, lblPass, lblError;
    private TextBox txtUsername, txtPassword;
    private CheckBox chkShow;
    private Button btnLogin, btnExit;
}
