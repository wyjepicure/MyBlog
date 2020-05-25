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
    [AbpAuthorize]
    public class CategoryAppService : BlogAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;

        private readonly ICategoryManager _categoryManager;

        /// <summary>
        /// 构造函数
        ///</summary>
        public CategoryAppService(
        IRepository<Category, int> categoryRepository
              , ICategoryManager categoryManager

             )
        {
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
        }

        /// <summary>
        /// 获取的分页列表信息
        ///      </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        // [AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Query)]
        public async Task<PagedResultDto<CategoryListDto>> GetAll(GetCategorysInput input)
        {
            var query = _categoryRepository.GetAll()

                          //模糊搜索CategoryName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CategoryName.Contains(input.FilterText))
                          //模糊搜索DisplayName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.DisplayName.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var categoryList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var categoryListDtos = ObjectMapper.Map<List<CategoryListDto>>(categoryList);

            return new PagedResultDto<CategoryListDto>(count, categoryListDtos);
        }

        /// <summary>
        /// 通过指定id获取CategoryListDto信息
        /// </summary>
        //	[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Query)]
        public async Task<CategoryListDto> GetById(EntityDto<int> input)
        {
            var entity = await _categoryRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CategoryListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Create,CategoryPermissions.Pages_Blog_Category_Edit)]
        public async Task<GetCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetCategoryForEditOutput();
            CategoryEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _categoryRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<CategoryEditDto>(entity);
            }
            else
            {
                editDto = new CategoryEditDto();
            }

            output.Category = editDto;
            return output;
        }

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Create,CategoryPermissions.Pages_Blog_Category_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateCategoryInput input)
        {
            if (input.Category.Id.HasValue)
            {
                await Update(input.Category);
            }
            else
            {
                await Create(input.Category);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Create)]
        public async Task<CategoryEditDto> Create(CategoryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Category>(input);
            //调用领域服务
            entity = await _categoryManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CategoryEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Edit)]
        public async Task Update(CategoryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _categoryRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _categoryManager.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _categoryManager.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Category的方法
        /// </summary>
        //[AbpAuthorize(CategoryPermissions.Pages_Blog_Category_BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _categoryManager.BatchDelete(input);
        }

        //// custom codes

        //// custom codes end
    }
}