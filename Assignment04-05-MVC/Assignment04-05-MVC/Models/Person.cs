namespace Assignment04_05_MVC.Models;

public enum Gender
{
    Male,
    Female
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
	public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = "";
	public string BirthPlace { get; set; } = "";
	public bool IsGraduated { get; set; }
    public string FullName => FirstName+" "+LastName;
}
