//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Esoft.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostDetails
    {
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public int BuildingCost { get; set; }
        public int ValueAdded { get; set; }
    
        public virtual Apartment Apartment { get; set; }
    }
}
