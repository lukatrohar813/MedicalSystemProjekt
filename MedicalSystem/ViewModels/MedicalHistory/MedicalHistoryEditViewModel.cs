using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.MedicalHistory
{
	public class MedicalHistoryEditViewModel
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }

		[Required(ErrorMessage = "Disease name is required")]
		[Display(Name = "Disease Name")]
		public string DiseaseName { get; set; }

		[Required(ErrorMessage = "Start date is required")]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
	}

}
