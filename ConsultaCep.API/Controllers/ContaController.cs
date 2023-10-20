using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.DataAccess.Repository;
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
        public ActionResult<IEnumerable<ContaDTO>> GetAll()
        {
            var contas = _contaRepostitory.GetAll();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContaDTO>> FindById(long id)
        {
            var conta = await _contaRepostitory.FindById(id);
            if (conta == null) return NotFound();
            return Ok(conta);
        }

        [HttpPost]
        public async Task<ActionResult<ContaDTO>> Create(ContaDTO dto)
        {
            if (dto == null) return BadRequest();
            var conta = await _contaRepostitory.Create(dto);
            return Ok(conta);
        }

        [HttpPut]
        public async Task<ActionResult<ContaDTO>> Update(ContaDTO dto)
        {
            if (dto == null) return BadRequest();
            var conta = await _contaRepostitory.Update(dto);
            return Ok(conta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _contaRepostitory.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
