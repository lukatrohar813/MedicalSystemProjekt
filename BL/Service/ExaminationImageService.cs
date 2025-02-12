using AutoMapper;
using BL.IService;
using BL.Models;
using DAL.IRepository;
using DAL.Model;
using Microsoft.AspNetCore.Http;

namespace BL.Service
{
	public class ExaminationImageService(IUnitOfWork unitOfWork, IMapper mapper) : IExaminationImageService
	{
		public async Task<IEnumerable<ExaminationImageDto>> GetAllAsync()
		{
			var images = await unitOfWork.ExaminationImages.GetAllAsync();
			return mapper.Map<IEnumerable<ExaminationImageDto>>(images);
		}

		public async Task<IEnumerable<ExaminationImageDto>> GetByExaminationIdAsync(int examinationId)
		{
			var images = await unitOfWork.ExaminationImages.GetByExaminationIdAsync(examinationId);
			return mapper.Map<IEnumerable<ExaminationImageDto>>(images);
		}

		public async Task<ExaminationImageDto> GetByIdAsync(int id)
		{
			var image = await unitOfWork.ExaminationImages.GetByIdAsync(id);
			return image == null ? null : mapper.Map<ExaminationImageDto>(image);
		}

		public async Task<bool> AddAsync(ExaminationImageDto? examinationImageDto)
		{
			if (examinationImageDto == null) return false;

			var image = mapper.Map<ExaminationImage>(examinationImageDto);
			await unitOfWork.ExaminationImages.AddAsync(image);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var image = await unitOfWork.ExaminationImages.GetByIdAsync(id);
			if (image == null) return false;

			await unitOfWork.ExaminationImages.DeleteAsync(id);
			await unitOfWork.SaveChangesAsync();
			return true;
		}
		public async Task UploadImagesAsync(int examinationId, IEnumerable<IFormFile> images, string webRootPath)
		{
			if (images == null || !images.Any()) return;

			var uploadsFolder = Path.Combine(webRootPath, "examination-images");
			Directory.CreateDirectory(uploadsFolder);

			foreach (var image in images)
			{
				if (image.Length <= 0) continue;
				var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				await using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await image.CopyToAsync(fileStream);
				}

				var imageDto = new ExaminationImageDto
				{
					ExaminationId = examinationId,
					ImagePath = uniqueFileName,
					UploadDateTime = DateTime.UtcNow
				};

				await AddAsync(imageDto);
			}
		}

		public void DeleteImageFile(string imagePath, string webRootPath)
		{
			var fullPath = Path.Combine(webRootPath, "examination-images", imagePath);
			if (System.IO.File.Exists(fullPath))
			{
				try
				{
					System.IO.File.Delete(fullPath);
				}
				catch (Exception)
				{
				}
			}
		}
	}
}
