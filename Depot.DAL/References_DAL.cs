using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class References_DAL
    {
        public string References { get; private set; }
        public string Wording { get; private set; }
        public string Brand { get; private set; }
        public bool Status { get; private set; }

        public int ID { get; set; }

        public References_DAL(string references, string wording, string brand, bool status)
                => (References, Wording, Brand, Status) = (references, wording, brand, status);

        public References_DAL(int id,string references, string wording, string brand, bool status)
                => (ID, References, Wording, Brand, Status) = (id ,references, wording, brand, status);


    }
}