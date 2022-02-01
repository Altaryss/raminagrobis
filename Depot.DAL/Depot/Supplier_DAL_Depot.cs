using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Supplier_DAL_Depot : Depot_DAL<Supplier_DAL>
    {
        public override List<Supplier_DAL> GetAll()
            {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,company,civility,surname,name,email,address,create_at FROM Member";
            var reader = commande.ExecuteReader();

            var rep = new List<Supplier_DAL>();

            while (reader.Read())
            {
                var member = new Supplier_DAL(

                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetDateTime(7)
                );

                rep.Add(member);
            }

            DetruireConnexionEtCommande();

            return rep;
        }

        public List<Supplier_DAL> GetAllByIdForRefrences(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,company,civility,surname,name,email,address,create_at FROM Member Where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var nb = new List<Supplier_DAL>();

            while(reader.Read())
            {
                var add = new Supplier_DAL(


                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetDateTime(7)
                    );
                nb.Add(add);
            }
            DetruireConnexionEtCommande();

            return nb;


        }

        public override Supplier_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,company,civility,surname,name,email,address,create_at FROM Member Where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Supplier_DAL rep;

            if (reader.Read())
            {
                rep = new Supplier_DAL(


                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetDateTime(7)
                    );
            }
            else
            {
                throw new Exception($"pas d'adheran à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return rep;


        }

        public override Supplier_DAL Insert(Supplier_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Member (company,civility,surname,name,email,address,create_at)" + "(@company,@civility,@surname,@name,@email,@address,@create_at); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@company", item.Company));
            commande.Parameters.Add(new SqlParameter("@civility", item.Civility));
            commande.Parameters.Add(new SqlParameter("@surname", item.Surname));
            commande.Parameters.Add(new SqlParameter("@name", item.Name));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@address", item.Address));
            commande.Parameters.Add(new SqlParameter("@create_at", item.Create_at));
            item.ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public override Supplier_DAL Update(Supplier_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Member set company = @company, civility = @civility, surname = @surname, name = @name, email = @email, address = @address, create_at = @create_at, id = @id";

            commande.Parameters.Add(new SqlParameter("@company", item.Company));
            commande.Parameters.Add(new SqlParameter("@civility", item.Civility));
            commande.Parameters.Add(new SqlParameter("@surname", item.Surname));
            commande.Parameters.Add(new SqlParameter("@name", item.Name));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@address", item.Address));
            commande.Parameters.Add(new SqlParameter("@create_at", item.Create_at));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));
            var nb_ligne = (int)commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Supplier_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Member where id = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
                throw new Exception($"Aucune ID correspondent a {item.ID} dans la table Member");

            DetruireConnexionEtCommande();
        }
    }
}