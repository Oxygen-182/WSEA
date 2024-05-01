﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Realty>> GetFilteredRealtyApartments(FilterModel model)
        {
            IQueryable<Realty> request = _context.Set<Realty>();

            request = _context.Realties
                .AsNoTracking()
                .Include(x => x.Images)
                .Include(x => x.IdFlatRoomNavigation);
                //.Where(x => x.SellOrRent == model.Rent
                //&& x.IdFlatRoomNavigation.Elevator == model.Elevator
                //&& x.IdFlatRoomNavigation.Balcony == model.Balcony
                //&& x.IdFlatRoomNavigation.Loggia == model.Loggia);

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

            //if (model.HeatingId != -1)
            //    request = request.Where(x => x.IdFlatRoomNavigation.IdHeating == model.HeatingId);
            //if (model.SanitaryId != -1)
            //    request = request.Where(x => x.IdFlatRoomNavigation.IdSanitary == model.SanitaryId);
            //if (model.MaterialId != -1)
            //    request = request.Where(x => x.IdFlatRoomNavigation.IdMaterial == model.MaterialId);

            return await request.ToListAsync();
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
