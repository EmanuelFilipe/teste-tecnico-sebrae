using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCep.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private IContaRepostitory _contaRepostitory;

        public ContaController(IContaRepostitory contaRepostitory)
        {
            _contaRepostitory = contaRepostitory ?? throw new ArgumentNullException(nameof(contaRepostitory));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Conta>> GetAll()
        {
            var contas = _contaRepostitory.GetAll();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        public ActionResult FindById(long id)
        {
            var conta = _contaRepostitory.FindById(id);
            if (conta == null) return NotFound();
            return Ok(conta);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Conta conta)
        {
            if (conta == null) return BadRequest();
            
            var result = _contaRepostitory.Create(conta);

            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Conta conta)
        {
            if (conta == null) return BadRequest();
            var result = _contaRepostitory.Update(conta);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var status = _contaRepostitory.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
