using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service;

public class PatientService(IUnitOfWork unitOfWork, IMapper mapper) : IPatientService
{
	public async Task<IEnumerable<PatientDto>> GetAllAsync()
	{
		var patients = await unitOfWork.Patients.GetAllAsync();
		return mapper.Map<IEnumerable<PatientDto>>(patients);
	}

	public async Task<PatientDto?> GetByIdAsync(int id)
	{
		var patient = await unitOfWork.Patients.GetByIdAsync(id);
		return patient == null ? null : mapper.Map<PatientDto>(patient);
	}

	public async Task<bool> AddAsync(PatientDto? patientDto)
	{
		if (patientDto == null) return false;

		var patient = mapper.Map<Patient>(patientDto);
		await unitOfWork.Patients.AddAsync(patient);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UpdateAsync(PatientDto? patientDto)
	{
		if (patientDto == null) return false;

		var patient = mapper.Map<Patient>(patientDto);
		await unitOfWork.Patients.UpdateAsync(patient);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var patient = await unitOfWork.Patients.GetByIdAsync(id);
		if (patient == null) return false;

		await unitOfWork.Patients.DeleteAsync(id);
		await unitOfWork.SaveChangesAsync();
		return true;
	}
}
