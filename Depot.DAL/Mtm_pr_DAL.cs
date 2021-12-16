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

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(Id_references,id_supplier, id)"
                                + " values (@Id_references, @id_supplier, @id_supplier, @id )";

                commande.Parameters.Add(new SqlParameter("@Id_references", Id_references));
                commande.Parameters.Add(new SqlParameter("@id_supplier", Id_supplier));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}