using BL.Models;

namespace MedicalSystem.ViewModels.Examination
{
	public class ExaminationEditViewModel : ExaminationCreateViewModel
	{
		public int Id { get; set; }
		public List<ExaminationImageDto> ExistingImages { get; set; } = [];
	}

}
