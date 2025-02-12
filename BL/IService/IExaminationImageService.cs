using BL.Models;
using Microsoft.AspNetCore.Http;

namespace BL.IService;

public interface IExaminationImageService
{
	Task<IEnumerable<ExaminationImageDto>> GetAllAsync();
	Task<IEnumerable<ExaminationImageDto>> GetByExaminationIdAsync(int examinationId);
	Task<ExaminationImageDto> GetByIdAsync(int id);
	Task<bool> AddAsync(ExaminationImageDto? examinationImageDto);
	Task<bool> DeleteAsync(int id);
	Task UploadImagesAsync(int examinationId, IEnumerable<IFormFile> images, string webRootPath);
	void DeleteImageFile(string imagePath, string webRootPath);
}