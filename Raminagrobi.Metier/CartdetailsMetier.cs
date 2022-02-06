using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    public class CartDetailsMetier
    {
        public int ID { get; set; }
        public int IdCart { get; private set; }
        public int IdReferences { get; private set; }
        public int IdGlobalDetails { get; private set; }
        public int Quantity { get; private set; }

        public CartDetailsMetier(int id_cart, int id_references, int id_global_details, int quantity)
        {
            IdCart = id_cart;
            IdReferences = id_references;
            IdGlobalDetails = id_global_details;
            Quantity = quantity;
        }

        public CartDetailsMetier(int id, int id_cart, int id_references, int id_global_details, int quantity)
        {
            ID = id;
            IdCart = id_cart;
            IdReferences = id_references;
            IdGlobalDetails = id_global_details;
            Quantity = quantity;
        }
    }
}
