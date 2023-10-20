using ConsultaCep.DataAccess.Data;
using ConsultaCep.Models;

namespace ConsultaCep.DataAccess.Repository
{
    public class ContaRepository : IContaRepostitory
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Conta> GetAll()
        {
            return _context.Contas.ToList();
        }

        public Conta FindById(long id)
        {
            return _context.Contas.Find(id);
        }

        public Conta Create(Conta conta)
        {
            _context.Add(conta);
            _context.SaveChanges();

            return conta;
        }

        public Conta Update(Conta conta)
        {
            _context.Update(conta);
            _context.SaveChanges();

            return conta;
        }

        public bool Delete(long id)
        {
            try
            {
                var conta = FindById(id);

                if (conta == null) return false;

                _context.Remove(conta);
                _context.SaveChanges();

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
