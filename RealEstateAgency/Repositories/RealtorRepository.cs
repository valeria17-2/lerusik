using RealEstateAgency.Database;
using RealEstateAgency.Logic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RealEstateAgency.Repositories
{
    public class RealtorRepository
    {
        public static Realtor GetById(int realtorId)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                return context.Realtor.FirstOrDefault(x => x.Id == realtorId);
            }
        }

        public static IEnumerable<Realtor> GetList(string name = null)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return context.Realtor.ToArray()
                    .Where(x => LevenshteinHelper.LevenshteinDistance
                    (x.LastName + " " + x.FirstName + " " + x.Patronymic, name)
                    <= LevenshteinHelper.ApplicationLevenshteinDistance ||
                    (x.LastName + " " + x.FirstName + " " + x.Patronymic).Contains(name))
                    .ToList();
                }

                return context.Realtor.ToList();
            }
        }

        public static void Delete(Realtor realtor)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Entry(realtor).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void Create(Realtor realtor)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Realtor.Add(realtor);
                context.SaveChanges();
            }
        }

        public static void Update(Realtor realtor)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Realtor.Attach(realtor);
                context.Entry(realtor).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
