using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class CartResponse
    {
        public int ID { get; set; }
        public int IdMember { get; set; }
        public string WeekOrder { get; set; }
    }
}
