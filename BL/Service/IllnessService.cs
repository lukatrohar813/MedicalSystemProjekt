using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service
{
	public class IllnessService(IUnitOfWork unitOfWork, IMapper mapper) : IIllnessService
	{
		public async Task<IEnumerable<IllnessDto>> GetAllAsync()
		{
			var illnesses = await unitOfWork.Illnesses.GetAllAsync();
			return mapper.Map<IEnumerable<IllnessDto>>(illnesses);
		}

		public async Task<IllnessDto?> GetByIdAsync(int id)
		{
			var illness = await unitOfWork.Illnesses.GetByIdAsync(id);
			return illness == null ? null : mapper.Map<IllnessDto>(illness);
		}

		public async Task<bool> AddAsync(IllnessDto? illnessDto)
		{
			if (illnessDto == null) return false;

			var illness = mapper.Map<Illness>(illnessDto);
			await unitOfWork.Illnesses.AddAsync(illness);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> UpdateAsync(IllnessDto? illnessDto)
		{
			if (illnessDto == null) return false;

			var illness = mapper.Map<Illness>(illnessDto);
			await unitOfWork.Illnesses.UpdateAsync(illness);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var illness = await unitOfWork.Illnesses.GetByIdAsync(id);
			if (illness == null) return false;

			await unitOfWork.Illnesses.DeleteAsync(id);
			await unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}