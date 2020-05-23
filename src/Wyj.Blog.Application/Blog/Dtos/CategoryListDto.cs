

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using Wyj.Blog.Blog;
using System.Collections.ObjectModel;


namespace Wyj.Blog.Blog.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="Category"/>
	/// </summary>
    public class CategoryListDto : EntityDto<int> 
    {

        
		/// <summary>
		/// CategoryName
		/// </summary>
		[Required(ErrorMessage="CategoryName不能为空")]
		public string CategoryName { get; set; }



		/// <summary>
		/// DisplayName
		/// </summary>
		[Required(ErrorMessage="DisplayName不能为空")]
		public string DisplayName { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}