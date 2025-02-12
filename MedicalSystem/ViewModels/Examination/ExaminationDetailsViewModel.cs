using BL.Models;

namespace MedicalSystem.ViewModels.Examination
{
	public class ExaminationDetailsViewModel
	{
		public ExaminationDto Examination { get; set; }
		public string PatientName { get; set; }
		public List<ExaminationImageDto> Images { get; set; } = [];

		public string GetExaminationTypeName()
		{
			return ExaminationTypeOption.GetTypeName(Examination.ExaminationType);
		}
	}
}