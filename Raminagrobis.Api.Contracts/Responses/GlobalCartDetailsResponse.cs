using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Responses
{
    public class GlobalCartDetailsResponse
    {
        public int ID { get; set; }
        public int IdGlobalCart { get; set; }
        public int IdReferences { get; set; }
        public int Quantity { get; set; }
    }
}
