﻿using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class RegionRepository : GenericRepository<Region, DbContextSellCar>, IRegionRepository
    {
        public Region MostAdvertisedRegion()
        {
            using (var context = new DbContextSellCar())
            {
                return context.Region
                    .Include(i => i.Ads)
                    .OrderByDescending(i => i.Ads.Count())
                    .FirstOrDefault();
            }
        }

        public Region LeastAnnouncedRegion()
        {
            using (var context = new DbContextSellCar())
            {
                return context.Region
                    .Include(i => i.Ads)
                    .OrderBy(i => i.Ads.Count())
                    .FirstOrDefault();
            }
        }

        public Region GetByIdWithPosts(int ilId)
        {
            using (var context = new DbContextSellCar())
            {
                return context.Region
                    .Where(i => i.RegionId == ilId)
                    .Include(i => i.Ads)
                    .ThenInclude(i => i.Brand)
                    .FirstOrDefault();
            }
        }

        public List<Region> GetRegion()
        {
            using (var context = new DbContextSellCar())
            {
                return context.Region
                    .Include(i => i.Ads)
                    .OrderBy(i => i.Name)
                    .ToList();

            }
        }
    }
}
