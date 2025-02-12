using AutoMapper;
using BL.IService;
using BL.Models;
using MedicalSystem.Models.Patient;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class PatientController(
		IPatientService patientService,
		IMedicalHistoryService medicalHistoryService,
		IExaminationService examinationService,
		IPrescriptionService prescriptionService,
		IMapper mapper,
		IExportService exportService)
		: Controller
	{
		private readonly IMapper _mapper = mapper;

		// GET: Patient
		public async Task<IActionResult> Index(string searchString)
		{
			try
			{
				var patients = await patientService.GetAllAsync();

				if (!string.IsNullOrWhiteSpace(searchString))
				{
					patients = patients.Where(p =>
						p.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
						p.OIB.Contains(searchString));
				}

				ViewData["CurrentFilter"] = searchString;
				return View(patients);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		// GET: Patient/Details/5
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var patient = await patientService.GetByIdAsync(id);
				if (patient == null)
				{
					return NotFound();
				}

				var viewModel = new PatientDetailsViewModel
				{
					Patient = patient,
					MedicalHistories = await medicalHistoryService.GetByPatientIdAsync(id),
					Examinations = await examinationService.GetByPatientIdAsync(id),
					Prescriptions = await prescriptionService.GetByPatientIdAsync(id)
				};

				return View(viewModel);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		// GET: Patient/Create
		public IActionResult Create()
		{
			return View(new PatientCreateViewModel
			{
				DateOfBirth = DateTime.Today
			});
		}

		// POST: Patient/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(PatientCreateViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			try
			{
				var patientDto = new PatientDto
				{
					FirstName = viewModel.FirstName,
					DateOfBirth = viewModel.DateOfBirth,
					Gender = viewModel.Gender,
					LastName = viewModel.LastName,
					OIB = viewModel.OIB,
					PatientNumber = viewModel.PatientNumber
				};
				var success = await patientService.AddAsync(patientDto);

				if (success)
				{
					return RedirectToAction(nameof(Index));
				}

				ModelState.AddModelError("", "Failed to create patient. Please try again.");
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "An error occurred while creating the patient.");
			}

			return View(viewModel);
		}

		// GET: Patient/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var patient = await patientService.GetByIdAsync(id);
				if (patient == null)
				{
					return NotFound();
				}

				var viewModel = new PatientEditViewModel()
				{

					Id = patient.Id,
					FirstName = patient.FirstName,
					LastName = patient.LastName,
					OIB = patient.OIB,
					DateOfBirth = patient.DateOfBirth,
					Gender = patient.Gender,
					PatientNumber = patient.PatientNumber
				};
				return View(viewModel);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		// POST: Patient/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, PatientEditViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			try
			{
				var patientDto = new PatientDto
				{
					Id = viewModel.Id,
					FirstName = viewModel.FirstName,
					LastName = viewModel.LastName,
					OIB = viewModel.OIB,
					DateOfBirth = viewModel.DateOfBirth,
					Gender = viewModel.Gender,
					PatientNumber = viewModel.PatientNumber
				};
				var success = await patientService.UpdateAsync(patientDto);

				if (success)
				{
					return RedirectToAction(nameof(Details), new { id = viewModel.Id });
				}

				ModelState.AddModelError("", "Failed to update patient. Please try again.");
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "An error occurred while updating the patient.");
			}

			return View(viewModel);
		}
		// GET: Patient/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var patient = await patientService.GetByIdAsync(id);
				if (patient == null)
				{
					return NotFound();
				}

				var viewModel = new PatientDetailsViewModel
				{
					Patient = patient,
					MedicalHistories = await medicalHistoryService.GetByPatientIdAsync(id),
					Examinations = await examinationService.GetByPatientIdAsync(id),
					Prescriptions = await prescriptionService.GetByPatientIdAsync(id)
				};

				return View(viewModel);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}
		// POST: Patient/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				var success = await patientService.DeleteAsync(id);
				if (success)
				{
					return RedirectToAction(nameof(Index));
				}

				return NotFound();
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		// GET: Patient/ExportToCsv
		public async Task<IActionResult> ExportToCsv()
		{
			try
			{
				var patients = await patientService.GetAllAsync();
				var fileBytes = exportService.ExportPatientsToCsv(patients);
				var fileName = exportService.GenerateFileName("patients");
				return File(fileBytes, "text/csv", fileName);
			}
			catch (Exception)
			{
				TempData["Error"] = "Failed to export patient data.";
				return RedirectToAction(nameof(Index));
			}
		}
		// GET: Patient/ExportDetailedCsv/88
		public async Task<IActionResult> ExportDetailedCsv(int id)
		{
			try
			{
				byte[] fileBytes = await exportService.ExportDetailedPatientToCsvAsync(id);
				string fileName = $"patient_{id}_{DateTime.Now:yyyyMMdd}.csv";
				return File(fileBytes, "text/csv", fileName);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
			catch (Exception)
			{
				TempData["Error"] = "Failed to export patient data.";
				return RedirectToAction(nameof(Details), new { id });
			}
		}
	}
}