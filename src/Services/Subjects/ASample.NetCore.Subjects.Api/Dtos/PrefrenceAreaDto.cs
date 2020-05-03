using System;

namespace ASample.NetCore.Subjects.Api
{
    public class PrefrenceAreaDto
    {
        public Guid? Id { get; set; }
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
