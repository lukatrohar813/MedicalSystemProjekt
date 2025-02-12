using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
	public class MedicalHistoryDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Patient ID is required")]
		public int PatientId { get; set; }

		[Required(ErrorMessage = "Illness ID is required")]
		public int IllnessId { get; set; }

		[Required(ErrorMessage = "Start date is required")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? EndDate { get; set; }

		public IllnessDto? Illness { get; set; }
	}
}