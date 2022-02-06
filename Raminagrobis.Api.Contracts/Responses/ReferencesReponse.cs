using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class ReferencesReponse
    {
        public int ID { get; set; }
        public string References { get; private set; }
        public string Wording { get; private set; }
        public string Brand { get; private set; }
        public bool Status { get; private set; }
    }
}
