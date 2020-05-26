using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Wyj.Blog.Blog;
using Wyj.Blog.Blog.Dtos;

using Wyj.Blog.Blog.DomainService;
using Wyj.Blog.Authorization;
using Wyj.Blog.Blog.Authorization;

namespace Wyj.Blog.Blog
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    
    public class PostAppService : BlogAppServiceBase, IPostAppService
    {
        private readonly IRepository<Post, Guid> _postRepository;

        private readonly IPostManager _postManager;

        /// <summary>
        /// 构造函数
        ///</summary>
        public PostAppService(
        IRepository<Post, Guid> postRepository
              , IPostManager postManager

             )
        {
            _postRepository = postRepository;
            _postManager = postManager;
        }

        /// <summary>
        /// 获取的分页列表信息
        ///      </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<PostListDto>> GetPaged(GetPostsInput input)
        {
            var query = _postRepository.GetAll()

                          //模糊搜索Title
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Title.Contains(input.FilterText))
                          //模糊搜索Author
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Author.Contains(input.FilterText))
                          //模糊搜索Url
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Url.Contains(input.FilterText))
                          //模糊搜索Html
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Html.Contains(input.FilterText))
                          //模糊搜索Markdown
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Markdown.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var postList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var postListDtos = ObjectMapper.Map<List<PostListDto>>(postList);

            return new PagedResultDto<PostListDto>(count, postListDtos);
        }

        /// <summary>
        /// 通过指定id获取PostListDto信息
        /// </summary>

        public async Task<PostListDto> GetById(EntityDto<Guid> input)
        {
            var entity = await _postRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<PostListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetPostForEditOutput> GetForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetPostForEditOutput();
            PostEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _postRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<PostEditDto>(entity);
            }
            else
            {
                editDto = new PostEditDto();
            }

            output.Post = editDto;
            return output;
        }

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdatePostInput input)
        {
            if (input.Post.Id.HasValue)
            {
                await Update(input.Post);
            }
            else
            {
                await Create(input.Post);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>

        public  async Task<PostEditDto> Create(PostEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Post>(input);
            //调用领域服务
            entity = await _postManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<PostEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>

        public  async Task Update(PostEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _postRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _postManager.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _postManager.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Post的方法
        /// </summary>

        public async Task BatchDelete(List<Guid> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _postManager.BatchDelete(input);
        }

        //// custom codes

        //// custom codes end
    }
}