using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace Wyj.Blog.Blog
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category : Entity<int>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}