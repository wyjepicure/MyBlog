using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Wyj.Blog.Blog.Dtos;

using Wyj.Blog.Blog.DomainService;

namespace Wyj.Blog.Blog
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class TagAppService : BlogAppServiceBase, ITagAppService
    {
        private readonly IRepository<Tag, int> _tagRepository;

        private readonly ITagManager _tagManager;

        /// <summary>
        /// 构造函数
        ///</summary>
        public TagAppService(
        IRepository<Tag, int> tagRepository
              , ITagManager tagManager

             )
        {
            _tagRepository = tagRepository;
            _tagManager = tagManager;
        }

        /// <summary>
        /// 获取的分页列表信息
        ///      </summary>
        /// <param name="input"></param>
        /// <returns></returns>
      //  [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Query)]
        public async Task<PagedResultDto<TagListDto>> GetAll(GetTagsInput input)
        {
            var query = _tagRepository.GetAll()

                          //模糊搜索TagName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TagName.Contains(input.FilterText))
                          //模糊搜索DisplayName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.DisplayName.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var tagList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var tagListDtos = ObjectMapper.Map<List<TagListDto>>(tagList);

            return new PagedResultDto<TagListDto>(count, tagListDtos);
        }

        /// <summary>
        /// 通过指定id获取TagListDto信息
        /// </summary>
      //  [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Query)]
        public async Task<TagListDto> GetById(EntityDto<int> input)
        {
            var entity = await _tagRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<TagListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       // [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Create, TagPermissions.Pages_Blog_Tag_Edit)]
        public async Task<GetTagForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetTagForEditOutput();
            TagEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _tagRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<TagEditDto>(entity);
            }
            else
            {
                editDto = new TagEditDto();
            }

            output.Tag = editDto;
            return output;
        }

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
     //   [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Create, TagPermissions.Pages_Blog_Tag_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateTagInput input)
        {
            if (input.Tag.Id.HasValue)
            {
                await Update(input.Tag);
            }
            else
            {
                await Create(input.Tag);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        //[AbpAuthorize(TagPermissions.Pages_Blog_Tag_Create)]
        public  async Task<TagEditDto> Create(TagEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Tag>(input);
            //调用领域服务
            entity = await _tagManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<TagEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
       // [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Edit)]
        public  async Task Update(TagEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _tagRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _tagManager.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       // [AbpAuthorize(TagPermissions.Pages_Blog_Tag_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _tagManager.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Tag的方法
        /// </summary>
       // [AbpAuthorize(TagPermissions.Pages_Blog_Tag_BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _tagManager.BatchDelete(input);
        }

        //// custom codes

        //// custom codes end
    }
}