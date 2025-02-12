using BL.IService;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.ViewModels.Medicine;

namespace MedicalSystem.Controllers
{
	public class MedicineController(IMedicineService medicineService) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var medicines = await medicineService.GetAllAsync();
			return View(medicines);
		}

		public IActionResult Create()
		{
			return View(new MedicineCreateViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MedicineCreateViewModel viewModel)
		{
			if (!ModelState.IsValid) return View(viewModel);

			var medicineDto = new MedicineDto
			{
				Name = viewModel.Name,
				Description = viewModel.Description
			};

			var success = await medicineService.AddAsync(medicineDto);
			if (success)
			{
				return RedirectToAction(nameof(Index));
			}

			ModelState.AddModelError("", "Failed to create medicine record");
			return View(viewModel);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var medicine = await medicineService.GetByIdAsync(id);
			if (medicine == null) return NotFound();

			var viewModel = new MedicineEditViewModel
			{
				Id = medicine.Id,
				Name = medicine.Name,
				Description = medicine.Description
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MedicineEditViewModel viewModel)
		{
			if (id != viewModel.Id) return NotFound();
			if (!ModelState.IsValid) return View(viewModel);

			var medicineDto = new MedicineDto
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				Description = viewModel.Description
			};

			var success = await medicineService.UpdateAsync(medicineDto);
			if (success)
			{
				return RedirectToAction(nameof(Index));
			}

			ModelState.AddModelError("", "Failed to update medicine record");
			return View(viewModel);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var medicine = await medicineService.GetByIdAsync(id);
			if (medicine == null) return NotFound();

			return View(medicine);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await medicineService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}