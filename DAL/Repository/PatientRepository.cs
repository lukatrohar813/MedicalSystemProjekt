using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class PatientRepository(MedicalSystemContext context) : IPatientRepository
	{

		public async Task<Patient> GetByIdAsync(int id)
		{
			return await context.Patients.FindAsync(id);
		}

		public async Task<IEnumerable<Patient>> GetAllAsync()
		{
			return await context.Patients.ToListAsync();
		}

		public async Task AddAsync(Patient patient)
		{
			await context.Patients.AddAsync(patient);
		}

		public async Task UpdateAsync(Patient patient)
		{
			context.Patients.Update(patient);
		}

		public async Task DeleteAsync(int id)
		{
			var patient = await GetByIdAsync(id);
			if (patient == null)
				throw new KeyNotFoundException($"Patient with ID {id} not found.");

			context.Patients.Remove(patient);
		}
	}
}
