using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.Prescription
{
	public class PrescriptionCreateViewModel
	{
		public int PatientId { get; set; }
		public string PatientName { get; set; }

		[Required(ErrorMessage = "Medicine name is required")]
		[Display(Name = "Medicine Name")]
		public string MedicineName { get; set; }

		[Required(ErrorMessage = "Dosage is required")]
		[Display(Name = "Dosage")]
		public string Dosage { get; set; }

		[Required(ErrorMessage = "Date is required")]
		[Display(Name = "Prescription Date")]
		public DateTime PrescriptionDate { get; set; }

		[Required(ErrorMessage = "Instructions are required")]
		[Display(Name = "Instructions")]
		[MinLength(10, ErrorMessage = "Instructions must be at least 10 characters long")]
		public string Instructions { get; set; }
	}
}
