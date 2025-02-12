using BL.IService;
using BL.Models;
using MedicalSystem.ViewModels.MedicalHistory;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Controllers
{
	public class MedicalHistoryController : Controller
	{
		private readonly IMedicalHistoryService _medicalHistoryService;
		private readonly IPatientService _patientService;
		private readonly IIllnessService _illnessService;

		public MedicalHistoryController(
			IMedicalHistoryService medicalHistoryService,
			IPatientService patientService,
			IIllnessService illnessService)
		{
			_medicalHistoryService = medicalHistoryService;
			_patientService = patientService;
			_illnessService = illnessService;
		}

		public async Task<IActionResult> PatientHistory(int id)
		{
			var patient = await _patientService.GetByIdAsync(id);
			if (patient == null) return NotFound();

			var histories = await _medicalHistoryService.GetByPatientIdAsync(id);
			ViewBag.PatientName = $"{patient.FirstName} {patient.LastName}";
			ViewBag.PatientId = id;
			return View(histories);
		}

		public async Task<IActionResult> Create(int patientId)
		{
			var patient = await _patientService.GetByIdAsync(patientId);
			if (patient == null) return NotFound();

			var illnesses = await _illnessService.GetAllAsync();

			var viewModel = new MedicalHistoryCreateViewModel
			{
				PatientId = patientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				StartDate = DateTime.Now,
				AvailableIllnesses = illnesses
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MedicalHistoryCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (viewModel.EndDate.HasValue && viewModel.EndDate.Value < viewModel.StartDate)
					{
						ModelState.AddModelError("EndDate", "End date must be after start date");
						viewModel.AvailableIllnesses = await _illnessService.GetAllAsync();
						return View(viewModel);
					}

					var medicalHistoryDto = new MedicalHistoryDto
					{
						PatientId = viewModel.PatientId,
						IllnessId = viewModel.IllnessId,
						StartDate = viewModel.StartDate,
						EndDate = viewModel.EndDate
					};

					var success = await _medicalHistoryService.AddAsync(medicalHistoryDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "An error occurred while saving the medical history.");
				}
			}

			viewModel.AvailableIllnesses = await _illnessService.GetAllAsync();
			return View(viewModel);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var medicalHistory = await _medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null) return NotFound();

			var patient = await _patientService.GetByIdAsync(medicalHistory.PatientId);
			if (patient == null) return NotFound();

			var illnesses = await _illnessService.GetAllAsync();

			var viewModel = new MedicalHistoryEditViewModel
			{
				Id = medicalHistory.Id,
				PatientId = medicalHistory.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				IllnessId = medicalHistory.IllnessId,
				StartDate = medicalHistory.StartDate,
				EndDate = medicalHistory.EndDate,
				AvailableIllnesses = illnesses
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MedicalHistoryEditViewModel viewModel)
		{
			if (id != viewModel.Id) return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					if (viewModel.EndDate.HasValue && viewModel.EndDate.Value < viewModel.StartDate)
					{
						ModelState.AddModelError("EndDate", "End date must be after start date");
						viewModel.AvailableIllnesses = await _illnessService.GetAllAsync();
						return View(viewModel);
					}

					var medicalHistoryDto = new MedicalHistoryDto
					{
						Id = viewModel.Id,
						PatientId = viewModel.PatientId,
						IllnessId = viewModel.IllnessId,
						StartDate = viewModel.StartDate,
						EndDate = viewModel.EndDate
					};

					var success = await _medicalHistoryService.UpdateAsync(medicalHistoryDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "An error occurred while updating the medical history.");
				}
			}

			viewModel.AvailableIllnesses = await _illnessService.GetAllAsync();
			return View(viewModel);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var medicalHistory = await _medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null) return NotFound();

			var patient = await _patientService.GetByIdAsync(medicalHistory.PatientId);
			if (patient == null) return NotFound();

			var illness = await _illnessService.GetByIdAsync(medicalHistory.IllnessId);

			var viewModel = new MedicalHistoryDeleteViewModel
			{
				Id = medicalHistory.Id,
				PatientId = medicalHistory.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				IllnessName = illness?.Name ?? "Unknown Illness",
				StartDate = medicalHistory.StartDate,
				EndDate = medicalHistory.EndDate
			};

			return View(viewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var medicalHistory = await _medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null) return NotFound();

			var patientId = medicalHistory.PatientId;
			await _medicalHistoryService.DeleteAsync(id);

			return RedirectToAction("Details", "Patient", new { id = patientId });
		}
	}
}