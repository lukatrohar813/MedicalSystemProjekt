namespace DAL.Model
{
	public class ExaminationImage
	{
		public int Id { get; set; }
		public int ExaminationId { get; set; }
		public string ImagePath { get; set; }
		public DateTime UploadDateTime { get; set; }

		public Examination Examination { get; set; }
	}
}
