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
    public class CartViewModel : BaseViewModel
    {
        public IEnumerable<CartResponse> CartList { get; set; }
        public CartViewModel()
        {
            var api = RestService.For<IRaminogrobiApi>("https://localhost:5001");
            //var clientApi = new CartService("https://localhost:5001", new HttpClient());
            var result = new List<CartResponse>();
            //result.Add(api.GetById(1).Result);
            result.Add(api.GetCartById(1).Result);
            CartList = result;
        }
    }
}
