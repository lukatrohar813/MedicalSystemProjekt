using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;

namespace BL.Service
{
	public class MedicineService(IUnitOfWork unitOfWork, IMapper mapper) : IMedicineService
	{
		public async Task<IEnumerable<MedicineDto>> GetAllAsync()
		{
			var medicines = await unitOfWork.Medicines.GetAllAsync();
			return mapper.Map<IEnumerable<MedicineDto>>(medicines);
		}

		public async Task<MedicineDto?> GetByIdAsync(int id)
		{
			var medicine = await unitOfWork.Medicines.GetByIdAsync(id);
			return medicine == null ? null : mapper.Map<MedicineDto>(medicine);
		}

		public async Task<bool> AddAsync(MedicineDto? medicineDto)
		{
			if (medicineDto == null) return false;

			var medicine = mapper.Map<Medicine>(medicineDto);
			await unitOfWork.Medicines.AddAsync(medicine);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> UpdateAsync(MedicineDto? medicineDto)
		{
			if (medicineDto == null) return false;

			var medicine = mapper.Map<Medicine>(medicineDto);
			await unitOfWork.Medicines.UpdateAsync(medicine);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var medicine = await unitOfWork.Medicines.GetByIdAsync(id);
			if (medicine == null) return false;

			await unitOfWork.Medicines.DeleteAsync(id);
			await unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}