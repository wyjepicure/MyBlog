

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wyj.Blog.Blog;

namespace Wyj.Blog.Blog.Dtos
{
    public class CreateOrUpdateCategoryInput
    {
        [Required]
        public CategoryEditDto Category { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}