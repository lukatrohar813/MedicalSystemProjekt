using MedicalSystem.ViewModels.Prescription;

namespace MedicalSystem.Controllers
{
	using BL.IService;
	using BL.Models;
	using Microsoft.AspNetCore.Mvc;

	namespace WebApp.Controllers
	{
		public class PrescriptionController(
			IPrescriptionService prescriptionService,
			IPatientService patientService)
			: Controller
		{
			// GET: Prescription/Patient/5
			public async Task<IActionResult> PatientPrescriptions(int id)
			{
				var patient = await patientService.GetByIdAsync(id);
				if (patient == null)
				{
					return NotFound();
				}

				var prescriptions = await prescriptionService.GetByPatientIdAsync(id);
				ViewBag.PatientName = $"{patient.FirstName} {patient.LastName}";
				ViewBag.PatientId = id;
				return View(prescriptions);
			}

			// GET: Prescription/Create
			public async Task<IActionResult> Create(int patientId)
			{
				var patient = await patientService.GetByIdAsync(patientId);
				if (patient == null)
				{
					return NotFound();
				}

				var viewModel = new PrescriptionCreateViewModel
				{
					PatientId = patientId,
					PatientName = $"{patient.FirstName} {patient.LastName}",
					PrescriptionDate = DateTime.Now
				};

				return View(viewModel);
			}

			// POST: Prescription/Create
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Create(PrescriptionCreateViewModel viewModel)
			{
				if (ModelState.IsValid)
				{
					try
					{
						var prescriptionDto = new PrescriptionDto
						{
							PatientId = viewModel.PatientId,
							MedicineName = viewModel.MedicineName,
							Dosage = viewModel.Dosage,
							PrescriptionDate = viewModel.PrescriptionDate,
							Instructions = viewModel.Instructions
						};

						var success = await prescriptionService.AddAsync(prescriptionDto);
						if (success)
						{
							return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
						}
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("",
							"An error occurred while saving the prescription. Please try again.");
						// Log the exception here
					}
				}

				// If we got this far, something failed; redisplay form
				var patient = await patientService.GetByIdAsync(viewModel.PatientId);
				viewModel.PatientName = $"{patient.FirstName} {patient.LastName}";
				return View(viewModel);
			}

			// GET: Prescription/Edit/5
			public async Task<IActionResult> Edit(int id)
			{
				var prescription = await prescriptionService.GetByIdAsync(id);
				if (prescription == null)
				{
					return NotFound();
				}

				var patient = await patientService.GetByIdAsync(prescription.PatientId);

				var viewModel = new PrescriptionEditViewModel
				{
					Id = prescription.Id,
					PatientId = prescription.PatientId,
					PatientName = $"{patient.FirstName} {patient.LastName}",
					MedicineName = prescription.MedicineName,
					Dosage = prescription.Dosage,
					Instructions = prescription.Instructions
				};

				return View(viewModel);
			}

			// POST: Prescription/Edit/5
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Edit(int id, PrescriptionEditViewModel viewModel)
			{
				if (id != viewModel.Id)
				{
					return NotFound();
				}

				if (ModelState.IsValid)
				{
					try
					{
						var prescriptionDto = new PrescriptionDto
						{
							Id = viewModel.Id,
							PatientId = viewModel.PatientId,
							MedicineName = viewModel.MedicineName,
							Dosage = viewModel.Dosage,
							PrescriptionDate = viewModel.PrescriptionDate,
							Instructions = viewModel.Instructions
						};

						var success = await prescriptionService.UpdateAsync(prescriptionDto);
						if (success)
						{
							return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
						}
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("",
							"An error occurred while updating the prescription. Please try again.");
						// Log the exception here
					}
				}

				// If we got this far, something failed; redisplay form
				var patient = await patientService.GetByIdAsync(viewModel.PatientId);
				viewModel.PatientName = $"{patient.FirstName} {patient.LastName}";
				return View(viewModel);
			}




			// GET: Prescription/Details/5
			public async Task<IActionResult> Details(int id)
			{
				var prescription = await prescriptionService.GetByIdAsync(id);
				if (prescription == null)
				{
					return NotFound();
				}

				var patient = await patientService.GetByIdAsync(prescription.PatientId);

				var viewModel = new PrescriptionDetailsViewModel
				{
					Id = prescription.Id,
					PatientId = prescription.PatientId,
					PatientName = $"{patient.FirstName} {patient.LastName}",
					MedicineName = prescription.MedicineName,
					Dosage = prescription.Dosage,
					PrescriptionDate = prescription.PrescriptionDate,
					Instructions = prescription.Instructions
				};

				return View(viewModel);
			}

			// GET: Prescription/Delete/5
			public async Task<IActionResult> Delete(int id)
			{
				var prescription = await prescriptionService.GetByIdAsync(id);
				if (prescription == null)
				{
					return NotFound();
				}

				var patient = await patientService.GetByIdAsync(prescription.PatientId);
				if (patient == null)
				{
					return NotFound();
				}

				var viewModel = new PrescriptionDetailsViewModel
				{
					Id = prescription.Id,
					PatientId = prescription.PatientId,
					PatientName = $"{patient.FirstName} {patient.LastName}",
					MedicineName = prescription.MedicineName,
					Dosage = prescription.Dosage,
					PrescriptionDate = prescription.PrescriptionDate,
					Instructions = prescription.Instructions
				};

				return View(viewModel);
			}

			// POST: Prescription/Delete/5
			[HttpPost, ActionName("Delete")]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> DeleteConfirmed(int id)
			{
				try
				{
					var prescription = await prescriptionService.GetByIdAsync(id);
					if (prescription == null)
					{
						return NotFound();
					}

					var patientId = prescription.PatientId;
					var success = await prescriptionService.DeleteAsync(id);

					if (success)
					{
						TempData["SuccessMessage"] = "Prescription was successfully deleted.";
						return RedirectToAction("Details", "Patient", new { id = patientId });
					}
					else
					{
						TempData["ErrorMessage"] = "Failed to delete the prescription.";
						return RedirectToAction("Details", new { id });
					}
				}
				catch (Exception ex)
				{
					// Log the error
					TempData["ErrorMessage"] = "An error occurred while deleting the prescription.";
					return RedirectToAction("Details", new { id });
				}
			}
		}
	}
}
