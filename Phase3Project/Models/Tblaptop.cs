using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Tblaptop
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public int? Quantity { get; set; }
        public int? CostPerLaptop { get; set; }
    }
}
