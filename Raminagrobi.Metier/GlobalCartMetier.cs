using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    public class GlobalCartMetier
    {
        public int ID { get; set; }
        public int Id_cart { get; private set; }
        public string Week_order { get; private set; }

        public GlobalCartMetier(int id_cart, string week_order)
        {
            Id_cart = id_cart;
            Week_order = week_order;
        }
        public GlobalCartMetier(int id, int id_cart, string week_order)
        {
            ID = id;
            Id_cart = id_cart;
            Week_order = week_order;
        }

    }
}
