namespace MedicalSystem.ViewModels.Prescription
{
	public class PrescriptionDetailsViewModel
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }
		public string MedicineName { get; set; }
		public string Dosage { get; set; }
		public DateTime PrescriptionDate { get; set; }
		public string Instructions { get; set; }
	}
}
