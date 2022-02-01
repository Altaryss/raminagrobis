using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Price_DAL
    {
        public int Id_global_details { get; private set; }
        public int Id_supplier { get; private set; }
        public float Price { get; private set; }

        public int ID { get; set; }

        public Price_DAL(int id_global_details, int id_supplier, float price )
                => (Id_global_details, Id_supplier, Price) = (id_global_details, id_supplier, price);

        public Price_DAL(int id, int id_global_details, int id_supplier, float price)
         => (ID, Id_global_details, Id_supplier, Price) = (id, id_global_details, id_supplier, price);
    }
}