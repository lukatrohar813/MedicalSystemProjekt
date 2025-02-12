using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Models.Patient
{
	public class PatientCreateViewModel
	{
		[Required(ErrorMessage = "First name is required")]
		[StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "OIB is required")]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "OIB must be exactly 11 characters")]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "OIB must contain exactly 11 digits")]
		public string OIB { get; set; }

		[Required(ErrorMessage = "Date of birth is required")]
		[DataType(DataType.Date)]
		[Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Gender is required")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Patient number is required")]
		[Display(Name = "Patient Number")]
		public string PatientNumber { get; set; }
	}
}