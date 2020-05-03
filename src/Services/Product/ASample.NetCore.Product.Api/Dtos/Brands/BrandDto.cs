using System;

namespace ASample.NetCore.Product.Api
{
    public class BrandDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstLetter { get; set; }
        public int Sort { get; set; }
        public bool FactoryStatus { get; set; }
        public bool ShowStatus { get; set; }
        public string Logo { get; set; }
        public string BigPic { get; set; }
        public string BrandStory { get; set; }
    }
}
