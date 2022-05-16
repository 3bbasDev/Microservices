using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discount;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discount)
        {
            _discount = discount ?? throw new ArgumentNullException(nameof(discount));
        }

        public async Task<CouponModel> GetDiscount(string productName)
            =>await _discount.GetDiscountAsync(new GetDiscountRequest() { ProductName = productName });
    }
}
