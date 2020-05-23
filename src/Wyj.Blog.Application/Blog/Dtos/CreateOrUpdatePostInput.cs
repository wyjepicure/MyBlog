

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wyj.Blog.Blog;

namespace Wyj.Blog.Blog.Dtos
{
    public class CreateOrUpdatePostInput
    {
        [Required]
        public PostEditDto Post { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}