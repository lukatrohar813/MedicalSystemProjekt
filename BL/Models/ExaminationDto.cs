using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
	public class ExaminationDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Patient ID is required")]
		public int PatientId { get; set; }

		[Required(ErrorMessage = "Examination date and time is required")]
		public DateTime ExaminationDateTime { get; set; }

		[Required(ErrorMessage = "Examination type is required")]
		[RegularExpression("^(GP|KRV|X-RAY|CT|MR|ULTRA|EKG|ECHO|EYE|DERM|DENTA|MAMMO|NEURO)$",
			ErrorMessage = "Invalid examination type")]
		public string ExaminationType { get; set; }

		[Required(ErrorMessage = "Notes are required")]
		public string Notes { get; set; }
	}
}
