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
    public class Supplier
    {
        public static List<SupplierMetier> GetAll()
        {
            var all = new List<SupplierMetier>();
            var dep = new Supplier_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new SupplierMetier(item.ID, item.Company, item.Civility, item.Surname, item.Name, item.Email, item.Address, item.Create_at));
            }
            return all;
        }

        public static SupplierMetier GetByID(int id)
        {
            var dep = new Member_DAL_Depot();
            var member = dep.GetByID(id);
            return new SupplierMetier(member.ID, member.Company, member.Civility, member.Surname, member.Name, member.Email, member.Address, member.Create_at);
        }

        public static void Insert(SupplierMetier input)
        {
            var dep = new Supplier_DAL_Depot();
            var supplier = new Supplier_DAL(input.Company, input.Civility, input.Surname, input.Name, input.Email, input.Address, input.Create_at);
            dep.Insert(supplier);
        }

        public static void Update(int id, SupplierMetier input)
        {
            var dep = new Supplier_DAL_Depot();
            var supplier = new Supplier_DAL(id, input.Company, input.Civility, input.Surname, input.Name, input.Email, input.Address, input.Create_at);
            dep.Update(supplier);
        }

        public static void Delete(int id)
        {
            Supplier_DAL supplier;
            Supplier_DAL_Depot dep = new Supplier_DAL_Depot();
            supplier = dep.GetByID(id);
            dep.Delete(supplier);
        }
    }
}
