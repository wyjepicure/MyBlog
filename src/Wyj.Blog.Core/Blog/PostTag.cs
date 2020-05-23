using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace Wyj.Blog.Blog
{
    /// <summary>
    /// PostTag
    /// </summary>
    public class PostTag : Entity<int>
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// 标签Id
        /// </summary>
        public int TagId { get; set; }
    }
}