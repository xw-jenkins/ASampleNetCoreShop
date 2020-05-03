using ASample.NetCore.Domain;


namespace ASample.NetCore.Subjects.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 优选专区
    /// </summary>
    public class PrefrenceArea:AggregateRoot
    {
        public string Name { get; set; }
        public string SubTitle { get; set; }

        /// <summary>
        /// 展示图片
        /// </summary>
        public string Pic { get; set; }
        public int Sort { get; set; }
        public bool ShowStatus { get; set; }
    }
}
