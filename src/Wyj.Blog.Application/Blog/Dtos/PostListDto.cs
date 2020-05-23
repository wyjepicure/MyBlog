

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
	/// <see cref="Post"/>
	/// </summary>
    public class PostListDto : FullAuditedEntityDto<Guid> 
    {

        
		/// <summary>
		/// Title
		/// </summary>
		[Required(ErrorMessage="Title不能为空")]
		public string Title { get; set; }



		/// <summary>
		/// Author
		/// </summary>
		[Required(ErrorMessage="Author不能为空")]
		public string Author { get; set; }



		/// <summary>
		/// Url
		/// </summary>
		public string Url { get; set; }



		/// <summary>
		/// Html
		/// </summary>
		public string Html { get; set; }



		/// <summary>
		/// Markdown
		/// </summary>
		public string Markdown { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public int CategoryId { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}