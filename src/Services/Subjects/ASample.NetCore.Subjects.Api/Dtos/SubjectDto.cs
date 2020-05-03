using System;

namespace ASample.NetCore.Subjects.Api
{
    public class SubjectDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 专题分类名称
        /// </summary>
        public string CategoryName { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 专题主图
        /// </summary>
        public string Pic { get; set; }

        /// <summary>
        /// 关联产品数量
        /// </summary>
        public int ProductCount { get; set; }
        public int CollectCount { get; set; }
        public int ReadCount { get; set; }
        public int CommentCount { get; set; }
        public bool RecommendStatus { get; set; }

        /// <summary>
        /// 显示状态：0->不显示；1->显示
        /// </summary>
        public bool ShowStatus { get; set; }

        /// <summary>
        /// 画册图片用逗号分割
        /// </summary>
        public string AlbumPics { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        public int ForwardCount { get; set; }
    }
}
