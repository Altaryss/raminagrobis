using Raminagrobis.DAL;
using Raminagrobi.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Raminagrobi.Api.Contracts.Requests;

namespace Raminagrobi.Metier.Services
{
    public class Member
    {
        public List<MemberMetier> GetAll()
        {
            var all = new List<MemberMetier>();
            var dep = new Member_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new MemberMetier(item.ID, item.Company, item.Civility, item.Surname, item.Name, item.Email, item.Address, item.Create_at));
            }
            return all;
        }

        public MemberMetier GetByID(int id)
        {
            var dep = new Member_DAL_Depot();
            var member =  dep.GetByID(id);
            return new MemberMetier(member.ID, member.Company, member.Civility, member.Surname, member.Name, member.Email, member.Address, member.Create_at);
        }

        public void Insert(MemberRequest input)
        {
            var dep = new Member_DAL_Depot();
            var member = new Member_DAL(input.Company, input.Civility, input.Surname, input.Name, input.Email, input.Address, input.CreatedAt);
            dep.Insert(member);
        }

        public void Update(int id, MemberRequest input)
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

