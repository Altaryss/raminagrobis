using Raminagrobis.DAL;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobis.Metier
{
    public class ReferencesMetier
    {
        public int ID { get; set; }
        public string References { get; private set; }
        public string Wording { get; private set; }
        public string Brand { get; private set; }
        public bool Status { get; private set; }

        public ReferencesMetier(string references, string wording, string brand, bool status)
        {
            References = references;
            Wording = wording;
            Brand = brand;
            Status = status;
        }

        public ReferencesMetier(int id, string references, string wording, string brand, bool status)
        {
            ID = id;
            References = references;
            Wording = wording;
            Brand = brand;
            Status = status;
        }

        public string GetReferences()
        {
            return References;
        }

        public string GetWoreding()
        {
            return Wording;
        }

        public string GetBrand()
        {
            return Brand;
        }
    }
}