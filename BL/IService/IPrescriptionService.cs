using BL.Models;


namespace BL.IService
{
	public interface IPrescriptionService
	{
		Task<IEnumerable<PrescriptionDto>> GetAllAsync();
		Task<IEnumerable<PrescriptionDto>> GetByPatientIdAsync(int patientId);
		Task<PrescriptionDto?> GetByIdAsync(int id);
		Task<bool> AddAsync(PrescriptionDto? prescriptionDto);
		Task<bool> UpdateAsync(PrescriptionDto? prescriptionDto);
		Task<bool> DeleteAsync(int id);
	}
}
