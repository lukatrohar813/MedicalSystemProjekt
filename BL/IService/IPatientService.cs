using BL.Models;


namespace BL.IService
{
	public interface IPatientService
	{
		Task<IEnumerable<PatientDto>> GetAllAsync();
		Task<PatientDto> GetByIdAsync(int id);
		Task<bool> AddAsync(PatientDto? patientDto);
		Task<bool> UpdateAsync(PatientDto? patientDto);
		Task<bool> DeleteAsync(int id);
	}
}
