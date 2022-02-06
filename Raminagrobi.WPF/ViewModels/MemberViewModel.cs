using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.WPF.Api;
using Raminagrobis.WPF.Core;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF.ViewModels
{
    public class MemberViewModel : BaseViewModel
    {
        public IEnumerable<MemberResponse> MemberList { get; set; }
        public MemberViewModel()
        {
            try
            {
                var api = RestService.For<IRaminogrobiApi>("https://localhost:5001");
                //var clientApi = new CartService("https://localhost:5001", new HttpClient());
                var result = new List<MemberResponse>();
                //result.Add(api.GetMembers().Result);
                result.Add(api.GetMemberById(1).Result);
                MemberList = result;

                api.AddMember(new MemberRequest
                {
                    Name = "altaryss",
                    Surname = "Surname",
                    Civility = "M",
                    Address = "Champs elisées",
                    Company = "b",
                    Email = "test@test.fr",
                    CreatedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                var res = ex;
            }
        }
    }
}
