using BL.IService;
using BL.Models;
using MedicalSystem.ViewModels.MedicalHistory;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Controllers
{
	public class MedicalHistoryController(
		IMedicalHistoryService medicalHistoryService,
		IPatientService patientService)
		: Controller
	{
		// GET: MedicalHistory/Patient/5
		public async Task<IActionResult> PatientHistory(int id)
		{
			var patient = await patientService.GetByIdAsync(id);
			if (patient == null)
			{
				return NotFound();
			}

			var histories = await medicalHistoryService.GetByPatientIdAsync(id);
			ViewBag.PatientName = $"{patient.FirstName} {patient.LastName}";
			ViewBag.PatientId = id;
			return View(histories);
		}

		// GET: MedicalHistory/Create
		public async Task<IActionResult> Create(int patientId)
		{
			var patient = await patientService.GetByIdAsync(patientId);
			if (patient == null)
			{
				return NotFound();
			}

			var viewModel = new MedicalHistoryCreateViewModel
			{
				PatientId = patientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				StartDate = DateTime.Now
			};

			return View(viewModel);
		}


		// POST: MedicalHistory/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MedicalHistoryCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Validate dates
					if (viewModel.EndDate.HasValue && viewModel.EndDate.Value < viewModel.StartDate)
					{
						ModelState.AddModelError("EndDate", "End date must be after start date");
						return View(viewModel);
					}

					var medicalHistoryDto = new MedicalHistoryDto
					{
						PatientId = viewModel.PatientId,
						DiseaseName = viewModel.DiseaseName,
						StartDate = viewModel.StartDate,
						EndDate = viewModel.EndDate
					};

					var success = await medicalHistoryService.AddAsync(medicalHistoryDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("",
						"An error occurred while saving the medical history. Please try again.");
				}
			}

			return View(viewModel);
		}

		// GET: MedicalHistory/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var medicalHistory = await medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null)
			{
				return NotFound();
			}

			var patient = await patientService.GetByIdAsync(medicalHistory.PatientId);
			if (patient == null)
			{
				return NotFound();
			}

			var viewModel = new MedicalHistoryEditViewModel
			{
				Id = medicalHistory.Id,
				PatientId = medicalHistory.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				DiseaseName = medicalHistory.DiseaseName,
				StartDate = medicalHistory.StartDate,
				EndDate = medicalHistory.EndDate
			};

			return View(viewModel);
		}

		// POST: MedicalHistory/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MedicalHistoryEditViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					// Validate dates
					if (viewModel.EndDate.HasValue && viewModel.EndDate.Value < viewModel.StartDate)
					{
						ModelState.AddModelError("EndDate", "End date must be after start date");
						return View(viewModel);
					}

					var medicalHistoryDto = new MedicalHistoryDto
					{
						Id = viewModel.Id,
						PatientId = viewModel.PatientId,
						DiseaseName = viewModel.DiseaseName,
						StartDate = viewModel.StartDate,
						EndDate = viewModel.EndDate
					};

					var success = await medicalHistoryService.UpdateAsync(medicalHistoryDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("",
						"An error occurred while updating the medical history. Please try again.");
					// Log the exception here
				}
			}

			return View(viewModel);
		}

		// GET: MedicalHistory/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var medicalHistory = await medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null)
			{
				return NotFound();
			}

			var patient = await patientService.GetByIdAsync(medicalHistory.PatientId);
			if (patient == null)
			{
				return NotFound();
			}

			var viewModel = new MedicalHistoryDeleteViewModel
			{
				Id = medicalHistory.Id,
				PatientId = medicalHistory.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				DiseaseName = medicalHistory.DiseaseName,
				StartDate = medicalHistory.StartDate,
				EndDate = medicalHistory.EndDate
			};

			return View(viewModel);
		}

		// POST: MedicalHistory/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var medicalHistory = await medicalHistoryService.GetByIdAsync(id);
			if (medicalHistory == null)
			{
				return NotFound();
			}

			var patientId = medicalHistory.PatientId;
			await medicalHistoryService.DeleteAsync(id);

			return RedirectToAction("Details", "Patient", new { id = patientId });
		}
	}
}
