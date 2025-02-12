namespace BL.Models
{
	public class PatientDetailsDto
	{
		public PatientDto Patient { get; set; }
		public IEnumerable<MedicalHistoryDto> MedicalHistories { get; set; }
		public IEnumerable<ExaminationDto> Examinations { get; set; }
		public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
	}
}
