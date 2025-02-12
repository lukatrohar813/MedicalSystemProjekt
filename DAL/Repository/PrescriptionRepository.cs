using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class PrescriptionRepository(MedicalSystemContext context) : IPrescriptionRepository
	{
		public async Task<Prescription> GetByIdAsync(int id)
		{
			return await context.Prescriptions.FindAsync(id);
		}

		public async Task<IEnumerable<Prescription>> GetByPatientIdAsync(int patientId)
		{
			return await context.Prescriptions
				.Include(p => p.Medicine)
				.Where(p => p.PatientId == patientId)
				.ToListAsync();
		}
		public async Task<IEnumerable<Prescription>> GetAllAsync()
		{
			return await context.Prescriptions.ToListAsync();
		}

		public async Task AddAsync(Prescription prescription)
		{
			await context.Prescriptions.AddAsync(prescription);
		}

		public async Task UpdateAsync(Prescription prescription)
		{
			context.Prescriptions.Update(prescription);
		}

		public async Task DeleteAsync(int id)
		{
			var prescription = await GetByIdAsync(id);
			context.Prescriptions.Remove(prescription);
		}
	}

}
