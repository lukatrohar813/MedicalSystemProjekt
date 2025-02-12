using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.Examination
{
	public class ExaminationCreateViewModel
	{
		public int PatientId { get; set; }

		[Required(ErrorMessage = "Examination date and time is required")]
		[Display(Name = "Examination Date & Time")]

		public DateTime ExaminationDateTime { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Examination type is required")]
		[Display(Name = "Examination Type")]
		public string ExaminationType { get; set; }

		[Required(ErrorMessage = "Notes are required")]
		[MinLength(10, ErrorMessage = "Notes must be at least 10 characters long")]
		public string Notes { get; set; }

		[Display(Name = "Examination Images")] public List<IFormFile> Images { get; set; } = [];

		public string PatientName { get; set; }

		// For dropdown
		public List<ExaminationTypeOption> ExaminationTypes { get; } =
		[
			new("GP", "General Physical Examination"),
			new("KRV", "Blood Test"),
			new("X-RAY", "X-Ray"),
			new("CT", "CT Scan"),
			new("MR", "MRI Scan"),
			new("ULTRA", "Ultrasound"),
			new("EKG", "Electrocardiogram"),
			new("ECHO", "Echocardiogram"),
			new("EYE", "Eye Examination"),
			new("DERM", "Dermatological Examination"),
			new("DENTA", "Dental Examination"),
			new("MAMMO", "Mammography"),
			new("NEURO", "Neurological Examination")
		];
	}
}