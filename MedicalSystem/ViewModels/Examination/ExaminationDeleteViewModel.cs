using BL.Models;

namespace MedicalSystem.ViewModels.Examination
{
	public class ExaminationDeleteViewModel
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }
		public DateTime ExaminationDateTime { get; set; }
		public string ExaminationType { get; set; }
		public string Notes { get; set; }
		public List<ExaminationImageDto> Images { get; set; } = [];

		public string GetExaminationTypeName()
		{
			return ExaminationTypeOption.GetTypeName(ExaminationType);
		}
	}
}
