using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class IllnessRepository(MedicalSystemContext context) : IIllnessRepository
	{
		public async Task<Illness> GetByIdAsync(int id)
		{
			return await context.Illnesses.FindAsync(id);
		}

		public async Task<IEnumerable<Illness>> GetAllAsync()
		{
			return await context.Illnesses.ToListAsync();
		}

		public async Task AddAsync(Illness illness)
		{
			await context.Illnesses.AddAsync(illness);
		}

		public async Task UpdateAsync(Illness illness)
		{
			context.Illnesses.Update(illness);
		}

		public async Task DeleteAsync(int id)
		{
			var illness = await GetByIdAsync(id);
			if (illness == null)
				throw new KeyNotFoundException($"Illness with ID {id} not found.");

			context.Illnesses.Remove(illness);
		}
	}
}