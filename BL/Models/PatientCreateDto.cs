namespace BL.Models
{
	public class PatientCreateDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OIB { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string PatientNumber { get; set; }
	}
}
