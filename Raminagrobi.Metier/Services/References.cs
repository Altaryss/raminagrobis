using Raminagrobis.DAL;
using Raminagrobi.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobi.Metier.Services
{
    internal class References
    {

        public static List<ReferencesMetier> GetAll()
        {
            var all = new List<ReferencesMetier>();
            var dep = new References_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new ReferencesMetier(item.ID, item.References, item.Wording, item.Brand, item.Status));
            }
            return all;
        }

        public static ReferencesMetier GetByID(int id)
        {
            var dep = new References_DAL_Depot();
            var references = dep.GetByID(id);
            return new ReferencesMetier(references.ID, references.References, references.Wording, references.Brand, references.Status);
        }

        public static void Insert(ReferencesReponse input)
        {
            var dep = new References_DAL_Depot();
            var references = new References_DAL(input.References, input.Wording, input.Brand, input.Status);
            dep.Insert(references);
        }

        public static void Update(int id, ReferencesReponse input)
        {
            var dep = new References_DAL_Depot();
            var references = new References_DAL(id, input.References, input.Wording, input.Brand, input.Status);
            dep.Update(references);
        }

        public static void Delete(int id)
        {
            References_DAL references;
            References_DAL_Depot dep = new References_DAL_Depot();
            references = dep.GetByID(id);
            dep.Delete(references);
        }
    }
}
