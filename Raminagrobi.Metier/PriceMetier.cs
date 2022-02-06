using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    public class PriceMetier
    {   
        public int ID { get; set; }
        public int Id_global_details { get; private set; }
        public int Id_supplier { get; private set; }
        public float Price { get; private set; }

        public PriceMetier(int id_global_details, int id_supplier, float price)
        {
            Id_global_details = id_global_details;
            Id_supplier = id_supplier;
            Price = price;
        }

        public PriceMetier(int id, int id_global_details, int id_supplier, float price)
        {
            ID = id;
            Id_global_details = id_global_details;
            Id_supplier = id_supplier;
            Price = price;
        }
    }
}
