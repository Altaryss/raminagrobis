using Raminagrobi.Api.Contracts.Responses;
using Raminagrobi.WPF.Api;
using Raminagrobi.WPF.Core;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.WPF.ViewModels
{
    public class MemberViewModel : BaseViewModel
    {
        public IEnumerable<MemberResponse> MemberList { get; set; }
        public MemberViewModel()
        {
            var api = RestService.For<IRaminogrobiApi>("https://localhost:44356");
            //var clientApi = new CartService("https://localhost:44356", new HttpClient());
            var result = new List<MemberResponse>();
            result.Add(api.GetAll().Result);
            MemberList = result;
        }
    }
}
