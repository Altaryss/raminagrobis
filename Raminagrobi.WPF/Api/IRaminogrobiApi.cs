using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF.Api
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
        public Task AddMember(MemberRequest request);

        [Put("/Member/Update")]
        public Task UpdateMember(MemberRequest request, int id);

        [Delete("/Member/Delete")]
        public Task DeleteMember(int id);
    }
}
