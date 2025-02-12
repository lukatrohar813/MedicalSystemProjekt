using BL.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.ViewModels.Prescription
{
	public class PrescriptionCreateViewModel
	{
		public int PatientId { get; set; }
		public string PatientName { get; set; }

		[Required(ErrorMessage = "Medicine is required")]
		public int MedicineId { get; set; }

		[Required(ErrorMessage = "Dosage is required")]
		public string Dosage { get; set; }

		[Required(ErrorMessage = "Prescription date is required")]
		[DataType(DataType.Date)]
		public DateTime PrescriptionDate { get; set; }

		[Required(ErrorMessage = "Instructions are required")]
		public string Instructions { get; set; }

		public IEnumerable<MedicineDto> AvailableMedicines { get; set; } = new List<MedicineDto>();
	}
}
