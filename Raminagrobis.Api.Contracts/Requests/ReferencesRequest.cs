using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Requests
{
    public class ReferencesRequest
    {

        public int ID { get; set; }

        [Required]
        public string References { get; set; }

        [Required]
        public string Wording { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
