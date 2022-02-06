using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Responses
{
    public class CartDetailsResponse
    {
        public int ID { get; set; }
        public int IdCart { get; set; }
        public int IdReferences { get; set; }
        public int IdGlobalDetails { get; set; }
        public int Quantity { get; set; }
    }
}
