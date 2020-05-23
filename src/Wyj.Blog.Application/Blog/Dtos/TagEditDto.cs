
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using Wyj.Blog.Blog;


namespace  Wyj.Blog.Blog.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Tag"/>
	/// </summary>
    public class TagEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// TagName
		/// </summary>
		[Required(ErrorMessage="TagName不能为空")]
		public string TagName { get; set; }



		/// <summary>
		/// DisplayName
		/// </summary>
		[Required(ErrorMessage="DisplayName不能为空")]
		public string DisplayName { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}