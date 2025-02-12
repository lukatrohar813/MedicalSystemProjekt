using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
	public class ExaminationImageDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Examination ID is required")]
		public int ExaminationId { get; set; }

		[Required(ErrorMessage = "Image path is required")]
		public string ImagePath { get; set; }

		public DateTime UploadDateTime { get; set; }
	}
}
