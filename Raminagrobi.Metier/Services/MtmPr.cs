using Raminagrobis.DAL;
using Raminagrobis.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Raminagrobis.Metier;

namespace Raminagrobi.Metier.Services
{
    public class MtmPr
    {
        public List<MtmPrMetier> GetAll()
        {
            var all = new List<MtmPrMetier>();
            var dep = new Mtm_pr_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new MtmPrMetier(item.ID, item.Id_references, item.Id_supplier));
            }
            return all;
        }

        public MtmPrMetier GetByID(int id)
        {
            var dep = new Mtm_pr_DAL_Depot();
            var member = dep.GetByID(id);
            return new MtmPrMetier(member.ID, member.Id_references, member.Id_supplier);
        }

        public void Insert(MemberResponse input)
        {
            var dep = new Member_DAL_Depot();
            var member = new Member_DAL(input.Company, input.Civility, input.Surname, input.Name, input.Email, input.Address, input.CreatedAt);
            dep.Insert(member);
        }

        public void Update(int id, MemberResponse input)
        {
            var dep = new Member_DAL_Depot();
            var member = new Member_DAL(id, input.Company, input.Civility, input.Surname, input.Name, input.Email, input.Address, input.CreatedAt);
            dep.Update(member);
        }

        public void Delete(int id)
        {
            Member_DAL member;
            Member_DAL_Depot dep = new Member_DAL_Depot();
            member = dep.GetByID(id);
            dep.Delete(member);
        }
    }
}
