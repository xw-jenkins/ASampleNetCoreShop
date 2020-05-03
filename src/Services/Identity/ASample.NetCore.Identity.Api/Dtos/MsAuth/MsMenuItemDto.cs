using ASample.NetCore.Identity.Api.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ASample.NetCore.Identity.Api.Dtos
{
    public class MsMenuJsonDto
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public List<LayUiMenuDto> Data { get; set; }
    }

    public class LayUiMenuDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("jump")]
        public string Jump { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("list")]
        public List<LayUiMenuDto> List { get; set; }
    }

    public class MenuComparer : IEqualityComparer<Menu>
    {
        public bool Equals([AllowNull] Menu x, [AllowNull] Menu y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Menu obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
