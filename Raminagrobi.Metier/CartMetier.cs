using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Metier
{
    public class CartMetier
    {
        public int ID { get; set; }
        public int Id_Member { get; private set; }
        public string Week_order { get; private set; }

        public CartMetier(int id_member, string week_order)
        {
            Id_Member = id_member;
            Week_order = week_order;
        }

        public CartMetier(int id,int id_member, string week_order)
        {
            ID = id;
            Id_Member = id_member;
            Week_order = week_order;
        }
    }
}
