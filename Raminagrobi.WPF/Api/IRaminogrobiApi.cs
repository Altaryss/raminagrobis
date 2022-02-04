using Raminagrobi.Api.Contracts.Requests;
using Raminagrobi.Api.Contracts.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.WPF.Api
{
    public interface IRaminogrobiApi
    {
        [Get("/Cart/GetAll")]
        public Task<IEnumerable<CartResponse>> GetAllCarts();

        [Get("/Cart/GetById")]
        public Task<CartResponse> GetCartById(int id);

        // ---------------------------------------------

        [Get("/Member/GetAll")]
        public Task<IEnumerable<MemberResponse>> GetAllMembers();

        [Get("/Member/GetById")]
        public Task<MemberResponse> GetMemberById(int id);

        [Post("/Member/AddMember")]
        public Task AddMember(MemberRequest request); // essayer de mettre le tout dans un obj

        [Put("/Member/Update")]
        public Task UpdateMember(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at);

        [Delete("/Member/Delete")]
        public Task DeleteStudent(int id);
    }
}
