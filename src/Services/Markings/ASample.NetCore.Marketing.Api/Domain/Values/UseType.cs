using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum UseType
    {
        [Description("全场通用")]
        GeneralPurpose,
        [Description("指定分类")]
        DesignatedCategory,
        [Description("指定商品")] 
        DesignatedProduct
    }
}
