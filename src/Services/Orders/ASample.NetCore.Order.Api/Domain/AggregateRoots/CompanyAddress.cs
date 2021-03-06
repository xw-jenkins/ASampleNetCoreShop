using ASample.NetCore.Domain;

namespace ASample.NetCore.Order.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 公司收发货地址表
    /// </summary>
    public class CompanyAddress:AggregateRoot
    {
        /// <summary>
        /// 地址名称
        /// </summary>
        public string AddressName { get; set; }

        /// <summary>
        /// 默认发货地址：0->否；1->是
        /// </summary>
        public bool SendStatus { get; set; }

        /// <summary>
        /// 是否默认收货地址：0->否；1->是
        /// </summary>
        public bool ReceiveStatus { get; set; }

        /// <summary>
        /// 收发货人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 省/直辖市
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress { get; set; }
    }
}
