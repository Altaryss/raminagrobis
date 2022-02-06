using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Responses
{
    public class PriceResponse
    {
        public int ID { get; set; }
        public int IdGlobalDetails { get; set; }
        public int IdSupplier { get; set; }
        public float Price { get; set; }
    }
}
