using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class MedicineRepository(MedicalSystemContext context) : IMedicineRepository
	{
		public async Task<Medicine> GetByIdAsync(int id)
		{
			return await context.Medicines.FindAsync(id);
		}

		public async Task<IEnumerable<Medicine>> GetAllAsync()
		{
			return await context.Medicines.ToListAsync();
		}

		public async Task AddAsync(Medicine medicine)
		{
			await context.Medicines.AddAsync(medicine);
		}

		public async Task UpdateAsync(Medicine medicine)
		{
			context.Medicines.Update(medicine);
		}

		public async Task DeleteAsync(int id)
		{
			var medicine = await GetByIdAsync(id);
			if (medicine == null)
				throw new KeyNotFoundException($"Medicine with ID {id} not found.");

			context.Medicines.Remove(medicine);
		}
	}
}