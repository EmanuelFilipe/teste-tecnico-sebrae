using ConsultaCep.Web.Models;
using ConsultaCep.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
                {
                    TempData["MSG_SUCCESS"] = "Conta criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Detail(long id)
        {
            var contaModel = await _contaService.FindContaById(id);

            if (contaModel != null) return View(contaModel);

            return NotFound();
        }

        public async Task<IActionResult> Edit(long id)
        {
            var contaModel = await _contaService.FindContaById(id);

            if (contaModel != null) return View(contaModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContaModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contaService.Update(model);

                if (response != null)
                {
                    TempData["MSG_SUCCESS"] = "Conta alterada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["MSG_ERRO"] = "Ocorreu um erro ao realizar a exclusão da conta!";
                return NotFound();
            }

            await _contaService.Delete((long)id); ;
            return RedirectToAction(nameof(Index));
        }
    }
}
