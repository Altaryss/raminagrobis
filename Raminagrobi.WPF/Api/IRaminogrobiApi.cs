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
        public Task<IEnumerable<CartResponse>> GetAll();

        [Get("/Cart/GetById")]
        public Task<CartResponse> GetById(int id);

        [Get("/Member/GetAll")]
        public Task<IEnumerable<MemberResponse>> GetAll();
    }
}
