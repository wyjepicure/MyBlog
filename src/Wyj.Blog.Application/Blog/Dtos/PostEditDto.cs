
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
	/// <see cref="Post"/>
	/// </summary>
    public class PostEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }         


        
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