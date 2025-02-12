using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
	public class Prescription
	{
		public int Id { get; set; }

		[Required] public int PatientId { get; set; }

		[Required] public int MedicineId { get; set; }

		[Required] public string Dosage { get; set; }

		[Required] public DateTime PrescriptionDate { get; set; }

		[Required] public string Instructions { get; set; }

		public Patient Patient { get; set; }
		public Medicine Medicine { get; set; }
	}
}
