using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.Metier
{
    internal class MtmPrMetier
    {        
        public int ID { get; set; }
        public int Id_references { get; private set; }
        public int Id_supplier { get; private set; }

        public MtmPrMetier(int id_references, int id_supplier)
        {
            Id_references = id_references;
            Id_supplier = id_supplier;
        }

        public MtmPrMetier(int id, int id_references, int id_supplier)
        {
            ID = id;
            Id_references = id_references;
            Id_supplier = id_supplier;
        }
    }
}
