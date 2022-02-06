using Raminagrobis.DAL;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;

namespace Raminagrobi.Metier
{
    public class SupplierMetier
    {        
        public int ID { get; set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }

        public List<ReferencesMetier> References { get; private set; }

        public SupplierMetier(string company, string civility, string surname, string name, string email, string address, DateTime create_at)
        { 
            Company = company;
            Civility = civility; 
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            Create_at = create_at;
            References = new List<ReferencesMetier>();
        }

        public SupplierMetier(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at)
        {
            ID = id;
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            Create_at = create_at;
            References = new List<ReferencesMetier>();
        }
        public void AddReferences(List<ReferencesMetier> references)
        {
            foreach (var item in references)
            {
                References.Add(item);
            }
        }

        public void AddReferencesFromCSV(StreamReader file)
        {
            var getline = file.ReadLine();
            var columnName = getline.Split(";");

            if (columnName.Length == 3)
            {
                while (!file.EndOfStream)
                {
                    var getcolumn = file.ReadLine().Split(";");
                    string Refrences = "";
                    string Wording = "";
                    string Brand = "";

                    for (int i = 0; i < 3; i++)
                    {
                        switch (columnName[i])
                        {
                            case "reference":
                                Refrences = getcolumn[i];
                                break;
                            case "libelle":
                                Wording = getcolumn[i];
                                break;
                            case "marque":
                                Brand = getcolumn[i];
                                break;
                            default:
                                throw new Exception($"le csv n'est pas lisible");

                        }
                    }
                    if (Refrences == "" || Wording == "" || Brand == "")
                    {
                        throw new Exception("Le CSV est Vide");
                    }
                    else
                    {
                        this.AddReferences(new ReferencesMetier (Refrences, Wording, Brand, true));
                    }
                }
            }
            else
            {
                throw new Exception("Le CSV est dans le mauvais format");
            }
        }

        private void AddReferences(ReferencesMetier references)
        {
            References.Add(references);
        }
    }
}
