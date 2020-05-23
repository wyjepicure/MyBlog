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
    public class PostTagStore : BlogDomainServiceBase, IPostTagManager
    {
        private readonly IRepository<PostTag, int> _postTagRepository;

        /// <summary>
        /// PostTag的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public PostTagStore(IRepository<PostTag, int> postTagRepository)
        {
            _postTagRepository = postTagRepository;
        }

        #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<PostTag> QueryPostTags()
        {
            return _postTagRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<PostTag> QueryPostTagsAsNoTracking()
        {
            return _postTagRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PostTag> FindByIdAsync(int id)
        {
            var entity = await _postTagRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(int id)
        {
            var result = await _postTagRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion 查询判断的业务

        public async Task<PostTag> CreateAsync(PostTag entity)
        {
            entity.Id = await _postTagRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(PostTag entity)
        {
            await _postTagRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _postTagRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _postTagRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        //// custom codes

        //// custom codes end
    }
}