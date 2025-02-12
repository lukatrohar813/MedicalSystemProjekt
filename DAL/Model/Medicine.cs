using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
	public class Medicine
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public ICollection<Prescription> Prescriptions { get; set; }
	}
}