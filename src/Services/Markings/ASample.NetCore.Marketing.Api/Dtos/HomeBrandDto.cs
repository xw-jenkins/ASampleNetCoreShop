using System;

namespace ASample.NetCore.Marketing.Api
{
    public class HomeBrandDto
    {
        public Guid? Id { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
