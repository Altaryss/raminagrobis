using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Globlal_cart_details_DAL
    {
        public int Id_global_cart { get; private set; }
        public int Id_references { get; private set; }
        public int Quantity { get; private set; }

        public int ID { get; set; }

        public Globlal_cart_details_DAL(int id_global_cart, int id_references, int quantity) 
                => (Id_global_cart, Id_references, Quantity) = (id_global_cart, id_references, quantity);

        public Globlal_cart_details_DAL(int id,int id_global_cart, int id_references, int quantity)
                => (ID, Id_global_cart, Id_references, Quantity) = (id, id_global_cart, id_references, quantity);


    }
}