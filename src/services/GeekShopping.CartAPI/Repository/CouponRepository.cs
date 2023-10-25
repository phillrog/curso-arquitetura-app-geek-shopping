using GeekShopping.CartAPI.Data.ValueObjects;
using System.Net;
using System.Text.Json;

namespace GeekShopping.CartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/coupon";

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<CouponVO> GetCouponByCouponCode(string code)
        {
            var response = await _client.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponVO();
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<CouponVO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
