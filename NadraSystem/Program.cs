using NadraSystem.Forms;

namespace NadraSystem;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Database.Initialize();                       // creates nadra.db on first run

        using var login = new LoginForm();
        if (login.ShowDialog() == DialogResult.OK)
            Application.Run(new MainForm());
    }
}
