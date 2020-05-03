using ASample.NetCore.Domain;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 系统
    /// </summary>
    public class Ms:AggregateRoot
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string MsName { get; set; }

        /// <summary>
        /// 系统描述
        /// </summary>
        public string MsDescription { get; set; }

        /// <summary>
        /// 系统域名
        /// </summary>
        public string MsDomain { get; set; }
    }
}
