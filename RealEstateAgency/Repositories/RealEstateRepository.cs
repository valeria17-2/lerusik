using RealEstateAgency.Database;
using RealEstateAgency.Filters;
using RealEstateAgency.Logic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RealEstateAgency.Repositories
{
    public static class RealEstateRepository
    {
        public static RealEstate GetById(int realtyId)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                return context.RealEstate.FirstOrDefault(x => x.Id == realtyId);
            }
        }

        public static IEnumerable<RealEstate> GetList(RealEstateFilter filter = null)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                if (filter == null)
                {
                    return context.RealEstate.ToList();
                }

                IQueryable<RealEstate> realtyQuery = context.RealEstate;

                if (filter.RealEstateType.HasValue)
                {
                    realtyQuery = realtyQuery.Where(x => x.Discriminator == filter.RealEstateType.ToString());
                }

                if (!string.IsNullOrWhiteSpace(filter.Address))
                {
                    return realtyQuery.ToArray().Where(x =>
                       LevenshteinHelper.LevenshteinDistance($"{x.City} {x.Street} {x.HouseNumber} {x.FlatNumber}", filter.Address)
                           <= LevenshteinHelper.ApplicationLevenshteinDistance ||
                        LevenshteinHelper.LevenshteinDistance(x.City + " " + x.Street, filter.Address)
                        <= LevenshteinHelper.ApplicationLevenshteinDistance ||
                        LevenshteinHelper.LevenshteinDistance(x.HouseNumber + " " + x.FlatNumber, filter.Address)
                        <= LevenshteinHelper.ApplicationLevenshteinMinDistance);
                }

                return realtyQuery.ToList();
            }
        }

        public static void Delete(RealEstate realEstate)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Entry(realEstate).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void Create(RealEstate realEstate)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.RealEstate.Add(realEstate);
                context.SaveChanges();
            }
        }

        public static void Update(RealEstate realEstate)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.RealEstate.Attach(realEstate);
                context.Entry(realEstate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
