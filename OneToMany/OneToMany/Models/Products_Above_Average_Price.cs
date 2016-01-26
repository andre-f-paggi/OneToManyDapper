using System;
using System.Collections.Generic;

namespace OneToMany.Models
{
    public partial class Products_Above_Average_Price
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
