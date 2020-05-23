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
    public class TagManager : BlogDomainServiceBase, ITagManager
    {
        private readonly IRepository<Tag, int> _tagRepository;

        /// <summary>
        /// Tag的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public TagManager(IRepository<Tag, int> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tag> QueryTags()
        {
            return _tagRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tag> QueryTagsAsNoTracking()
        {
            return _tagRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tag> FindByIdAsync(int id)
        {
            var entity = await _tagRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(int id)
        {
            var result = await _tagRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion 查询判断的业务

        public async Task<Tag> CreateAsync(Tag entity)
        {
            entity.Id = await _tagRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Tag entity)
        {
            await _tagRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _tagRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _tagRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        //// custom codes

        //// custom codes end
    }
}