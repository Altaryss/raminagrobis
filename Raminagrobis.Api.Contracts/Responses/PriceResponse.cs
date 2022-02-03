using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class PriceResponse
    {
        public int ID { get; set; }
        public int Id_global_details { get; private set; }
        public int Id_supplier { get; private set; }
        public float Price { get; private set; }
    }
}
