using BL.Models;

namespace MedicalSystem.Models.Patient
{
	public class PatientDetailsViewModel
	{
		public PatientDto Patient { get; set; }
		public IEnumerable<MedicalHistoryDto> MedicalHistories { get; set; }
		public IEnumerable<ExaminationDto> Examinations { get; set; }
		public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
	}
}
