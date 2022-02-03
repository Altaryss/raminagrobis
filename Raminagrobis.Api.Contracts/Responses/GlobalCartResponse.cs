using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class GlobalCartResponse
    {
        public int ID { get; set; }
        public int Id_cart { get; private set; }
        public string Week_order { get; private set; }
    }
}
