using Microsoft.EntityFrameworkCore;
using WSEA.Components.Pages;
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

        public async Task<Commerce> CreateCommerceAsync(Commerce commerce)
        {
            _context.Commerces.Add(commerce);
            _context.SaveChanges();
            return await Task.FromResult(commerce);
        }
        public async Task<List<CommerceType>> GetCommerceTypesAsync()
        {
            return await _context.CommerceTypes.ToListAsync();
        }
        public async Task<House> CreateHouseAsync(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
            return await Task.FromResult(house);
        }

        public async Task<List<HouseType>> GetHouseTypesAsync()
        {
            return await _context.HouseTypes.ToListAsync();
        }

        public async Task<List<Canal>> GetCanalsAsync()
        {
            return await _context.Canals.ToListAsync();
        }

        public async Task<List<Water>> GetWaterAsync()
        {
            return await _context.Water.ToListAsync();
        }

        public async Task<Landplot> CreateLandplotAsync(Landplot nLandplot)
        {
            _context.Landplots.Add(nLandplot);
            _context.SaveChanges();
            return await Task.FromResult(nLandplot);
        }
        public async Task<List<LandplotType>> GetLandplotTypesAsync() 
        {
            return await _context.LandplotTypes.ToListAsync();
        }
        public List<Realty> GetFilteredRealtyApartments(FilterModel model)
        {
            IQueryable<Realty> request = _context.Set<Realty>();

            request = _context.Realties
                .AsNoTracking()
                .Include(x => x.Images)
                .Include(x => x.IdFlatRoomNavigation);

            // Rent 
            if (model.Rent != 2)
                request = request.Where(x => x.SellOrRent == (model.Rent == 1) ? true : false);
            // Loggia
            if (model.Loggia != 2)
                request = request.Where(x => x.IdFlatRoomNavigation.Loggia == (model.Loggia == 1) ? true : false);
            // Elevator
            if (model.Elevator != 2)
                request = request.Where(x => x.IdFlatRoomNavigation.Elevator == (model.Elevator == 1) ? true : false);
            // Balcony
            if (model.Balcony != 2)
                request = request.Where(x => x.IdFlatRoomNavigation.Balcony == (model.Balcony == 1) ? true : false);

            // Рынок
            if (model.NewBuild != 2)
                request = request.Where(x => x.IdFlatRoomNavigation.SecOrNew == (model.NewBuild == 1) ? true : false);

            if (!string.IsNullOrWhiteSpace(model.City))
                request = request.Where(x => x.City == model.City);
            if (!string.IsNullOrWhiteSpace(model.District))
                request = request.Where(x => x.District == model.District);
            if (!string.IsNullOrWhiteSpace(model.Street))
                request = request.Where(x => x.Street == model.Street);

            if (model.RoomCount != null)
                request = request.Where(x => x.IdFlatRoomNavigation.RoomCount == model.RoomCount);

            // Floor Count
            // Minimum + Maximum -
            if (model.FlootMinimum != null && model.FlootMaximum == null)
                request = request.Where(x => x.IdFlatRoomNavigation.FloorCount >= model.FlootMinimum);
            // Minimum + Maximum +
            else if (model.FlootMinimum != null && model.FlootMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.FloorCount >= model.FlootMinimum
                && x.IdFlatRoomNavigation.FloorCount <= model.FlootMaximum);
            // Minimum - Maximum +
            else if (model.FlootMinimum == null && model.FlootMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.FloorCount <= model.FlootMaximum);

            // Cost
            // Minimum + Maximum -
            if (model.CostMinimum != null && model.CostMaximum == null)
                request = request.Where(x => x.Cost >= model.CostMinimum);
            // Minimum + Maximum +
            else if (model.CostMinimum != null && model.CostMaximum != null)
                request = request.Where(x => x.Cost >= model.CostMinimum
                && x.Cost <= model.CostMaximum);
            // Minimum - Maximum +
            else if (model.CostMinimum == null && model.CostMaximum != null)
                request = request.Where(x => x.Cost <= model.CostMaximum);

            // Square Object
            // Minimum + Maximum -
            if (model.SquareObjectMinimum != null && model.SquareObjectMaximum == null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareObject >= model.SquareObjectMinimum);
            // Minimum + Maximum +
            else if (model.SquareObjectMinimum != null && model.SquareObjectMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareObject >= model.SquareObjectMinimum
                && x.IdFlatRoomNavigation.SquareObject <= model.SquareObjectMaximum);
            // Minimum - Maximum +
            else if (model.SquareObjectMinimum == null && model.SquareObjectMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareObject <= model.SquareObjectMaximum);

            // Living Square
            // Minimum + Maximum -
            if (model.LivingSquareMinumum != null && model.LivingSquareMaximum == null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareLiving >= model.LivingSquareMinumum);
            // Minimum + Maximum +
            else if (model.LivingSquareMinumum != null && model.LivingSquareMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareLiving >= model.LivingSquareMinumum
                && x.IdFlatRoomNavigation.SquareLiving <= model.LivingSquareMaximum);
            // Minimum - Maximum +
            else if (model.LivingSquareMinumum == null && model.LivingSquareMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareLiving <= model.LivingSquareMaximum);

            // Kitchen Square
            // Minimum + Maximum -
            if (model.KitchenSquareMinimum != null && model.KitchenSquareMaximum == null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareKitchen >= model.KitchenSquareMinimum);
            // Minimum + Maximum +
            else if (model.KitchenSquareMinimum != null && model.KitchenSquareMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareKitchen >= model.KitchenSquareMinimum
                && x.IdFlatRoomNavigation.SquareKitchen <= model.KitchenSquareMaximum);
            // Minimum - Maximum +
            else if (model.KitchenSquareMinimum == null && model.KitchenSquareMaximum != null)
                request = request.Where(x => x.IdFlatRoomNavigation.SquareKitchen <= model.KitchenSquareMaximum);

            if (model.HeatingId != 0)
                request = request.Where(x => x.IdFlatRoomNavigation.IdHeating == model.HeatingId);
            if (model.SanitaryId != 0)
                request = request.Where(x => x.IdFlatRoomNavigation.IdSanitary == model.SanitaryId);
            if (model.MaterialId != 0)
                request = request.Where(x => x.IdFlatRoomNavigation.IdMaterial == model.MaterialId);

            return request.ToList();
        }

        public async Task<List<Operation>> GetOperationsAsync()
        {
            return await _context.Operations.ToListAsync();
        }
        public async Task<List<Realty>> GetRealtyApartments()
        {
            return await _context.Realties
                .AsNoTracking()
                .Where(x => x.IdFlatRoom != null)
                .ToListAsync();
        }
        public async Task<List<Sanitary>> GetSanitaries()
        {
            return await _context.Sanitaries
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<FlatRoom> CreateFlatroomAsync(FlatRoom flatRoom)
        {
            _context.FlatRooms.Add(flatRoom);
            _context.SaveChanges();
            return Task.FromResult(flatRoom);
        }

        public async Task<List<Heating>> GetHeatings()
        {
            return await _context.Heatings
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Material>> GetMaterials()
        {
            return await _context.Materials
                .AsNoTracking()
                .ToListAsync();
        }
        public Task<Image> CreateRealtyImage(Image realtyImage)
        {
            _context.Images.Add(realtyImage);
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
                .Include(x => x.Images)
                .Include(x => x.IdCommerceNavigation)
                .Include(x => x.IdFlatRoomNavigation)
                .Include(x => x.IdFlatRoomNavigation.IdMaterialNavigation)
                .Include(x => x.IdHouseNavigation)
                .Include(x => x.IdLandplotNavigation)
                .Include(x => x.IdLandplotNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Realty>> GetRealtiesAsync()
        {
            return await _context.Realties
                 .AsNoTracking()
                 .Include(x => x.Images)
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
