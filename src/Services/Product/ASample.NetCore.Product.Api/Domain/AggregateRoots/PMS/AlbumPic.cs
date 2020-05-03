using ASample.NetCore.Domain;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 画册图片表
    /// </summary>
    public class AlbumPic:AggregateRoot
    {
        public string AlbumId { get; set; }
        public string Pic { get; set; }
    }
}
