using Microsoft.EntityFrameworkCore;
using WSEA.Data.WSEA;

namespace WSEA.Data
{
    public class WSEAService
    {
        private readonly WSEAContext _context;
        public WSEAService(WSEAContext context)
        {
            _context = context;
        }

        public async Task<List<Realty>> GetRealtiesAsync()
        {
            return await _context.Realties
                 .AsNoTracking()
                 .Include(x => x.RealtyImages)
                 .Include(x => x.RealtyType)
                 .ToListAsync();
        }

        public Task<Request> CreateRequestAsync(Request objRecognition)
        {
            _context.Requests.Add(objRecognition);
            _context.SaveChanges();
            return Task.FromResult(objRecognition);
        }
    }
}
