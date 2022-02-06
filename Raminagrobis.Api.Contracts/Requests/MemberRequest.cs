using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Contracts.Requests
{
    public class MemberRequest
    {
        public int ID { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Civility { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}