using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class ExaminationRepository(MedicalSystemContext context) : IExaminationRepository
	{
		public async Task<Examination> GetByIdAsync(int id)
		{
			return await context.Examinations.FindAsync(id);
		}

		public async Task<IEnumerable<Examination>> GetByPatientIdAsync(int patientId)
		{
			return await context.Examinations.Where(e => e.PatientId == patientId).ToListAsync();
		}
		public async Task<IEnumerable<Examination>> GetAllAsync()
		{
			return await context.Examinations.ToListAsync();
		}

		public async Task AddAsync(Examination examination)
		{
			await context.Examinations.AddAsync(examination);
		}

		public async Task UpdateAsync(Examination examination)
		{
			context.Examinations.Update(examination);
		}

		public async Task DeleteAsync(int id)
		{
			var examination = await GetByIdAsync(id);
			context.Examinations.Remove(examination);
		}
	}
}
