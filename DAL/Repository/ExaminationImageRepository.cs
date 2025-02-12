using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class ExaminationImageRepository(MedicalSystemContext context) : IExaminationImageRepository
	{
		public async Task<ExaminationImage> GetByIdAsync(int id)
		{
			return await context.ExaminationImages.FindAsync(id);
		}
		public async Task<IEnumerable<ExaminationImage>> GetAllAsync()
		{
			return await context.ExaminationImages.ToListAsync();
		}
		public async Task<IEnumerable<ExaminationImage>> GetByExaminationIdAsync(int examinationId)
		{
			return await context.ExaminationImages.Where(ei => ei.ExaminationId == examinationId).ToListAsync();
		}

		public async Task AddAsync(ExaminationImage examinationImage)
		{
			await context.ExaminationImages.AddAsync(examinationImage);
		}

		public async Task UpdateAsync(ExaminationImage examinationImage)
		{
			context.ExaminationImages.Update(examinationImage);
		}

		public async Task DeleteAsync(int id)
		{
			var examinationImage = await GetByIdAsync(id);
			context.ExaminationImages.Remove(examinationImage);
		}
	}
}
