using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class Menu:AggregateRoot
    {
        /// <summary>
        /// 系统id
        /// </summary>
        public Guid MsId { get; set; }

        /// <summary>
        /// 父菜单id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        public string MenuDescription { get; set; }

        /// <summary>
        /// 菜单uri
        /// </summary>
        public string MenuUri { get; set; }

        /// <summary>
        /// 是否展示菜单
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
    }
}
