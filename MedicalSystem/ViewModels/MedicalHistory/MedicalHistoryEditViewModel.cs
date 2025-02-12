using BL.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.MedicalHistory
{
	public class MedicalHistoryEditViewModel
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }

		[Required(ErrorMessage = "Illness is required")]
		public int IllnessId { get; set; }

		[Required(ErrorMessage = "Start date is required")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? EndDate { get; set; }
		public IEnumerable<IllnessDto> AvailableIllnesses { get; set; } = new List<IllnessDto>();
	}

}
