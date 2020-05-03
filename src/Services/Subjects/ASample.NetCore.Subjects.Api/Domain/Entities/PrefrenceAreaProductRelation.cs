using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Subjects.Api.Domain.Entities
{
    /// <summary>
    /// 优选专区和产品关系表
    /// </summary>
    public class PrefrenceAreaProductRelation:AggregateRoot
    {
        public Guid PrefrenceAreaId { get; set; }
        public Guid ProductId { get; set; }
    }
}
