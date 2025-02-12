using BL.IService;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalSystem.ViewModels.Illness;

namespace MedicalSystem.Controllers
{
	public class IllnessController(IIllnessService illnessService) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var illnesses = await illnessService.GetAllAsync();
			return View(illnesses);
		}

		public IActionResult Create()
		{
			return View(new IllnessCreateViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IllnessCreateViewModel viewModel)
		{
			if (!ModelState.IsValid) return View(viewModel);

			var illnessDto = new IllnessDto
			{
				Name = viewModel.Name,
				Description = viewModel.Description
			};

			var success = await illnessService.AddAsync(illnessDto);
			if (success)
			{
				return RedirectToAction(nameof(Index));
			}

			ModelState.AddModelError("", "Failed to create illness record");
			return View(viewModel);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var illness = await illnessService.GetByIdAsync(id);
			if (illness == null) return NotFound();

			var viewModel = new IllnessEditViewModel
			{
				Id = illness.Id,
				Name = illness.Name,
				Description = illness.Description
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, IllnessEditViewModel viewModel)
		{
			if (id != viewModel.Id) return NotFound();
			if (!ModelState.IsValid) return View(viewModel);

			var illnessDto = new IllnessDto
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				Description = viewModel.Description
			};

			var success = await illnessService.UpdateAsync(illnessDto);
			if (success)
			{
				return RedirectToAction(nameof(Index));
			}

			ModelState.AddModelError("", "Failed to update illness record");
			return View(viewModel);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var illness = await illnessService.GetByIdAsync(id);
			if (illness == null) return NotFound();

			return View(illness);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await illnessService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}