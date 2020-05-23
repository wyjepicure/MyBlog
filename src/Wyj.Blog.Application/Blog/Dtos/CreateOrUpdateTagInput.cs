

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wyj.Blog.Blog;

namespace Wyj.Blog.Blog.Dtos
{
    public class CreateOrUpdateTagInput
    {
        [Required]
        public TagEditDto Tag { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}