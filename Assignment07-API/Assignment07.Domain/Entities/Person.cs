using Assignment07.Domain.Enums;
using Assignment07.Domain.Primitives;

namespace Assignment07.Domain.Entities;

public class Person : Entity, IAuditableEntity
{
    public string FirstName { get; set; } = "";
	public string LastName { get; set; } = "";
	public DateTime DateOfBirth { get; set; }
	public Gender Gender { get; set; }
	public string BirthPlace { get; set; } = "";
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
