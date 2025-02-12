using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class MedicalHistoryRepository(MedicalSystemContext context) : IMedicalHistoryRepository
	{
		public async Task<MedicalHistory> GetByIdAsync(int id)
		{
			return await context.MedicalHistories.FindAsync(id);
		}

		public async Task<IEnumerable<MedicalHistory>> GetByPatientIdAsync(int patientId)
		{
			return await context.MedicalHistories
				.Include(mh => mh.Illness)
				.Where(mh => mh.PatientId == patientId)
				.ToListAsync();
		}

		public async Task AddAsync(MedicalHistory medicalHistory)
		{
			await context.MedicalHistories.AddAsync(medicalHistory);
		}

		public async Task UpdateAsync(MedicalHistory medicalHistory)
		{
			 context.MedicalHistories.Update(medicalHistory);
		}
		public async Task<IEnumerable<MedicalHistory>> GetAllAsync()
		{
			return await context.MedicalHistories.ToListAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var medicalHistory = await GetByIdAsync(id);
			context.MedicalHistories.Remove(medicalHistory);
		}
	}

}
