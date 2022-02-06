using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Requests
{
    public class GlobalCartDetailsRequest
    {
        public int ID { get; set; }

        [Required]
        public int IdGlobalCart { get; set; }

        [Required]
        public int IdReferences { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
