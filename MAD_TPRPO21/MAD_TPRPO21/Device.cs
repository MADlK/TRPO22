using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAD_TPRPO21
{
    public class Device
    {
        public int Id { get; set; }

        public string? Name { get; set; } = null!;

        public string? Manufacturer { get; set; } = null!;

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public bool? IsActive { get; set; }
    }
}
