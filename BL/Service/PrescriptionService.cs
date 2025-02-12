using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service;

public class PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper) : IPrescriptionService
{
	public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
	{
		var prescriptions = await unitOfWork.Prescriptions.GetAllAsync();
		return mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
	}

	public async Task<IEnumerable<PrescriptionDto>> GetByPatientIdAsync(int patientId)
	{
		var prescriptions = await unitOfWork.Prescriptions
			.GetByPatientIdAsync(patientId);
		return mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
	}

	public async Task<PrescriptionDto?> GetByIdAsync(int id)
	{
		var prescription = await unitOfWork.Prescriptions.GetByIdAsync(id);
		return prescription == null ? null : mapper.Map<PrescriptionDto>(prescription);
	}

	public async Task<bool> AddAsync(PrescriptionDto prescriptionDto)
	{
		if (prescriptionDto == null) return false;

		prescriptionDto.PrescriptionDate = prescriptionDto.PrescriptionDate;

		var prescription = mapper.Map<Prescription>(prescriptionDto);
		await unitOfWork.Prescriptions.AddAsync(prescription);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UpdateAsync(PrescriptionDto? prescriptionDto)
	{
		if (prescriptionDto == null) return false;

		var prescription = mapper.Map<Prescription>(prescriptionDto);
		await unitOfWork.Prescriptions.UpdateAsync(prescription);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var prescription = await unitOfWork.Prescriptions.GetByIdAsync(id);
		if (prescription == null) return false;

		await unitOfWork.Prescriptions.DeleteAsync(id);
		await unitOfWork.SaveChangesAsync();
		return true;
	}
}

