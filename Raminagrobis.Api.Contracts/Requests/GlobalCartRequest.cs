using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Contracts.Requests
{
    public class GlobalCartRequest
    {

        public int ID { get; set; }

        [Required]
        public int IdCart { get; set; }
        [Required]
        public string WeekOrder { get; set; }
    }
}
