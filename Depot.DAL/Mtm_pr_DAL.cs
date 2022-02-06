using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Mtm_pr_DAL
    {
        public int Id_references { get; private set; }
        public int Id_supplier { get; private set; }

        public int ID { get; set; }

        public Mtm_pr_DAL(int id_references, int id_supplier) 
                => (Id_references, Id_references) = (id_references,id_supplier);

        public Mtm_pr_DAL(int id,int id_references, int id_supplier)
               => (ID,Id_references, Id_references) = (id,id_references, id_supplier);
    }
}