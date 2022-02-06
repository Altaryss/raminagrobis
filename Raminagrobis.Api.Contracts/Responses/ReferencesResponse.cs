using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Responses
{
    public class ReferencesResponse
    {
        public int ID { get; set; }
        public string References { get; set; }
        public string Wording { get; set; }
        public string Brand { get; set; }
        public bool Status { get; set; }
    }
}
