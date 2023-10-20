using ConsultaCep.Web.Models;
using ConsultaCep.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ConsultaCep.Web.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        public async Task<IActionResult> Index()
        {
            var contas = await _contaService.GetAll();
            return View(contas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContaModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contaService.Create(model);

                if (response != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Update(long id)
        {
            var contaModel = await _contaService.FindContaById(id);

            if (contaModel != null) return View(contaModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContaModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contaService.Update(model);

                if (response != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var contaModel = await _contaService.FindContaById(id);

            if (contaModel != null) return View(contaModel);
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(ContaModel model)
        {
            var response = await _contaService.Delete(model.Id);

            if (response) return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
