using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    public class GlobalCartDetailsMetier
    {
        public int ID { get; set; }
        public int Id_global_cart { get; private set; }
        public int Id_references { get; private set; }
        public int Quantity { get; private set; }
        public GlobalCartDetailsMetier(int id_global_cart, int id_references, int quantity)
        {
            Id_global_cart = id_global_cart;
            Id_references = id_references;
            Quantity = quantity;
        }

        public GlobalCartDetailsMetier(int id,int id_global_cart, int id_references, int quantity)
        {
            ID = id;
            Id_global_cart = id_global_cart;
            Id_references = id_references;
            Quantity = quantity;
        }

    }
}
