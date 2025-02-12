using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
	[Index(nameof(PatientNumber), IsUnique = true)]
	[Index(nameof(OIB), IsUnique = true)]
	public class Patient
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string OIB { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public string Gender { get; set; }

		[Required]
		public string PatientNumber { get; set; }
		public ICollection<MedicalHistory> MedicalHistory { get; set; }
		public ICollection<Examination> Examinations { get; set; }
		public ICollection<Prescription> Prescriptions { get; set; }
	}
}