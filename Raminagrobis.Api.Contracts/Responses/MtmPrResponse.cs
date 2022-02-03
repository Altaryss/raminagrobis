using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class MtmPrResponse
    {
        public int ID { get; set; }
        public int Id_references { get; private set; }
        public int Id_supplier { get; private set; }
    }
}
