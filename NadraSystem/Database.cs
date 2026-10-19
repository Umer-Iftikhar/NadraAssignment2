using Dapper;
using Microsoft.Data.Sqlite;

namespace NadraSystem;

/// <summary>Data access for the NADRA citizen database (SQLite file: nadra.db) using Dapper.</summary>
public static class Database
{
    private static readonly string ConnStr =
        "Data Source=" + Path.Combine(AppContext.BaseDirectory, "nadra.db");

    private static SqliteConnection Open() => new SqliteConnection(ConnStr);   // Dapper opens/closes it

    public static void Initialize()
    {
        using var con = Open();
        con.Execute(@"CREATE TABLE IF NOT EXISTS Citizens(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Cnic TEXT NOT NULL UNIQUE, Name TEXT NOT NULL, FatherName TEXT NOT NULL,
            Gender TEXT, DateOfBirth TEXT, Province TEXT, MaritalStatus TEXT, Phone TEXT,
            Address TEXT, HeightCm INTEGER, IsDisabled INTEGER,
            IssueDate TEXT, ExpiryDate TEXT, Photo BLOB)");

        // sample records on first run
        if (con.ExecuteScalar<int>("SELECT COUNT(*) FROM Citizens") == 0)
        {
            Seed("35202-1234567-1", "Ahmed Raza", "Raza Hussain", "Male", 1991, "Punjab", "Married");
            Seed("61101-7654321-2", "Fatima Noor", "Noor Muhammad", "Female", 1997, "Islamabad", "Single");
            Seed("17301-2345678-3", "Bilal Khan", "Sher Khan", "Male", 1985, "Khyber Pakhtunkhwa", "Married");
            Seed("42101-3456789-4", "Sana Memon", "Ibrahim Memon", "Female", 2001, "Sindh", "Single");
            Seed("54400-4567890-5", "Usman Baloch", "Akbar Baloch", "Male", 1979, "Balochistan", "Widowed");
        }
    }

    private static void Seed(string cnic, string name, string father, string gender, int year, string prov, string marital)
    {
        var issue = new DateTime(2022, 3, 15);
        Insert(new Citizen
        {
            Cnic = cnic, Name = name, FatherName = father, Gender = gender,
            DateOfBirth = new DateTime(year, 6, 1), Province = prov, MaritalStatus = marital,
            Phone = "0300-1234567", Address = "House 1, Street 1, " + prov, HeightCm = 170,
            IssueDate = issue, ExpiryDate = issue.AddYears(10)
        });
    }

    // Dapper maps the @Parameters to the Citizen properties with the same names
    public static void Insert(Citizen c)
    {
        using var con = Open();
        con.Execute(@"INSERT INTO Citizens(Cnic, Name, FatherName, Gender, DateOfBirth, Province, MaritalStatus,
                                          Phone, Address, HeightCm, IsDisabled, IssueDate, ExpiryDate, Photo)
                      VALUES(@Cnic, @Name, @FatherName, @Gender, @DateOfBirth, @Province, @MaritalStatus,
                             @Phone, @Address, @HeightCm, @IsDisabled, @IssueDate, @ExpiryDate, @Photo)", c);
    }

    public static void Update(Citizen c)
    {
        using var con = Open();
        con.Execute(@"UPDATE Citizens SET Name=@Name, FatherName=@FatherName, Gender=@Gender,
                      DateOfBirth=@DateOfBirth, Province=@Province, MaritalStatus=@MaritalStatus, Phone=@Phone,
                      Address=@Address, HeightCm=@HeightCm, IsDisabled=@IsDisabled, IssueDate=@IssueDate,
                      ExpiryDate=@ExpiryDate, Photo=@Photo
                      WHERE Cnic=@Cnic", c);
    }

    public static void Delete(string cnic)
    {
        using var con = Open();
        con.Execute("DELETE FROM Citizens WHERE Cnic=@cnic", new { cnic });
    }

    public static bool Exists(string cnic)
    {
        using var con = Open();
        return con.ExecuteScalar<int>("SELECT COUNT(*) FROM Citizens WHERE Cnic=@cnic", new { cnic }) > 0;
    }

    public static Citizen GetByCnic(string cnic)
    {
        using var con = Open();
        return con.QueryFirstOrDefault<Citizen>("SELECT * FROM Citizens WHERE Cnic=@cnic", new { cnic });
    }

    /// <summary>Searches by name, father name or CNIC.</summary>
    public static List<Citizen> Search(string text)
    {
        using var con = Open();
        return con.Query<Citizen>(@"SELECT * FROM Citizens
                                    WHERE Name LIKE @t OR FatherName LIKE @t OR Cnic LIKE @t
                                    ORDER BY Name", new { t = "%" + text + "%" }).ToList();
    }
}
