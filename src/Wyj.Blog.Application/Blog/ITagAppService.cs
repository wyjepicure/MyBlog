
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wyj.Blog.Blog.Dtos;
using Wyj.Blog.Blog;



namespace Wyj.Blog.Blog
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface ITagAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TagListDto>> GetPaged(GetTagsInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<TagListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTagForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateTagInput input);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);

		
        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDelete(List<int> input);


		
							//// custom codes
									
							

							//// custom codes end
    }
}
