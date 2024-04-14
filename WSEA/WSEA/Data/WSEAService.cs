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

        public Task<RealtyImage> CreateRealtyImage(RealtyImage realtyImage)
        {
            _context.RealtyImages.Add(realtyImage);
            _context.SaveChanges();
            return Task.FromResult(realtyImage);
        } 

        public Task<Realty> CreateRealtyAsync(Realty realty)
        {
            _context.Realties.Add(realty);
            _context.SaveChanges();
            return Task.FromResult(realty);
        }

        public async Task<Realty?> GetRealtyAsync(int id_realty)
        {
            return await _context.Realties
                .AsNoTracking()
                .Where(x => x.IdRealty == id_realty)
                .Include(x => x.RealtyImages)
                .Include(x => x.RealtyType)
                .FirstOrDefaultAsync();
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
