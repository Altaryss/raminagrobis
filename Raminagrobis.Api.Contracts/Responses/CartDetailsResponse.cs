using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class CartDetailsResponse
    {
        public int ID { get; set; }
        public int Id_cart { get; private set; }
        public int Id_references { get; private set; }
        public int Id_global_details { get; private set; }
        public int Quantity { get; private set; }
    }
}
