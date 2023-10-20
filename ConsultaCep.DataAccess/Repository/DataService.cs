using ConsultaCep.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.DataAccess.Repository
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InicializaDB()
        {
            _context.Database.Migrate();
        }
    }
}
