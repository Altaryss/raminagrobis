using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Mtm_pr_DAL_Depot : Depot_DAL<Mtm_pr_DAL>
    {
        public override List<Mtm_pr_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_global_cart, id_references, quantity, id from global_cart_details";
            var reader = commande.ExecuteReader();

            var nb = new List<Mtm_pr_DAL>();

            while (reader.Read())
            {
                var add = new Mtm_pr_DAL(reader.GetInt32(0), reader.GetInt32(1));
                nb.Add(add);
            }

            DetruireConnexionEtCommande();

            return nb;
        }

        public override Mtm_pr_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_references, id_supplier from mtm_pr where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Mtm_pr_DAL response;

            if (reader.Read())
            {
                response = new Mtm_pr_DAL(reader.GetInt32(0), reader.GetInt32(1));
            }
            else
            {
                throw new Exception($"pas d'id {ID} pour Mtm_pr_DAL");
            }
            DetruireConnexionEtCommande();

            return response;
        }

        public override Mtm_pr_DAL Insert(Mtm_pr_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into mtm_pr(id_references, id_supplier)" + "value (@id_references, @id_supplier); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@id_supplier", item.Id_supplier));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public override Mtm_pr_DAL Update(Mtm_pr_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update mtm_pr SET id_references = @id_references, id_supplier = @id_supplier where id = @id";
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@id_supplier", item.Id_supplier));

            var nb = commande.ExecuteNonQuery();

            if (nb != 1)
            {
             throw new Exception($"impossible d'update Mtm_pr {item.ID}");
            }

            DetruireConnexionEtCommande();

            return item;
        }
        public override void Delete(Mtm_pr_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from cart_details where id=@ID ";
            commande.Parameters.Add(new SqlParameter("ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($" impossible de delete {item.ID} dans Mtm_pr");
            }
            DetruireConnexionEtCommande();
        }


    }
}