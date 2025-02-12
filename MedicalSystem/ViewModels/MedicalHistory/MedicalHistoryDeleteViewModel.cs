namespace MedicalSystem.ViewModels.MedicalHistory
{
	public class MedicalHistoryDeleteViewModel
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }
		public string DiseaseName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Status => EndDate.HasValue ? "Recovered" : "Ongoing";
	}
}
