using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
	public class MedicalHistory
	{
		public int Id { get; set; }

		[Required]
		public int PatientId { get; set; }

		[Required]
		public int IllnessId { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public Patient Patient { get; set; }
		public Illness Illness { get; set; }
	}
}
