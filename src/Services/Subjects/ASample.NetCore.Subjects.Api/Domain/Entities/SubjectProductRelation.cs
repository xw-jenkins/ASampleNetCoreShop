using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Subjects.Api.Domain.Entities
{
    public class SubjectProductRelation:AggregateRoot
    {
        public Guid SubjectId { get; set; }
        public Guid ProductId { get; set; }
    }
}
