//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealEstateAgency.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class RealEstate
    {
        public int Id { get; set; }
        public string Discriminator { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> RoomsQuantity { get; set; }
        public Nullable<decimal> Square { get; set; }
        public Nullable<int> FloorsQuantity { get; set; }
    }
}
