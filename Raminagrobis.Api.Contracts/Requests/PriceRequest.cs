using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Requests
{
    public class PriceRequest
    {
        public int ID { get; set; }

        [Required]
        public int IdGlobalDetails { get; set; }
        [Required]
        public int IdSupplier { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
