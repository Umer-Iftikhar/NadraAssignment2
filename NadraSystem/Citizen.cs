namespace NadraSystem;

/// <summary>One citizen record in the NADRA database.</summary>
public class Citizen
{
    public int Id { get; set; }
    public string Cnic { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Province { get; set; }
    public string MaritalStatus { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int HeightCm { get; set; }
    public bool IsDisabled { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public byte[] Photo { get; set; }
}
