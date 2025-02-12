using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service;

public class ExaminationService(IUnitOfWork unitOfWork, IMapper mapper) : IExaminationService
{


	public async Task<IEnumerable<ExaminationDto>> GetAllAsync()
	{
		var examinations = await unitOfWork.Examinations.GetAllAsync();
		return mapper.Map<IEnumerable<ExaminationDto>>(examinations);
	}

	public async Task<IEnumerable<ExaminationDto>> GetByPatientIdAsync(int patientId)
	{
		var examinations = await unitOfWork.Examinations.GetByPatientIdAsync(patientId);
		return mapper.Map<IEnumerable<ExaminationDto>>(examinations);
	}

	public async Task<ExaminationDto> GetByIdAsync(int id)
	{
		var examination = await unitOfWork.Examinations.GetByIdAsync(id);
		return examination == null ? null : mapper.Map<ExaminationDto>(examination);
	}

	public async Task<bool> AddAsync(ExaminationDto examinationDto)
	{
		if (examinationDto == null) return false;

		try
		{
			var examination = mapper.Map<Examination>(examinationDto);
			await unitOfWork.Examinations.AddAsync(examination);
			await unitOfWork.SaveChangesAsync();

			examinationDto.Id = examination.Id;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<bool> UpdateAsync(ExaminationDto? examinationDto)
	{
		if (examinationDto == null) return false;

		var examination = mapper.Map<Examination>(examinationDto);
		await unitOfWork.Examinations.UpdateAsync(examination);
		await unitOfWork.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var examination = await unitOfWork.Examinations.GetByIdAsync(id);
		if (examination == null) return false;

		await unitOfWork.Examinations.DeleteAsync(id);
		await unitOfWork.SaveChangesAsync();
		return true;
	}
}
