using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Metier
{
    public class CartdetailsMetier
    {
        public int ID { get; set; }
        public int Id_cart { get; private set; }
        public int Id_references { get; private set; }
        public int Id_global_details { get; private set; }
        public int Quantity { get; private set; }

        public CartdetailsMetier(int id_cart, int id_references, int id_global_details, int quantity)
        {
            Id_cart = id_cart;
            Id_references = id_references;
            Id_global_details = id_global_details;
            Quantity = quantity;
        }

        public CartdetailsMetier(int id, int id_cart, int id_references, int id_global_details, int quantity)
        {
            ID = id;
            Id_cart = id_cart;
            Id_references = id_references;
            Id_global_details = id_global_details;
            Quantity = quantity;
        }
    }
}
