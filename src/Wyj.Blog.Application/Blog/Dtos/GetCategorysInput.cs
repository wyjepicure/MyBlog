
using Abp.Runtime.Validation;
using Wyj.Blog.Dtos;
using Wyj.Blog.Blog;

namespace Wyj.Blog.Blog.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetCategorysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
		
							//// custom codes
									
							

							//// custom codes end
    }
}
