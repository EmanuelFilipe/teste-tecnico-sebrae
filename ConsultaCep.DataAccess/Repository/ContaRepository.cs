using AutoMapper;
using ConsultaCep.DataAccess.Data;
using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.DataAccess.Repository
{
    public class ContaRepository : IContaRepostitory
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ContaRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ContaDTO> GetAll()
        {
            List<Conta> contas =  _context.Contas.AsNoTracking().ToList();
            return _mapper.Map<List<ContaDTO>>(contas);
        }

        public async Task<ContaDTO> FindById(long id)
        {
            var conta = await _context.Contas.FindAsync(id); //.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<ContaDTO>(conta);
        }

        public async Task<ContaDTO> Create(ContaDTO dto)
        {
            Conta conta = _mapper.Map<Conta>(dto);
            _context.Add(conta);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContaDTO>(conta);
        }

        public async Task<ContaDTO> Update(ContaDTO dto)
        {
            Conta conta = _mapper.Map<Conta>(dto);
            _context.Update(conta);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContaDTO>(conta);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var conta = await _context.Contas.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (conta == null) return false;

                _context.Remove(conta);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
