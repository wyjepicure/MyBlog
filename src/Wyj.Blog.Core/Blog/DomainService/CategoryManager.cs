

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Wyj.Blog.Blog.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class CategoryManager :BlogDomainServiceBase, ICategoryManager
    {
		
		private readonly IRepository<Category,int> _categoryRepository;

		/// <summary>
		/// Category的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public CategoryManager(IRepository<Category, int> categoryRepository)	{
			_categoryRepository =  categoryRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Category> QueryCategorys()
        {
            return _categoryRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Category> QueryCategorysAsNoTracking()
        {
            return _categoryRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> FindByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(int id)
        {
            var result = await _categoryRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<Category> CreateAsync(Category entity)
        {
            entity.Id = await _categoryRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Category entity)
        {
            await _categoryRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _categoryRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _categoryRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
