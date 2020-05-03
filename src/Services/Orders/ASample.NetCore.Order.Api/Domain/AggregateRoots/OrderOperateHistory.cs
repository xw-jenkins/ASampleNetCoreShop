using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Order.Api.Domain.AggregateRoots
{
    public class OrderOperateHistory:AggregateRoot
    {
        public Guid OrderId { get; set; }
        public string OperateUser { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }
    }
}
