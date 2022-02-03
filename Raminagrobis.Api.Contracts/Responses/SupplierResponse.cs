using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Responses
{
    public class SupplierResponse
    {
        public int ID { get; set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }
    }
}
