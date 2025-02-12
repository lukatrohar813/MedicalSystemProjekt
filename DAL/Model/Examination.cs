using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
	public class Examination
	{
		public int Id { get; set; }
		[Required]
		public int PatientId { get; set; }
		[Required]
		public DateTime ExaminationDateTime { get; set; }
		[Required]
		public string ExaminationType { get; set; }
		[Required]
		public string Notes { get; set; }
		public Patient Patient { get; set; }
		public ICollection<ExaminationImage> ExaminationImages { get; set; }
	}
}
