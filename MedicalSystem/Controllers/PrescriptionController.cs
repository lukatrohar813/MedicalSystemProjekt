using BL.IService;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.ViewModels.Prescription;

namespace MedicalSystem.Controllers
{
	public class PrescriptionController : Controller
	{
		private readonly IPrescriptionService _prescriptionService;
		private readonly IPatientService _patientService;
		private readonly IMedicineService _medicineService;

		public PrescriptionController(
			IPrescriptionService prescriptionService,
			IPatientService patientService,
			IMedicineService medicineService)
		{
			_prescriptionService = prescriptionService;
			_patientService = patientService;
			_medicineService = medicineService;
		}

		public async Task<IActionResult> PatientPrescriptions(int id)
		{
			var patient = await _patientService.GetByIdAsync(id);
			if (patient == null) return NotFound();

			var prescriptions = await _prescriptionService.GetByPatientIdAsync(id);
			ViewBag.PatientName = $"{patient.FirstName} {patient.LastName}";
			ViewBag.PatientId = id;
			return View(prescriptions);
		}

		public async Task<IActionResult> Create(int patientId)
		{
			var patient = await _patientService.GetByIdAsync(patientId);
			if (patient == null) return NotFound();

			var medicines = await _medicineService.GetAllAsync();

			var viewModel = new PrescriptionCreateViewModel
			{
				PatientId = patientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				PrescriptionDate = DateTime.Now,
				AvailableMedicines = medicines
			};

			return View(viewModel);
		}

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
						MedicineId = viewModel.MedicineId,
						Dosage = viewModel.Dosage,
						PrescriptionDate = viewModel.PrescriptionDate,
						Instructions = viewModel.Instructions
					};

					var success = await _prescriptionService.AddAsync(prescriptionDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "An error occurred while saving the prescription.");
				}
			}

			viewModel.AvailableMedicines = await _medicineService.GetAllAsync();
			return View(viewModel);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var prescription = await _prescriptionService.GetByIdAsync(id);
			if (prescription == null) return NotFound();

			var patient = await _patientService.GetByIdAsync(prescription.PatientId);
			if (patient == null) return NotFound();

			var medicines = await _medicineService.GetAllAsync();

			var viewModel = new PrescriptionEditViewModel
			{
				Id = prescription.Id,
				PatientId = prescription.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				MedicineId = prescription.MedicineId,
				Dosage = prescription.Dosage,
				PrescriptionDate = prescription.PrescriptionDate,
				Instructions = prescription.Instructions,
				AvailableMedicines = medicines
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, PrescriptionEditViewModel viewModel)
		{
			if (id != viewModel.Id) return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					var prescriptionDto = new PrescriptionDto
					{
						Id = viewModel.Id,
						PatientId = viewModel.PatientId,
						MedicineId = viewModel.MedicineId,
						Dosage = viewModel.Dosage,
						PrescriptionDate = viewModel.PrescriptionDate,
						Instructions = viewModel.Instructions
					};

					var success = await _prescriptionService.UpdateAsync(prescriptionDto);
					if (success)
					{
						return RedirectToAction("Details", "Patient", new { id = viewModel.PatientId });
					}
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "An error occurred while updating the prescription.");
				}
			}

			viewModel.AvailableMedicines = await _medicineService.GetAllAsync();
			return View(viewModel);
		}

		public async Task<IActionResult> Details(int id)
		{
			var prescription = await _prescriptionService.GetByIdAsync(id);
			if (prescription == null) return NotFound();

			var patient = await _patientService.GetByIdAsync(prescription.PatientId);
			if (patient == null) return NotFound();

			var medicine = await _medicineService.GetByIdAsync(prescription.MedicineId);

			var viewModel = new PrescriptionDetailsViewModel
			{
				Id = prescription.Id,
				PatientId = prescription.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				MedicineName = medicine?.Name ?? "Unknown Medicine",
				Dosage = prescription.Dosage,
				PrescriptionDate = prescription.PrescriptionDate,
				Instructions = prescription.Instructions
			};

			return View(viewModel);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var prescription = await _prescriptionService.GetByIdAsync(id);
			if (prescription == null) return NotFound();

			var patient = await _patientService.GetByIdAsync(prescription.PatientId);
			if (patient == null) return NotFound();

			var medicine = await _medicineService.GetByIdAsync(prescription.MedicineId);

			var viewModel = new PrescriptionDetailsViewModel
			{
				Id = prescription.Id,
				PatientId = prescription.PatientId,
				PatientName = $"{patient.FirstName} {patient.LastName}",
				MedicineName = medicine?.Name ?? "Unknown Medicine",
				Dosage = prescription.Dosage,
				PrescriptionDate = prescription.PrescriptionDate,
				Instructions = prescription.Instructions
			};

			return View(viewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var prescription = await _prescriptionService.GetByIdAsync(id);
			if (prescription == null) return NotFound();

			var patientId = prescription.PatientId;
			await _prescriptionService.DeleteAsync(id);

			return RedirectToAction("Details", "Patient", new { id = patientId });
		}
	}
}