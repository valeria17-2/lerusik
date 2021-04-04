using RealEstateAgency.Database;
using RealEstateAgency.Logic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RealEstateAgency.Repositories
{
    public static class ClientRepository
    {
        public static Client GetById(int clientId)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                return context.Client.FirstOrDefault(x => x.Id == clientId);
            }
        }

        public static IEnumerable<Client> GetList(string name = null)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return context.Client.ToArray()
                    .Where(x => LevenshteinHelper.LevenshteinDistance
                    (x.LastName + " " + x.FirstName + " " + x.Patronymic, name)
                    <= LevenshteinHelper.ApplicationLevenshteinDistance ||
                    (x.LastName + " " + x.FirstName + " " + x.Patronymic).Contains(name))
                    .ToList();
                }
                
                return context.Client.ToList();
            }
        }

        public static void Delete(Client client)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void Create(Client client)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Client.Add(client);
                context.SaveChanges();
            }
        }

        public static void Update(Client client)
        {
            using (AgencyDbEntities context = new AgencyDbEntities())
            {
                context.Client.Attach(client);
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
