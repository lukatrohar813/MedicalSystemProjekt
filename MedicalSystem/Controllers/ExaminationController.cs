using BL.IService;
using BL.Models;
using MedicalSystem.ViewModels.Examination;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Controllers
{
	public class ExaminationController(
		IExaminationService examinationService,
		IExaminationImageService imageService,
		IPatientService patientService,
		IWebHostEnvironment webHostEnvironment)
		: Controller
	{
		// GET: Examination
		public async Task<IActionResult> Index()
		{
			var examinations = await examinationService.GetAllAsync();
			return View(examinations);
		}

		// GET: Examination/Patient/{id}
		public async Task<IActionResult> PatientExaminations(int id)
		{
			var patient = await patientService.GetByIdAsync(id);
			if (patient == null) return NotFound();

			var examinations = await examinationService.GetByPatientIdAsync(id);
			ViewBag.PatientName = $"{patient.FirstName} {patient.LastName}";
			ViewBag.PatientId = id;

			return View(examinations);
		}

		// GET: Examination/Create/{patientId}
		public async Task<IActionResult> Create(int patientId)
		{
			var patient = await patientService.GetByIdAsync(patientId);
			if (patient == null) return NotFound();

			var viewModel = new ExaminationCreateViewModel
			{
				PatientId = patientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				ExaminationDateTime = DateTime.Now
			};

			return View(viewModel);
		}

		// POST: Examination/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExaminationCreateViewModel viewModel)
		{
			if (!ModelState.IsValid) return View(viewModel);

			try
			{
				var examinationDto = new ExaminationDto
				{
					PatientId = viewModel.PatientId,
					ExaminationType = viewModel.ExaminationType,
					Notes = viewModel.Notes,
					ExaminationDateTime = viewModel.ExaminationDateTime
				};

				var success = await examinationService.AddAsync(examinationDto);

				if (success && examinationDto.Id > 0)
				{
					await imageService.UploadImagesAsync(
						examinationDto.Id,
						viewModel.Images,
						webHostEnvironment.WebRootPath);

					return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "An error occurred while saving the examination. Please try again.");
			}

			return View(viewModel);
		}

		// GET: Examination/Details/{id}
		public async Task<IActionResult> Details(int id)
		{
			var examination = await examinationService.GetByIdAsync(id);
			if (examination == null) return NotFound();

			var patient = await patientService.GetByIdAsync(examination.PatientId);
			var images = await imageService.GetByExaminationIdAsync(id);

			var viewModel = new ExaminationDetailsViewModel
			{
				Examination = examination,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				Images = images.ToList()
			};

			return View(viewModel);
		}

		// POST: Examination/AddImages/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddImages(int id, List<IFormFile> images)
		{
			var examination = await examinationService.GetByIdAsync(id);
			if (examination == null) return NotFound();

			await imageService.UploadImagesAsync(id, images, webHostEnvironment.WebRootPath);
			return RedirectToAction(nameof(Details), new { id });
		}

		// POST: Examination/DeleteImage/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImage(int id)
		{
			var image = await imageService.GetByIdAsync(id);
			if (image == null) return NotFound();

			imageService.DeleteImageFile(image.ImagePath, webHostEnvironment.WebRootPath);
			await imageService.DeleteAsync(id);

			return RedirectToAction(nameof(Details), new { id = image.ExaminationId });
		}

		// GET: Examination/Edit/{id}
		public async Task<IActionResult> Edit(int id)
		{
			var examination = await examinationService.GetByIdAsync(id);
			if (examination == null) return NotFound();

			var patient = await patientService.GetByIdAsync(examination.PatientId);
			var images = await imageService.GetByExaminationIdAsync(id);

			var viewModel = new ExaminationEditViewModel
			{
				Id = examination.Id,
				PatientId = examination.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				ExaminationType = examination.ExaminationType,
				Notes = examination.Notes,
				ExistingImages = images.ToList(),
				ExaminationDateTime = examination.ExaminationDateTime
			};

			return View(viewModel);
		}

		// POST: Examination/Edit/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ExaminationEditViewModel viewModel)
		{
			if (id != viewModel.Id) return NotFound();
			if (!ModelState.IsValid) return View(viewModel);

			try
			{
				var examinationDto = new ExaminationDto
				{
					Id = viewModel.Id,
					PatientId = viewModel.PatientId,
					ExaminationType = viewModel.ExaminationType,
					Notes = viewModel.Notes,
					ExaminationDateTime = viewModel.ExaminationDateTime
				};

				var success = await examinationService.UpdateAsync(examinationDto);
				if (!success)
				{
					ModelState.AddModelError("", "Failed to update examination");
					return View(viewModel);
				}

				if (viewModel.Images != null && viewModel.Images.Any())
				{
					await imageService.UploadImagesAsync(viewModel.Id, viewModel.Images, webHostEnvironment.WebRootPath);
				}

				return RedirectToAction(nameof(Details), new { id });
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "An error occurred while updating the examination.");
			}

			return View(viewModel);
		}

		// GET: Examination/Delete/{id}
		public async Task<IActionResult> Delete(int id)
		{
			var examination = await examinationService.GetByIdAsync(id);
			if (examination == null) return NotFound();

			var patient = await patientService.GetByIdAsync(examination.PatientId);
			var viewModel = new ExaminationDeleteViewModel
			{
				Id = examination.Id,
				ExaminationType = examination.ExaminationType,
				ExaminationDateTime = examination.ExaminationDateTime,
				PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown"
			};

			return View(viewModel);
		}

		// POST: Examination/Delete/{id}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var examination = await examinationService.GetByIdAsync(id);
			if (examination == null) return NotFound();

			var images = await imageService.GetByExaminationIdAsync(id);
			foreach (var image in images)
			{
				imageService.DeleteImageFile(image.ImagePath, webHostEnvironment.WebRootPath);
				await imageService.DeleteAsync(image.Id);
			}

			await examinationService.DeleteAsync(id);
			return RedirectToAction("Details", "Patient", new { id = examination.PatientId });
		}
	}
}