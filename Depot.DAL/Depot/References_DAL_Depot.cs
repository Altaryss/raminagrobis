using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class References_DAL_Depot : Depot_DAL<References_DAL>
    {
        public override List<References_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, references, wording, brand, status from references";
            var reader = commande.ExecuteReader();

            var nb = new List<References_DAL>();

            while (reader.Read())
            {
                var add = new References_DAL(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                nb.Add(add);
            }

            DetruireConnexionEtCommande();

            return nb;
        }

        public override References_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, references, wording, brand, status from references where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));

            var reader = commande.ExecuteReader();

            References_DAL response;

            if (reader.Read())
            {
                response = new References_DAL(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));

            }
            else
            {
                throw new Exception($"pas d'id {ID} pour references");
            }
            DetruireConnexionEtCommande();

            return response;
        }

        public override References_DAL Insert(References_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into references(references, wording, brand, status)" + " value (@references, @brand, @status); select scope_identity";
            commande.Parameters.Add(new SqlParameter("@references", item.References));
            commande.Parameters.Add(new SqlParameter("@wording", item.Wording));
            commande.Parameters.Add(new SqlParameter("@brand", item.Brand));
            commande.Parameters.Add(new SqlParameter("@status", item.Status));

            var id = Convert.ToInt32(commande.ExecuteScalar());

            item.ID = id;

            DetruireConnexionEtCommande();

            return item;
        }

        public override References_DAL Update(References_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update references SET references = @references, wording = @wording, brand = @brand, status = @status where id = @id";
            commande.Parameters.Add(new SqlParameter("@references", item.References));
            commande.Parameters.Add(new SqlParameter("@wording", item.Wording));
            commande.Parameters.Add(new SqlParameter("@brand", item.Brand));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nb = commande.ExecuteNonQuery();

            if (nb != 1)
            {
                throw new Exception($"impossible d'update References {item.ID}");
            }

            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(References_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from references where id=@ID ";
            commande.Parameters.Add(new SqlParameter("ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"impossible de delete {item.ID} dans References");
            }
            DetruireConnexionEtCommande();
        }
    }
}