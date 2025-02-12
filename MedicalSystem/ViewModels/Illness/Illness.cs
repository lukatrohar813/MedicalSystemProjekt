using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.Illness
{
	public class IllnessCreateViewModel
	{
		[Required(ErrorMessage = "Name is required")]
		[StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }
	}

	public class IllnessEditViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }
	}
}