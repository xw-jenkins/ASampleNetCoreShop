using System;

namespace ASample.NetCore.Marketing.Api
{
    public class HomeRecommendProductDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
