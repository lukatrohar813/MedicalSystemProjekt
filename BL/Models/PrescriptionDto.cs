using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
	public class PrescriptionDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Patient ID is required")]
		public int PatientId { get; set; }

		[Required(ErrorMessage = "Medicine name is required")]
		public string MedicineName { get; set; }

		[Required(ErrorMessage = "Dosage is required")]
		public string Dosage { get; set; }

		[Required(ErrorMessage = "Prescription date is required")]
		[DataType(DataType.Date)]
		public DateTime PrescriptionDate { get; set; }

		[Required(ErrorMessage = "Instructions are required")]
		public string Instructions { get; set; }
	}
}
