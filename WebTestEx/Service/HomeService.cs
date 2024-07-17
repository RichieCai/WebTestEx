using Microsoft.EntityFrameworkCore;
using WebTestEx.Context;
using WebTestEx.Interface;
using WebTestEx.Models.Data;

namespace WebTestEx.Service
{
    public class HomeService : IHomeService
    {
        private readonly dbCustomDbSampleContext _context;
        public HomeService(dbCustomDbSampleContext db)
        {
            _context = db;
        }

        public async Task<List<Student>> Student()
        {
            var vUsers = await _context.Students.ToListAsync();
            return vUsers;
        }
    }
}
