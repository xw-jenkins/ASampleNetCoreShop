using ASample.NetCore.Domain;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 相册表
    /// </summary>
    public class Album:AggregateRoot
    {
        public string Name { get; set; }
        public string ConverPic { get; set; }
        public int PicCount { get; set; }
        public int Sort { get; set; }
        public string Decription { get; set; }
    }
}
