using RealEstateAgency.Models;

namespace RealEstateAgency.Filters
{
    public class RealEstateFilter
    {
        public string Address { get; set; }

        public RealEstateType? RealEstateType { get; set; }
    }
}
