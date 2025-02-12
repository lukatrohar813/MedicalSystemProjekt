using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service;

public class MedicalHistoryService(IUnitOfWork unitOfWork, IMapper mapper) : IMedicalHistoryService
{
	public async Task<IEnumerable<MedicalHistoryDto>> GetAllAsync()
	{
		var histories = await unitOfWork.MedicalHistories.GetAllAsync();
		return mapper.Map<IEnumerable<MedicalHistoryDto>>(histories);
	}

	public async Task<IEnumerable<MedicalHistoryDto>> GetByPatientIdAsync(int patientId)
	{
		var histories = await unitOfWork.MedicalHistories
			.GetByPatientIdAsync(patientId);
		return mapper.Map<IEnumerable<MedicalHistoryDto>>(histories);
	}

	public async Task<MedicalHistoryDto> GetByIdAsync(int id)
	{
		var history = await unitOfWork.MedicalHistories.GetByIdAsync(id);
		return mapper.Map<MedicalHistoryDto>(history);
	}

	public async Task<bool> AddAsync(MedicalHistoryDto medicalHistoryDto)
	{
		if (medicalHistoryDto == null) return false;

		medicalHistoryDto.StartDate = medicalHistoryDto.StartDate;
		if (medicalHistoryDto.EndDate.HasValue)
		{
			medicalHistoryDto.EndDate = medicalHistoryDto.EndDate;
		}

		var history = mapper.Map<MedicalHistory>(medicalHistoryDto);
		await unitOfWork.MedicalHistories.AddAsync(history);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UpdateAsync(MedicalHistoryDto? medicalHistoryDto)
	{
		if (medicalHistoryDto == null) return false;

		var history = mapper.Map<MedicalHistory>(medicalHistoryDto);
		await unitOfWork.MedicalHistories.UpdateAsync(history);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{

		await unitOfWork.MedicalHistories.DeleteAsync(id);
		await unitOfWork.SaveChangesAsync();
		return true;
	}
}
