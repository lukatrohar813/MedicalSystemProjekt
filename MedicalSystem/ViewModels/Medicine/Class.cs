using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.Medicine
{
	public class MedicineCreateViewModel
	{
		[Required(ErrorMessage = "Name is required")]
		[StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }
	}

	public class MedicineEditViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }
	}
}