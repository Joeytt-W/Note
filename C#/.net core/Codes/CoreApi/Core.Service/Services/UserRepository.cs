using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Enum;
using Core.Entity.Models;
using Core.Service.Data;
using Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utility;
using System.Linq;
using Core.Service.Hepler;
using System.Reflection;
using NLog;
using Newtonsoft.Json;

namespace Core.Service.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        
        public UserRepository(CoreDbContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
            
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User user,bool save = true)
        {
            user.CreateTime = DateTime.Now;
            user.Spell = CommonUtil.GetPYCode(user.UserName);
            await _context.Users.AddAsync(user);
            if (save)
                await SaveAsync();
            return user;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(Guid userId,bool save)
        {
            _context.Users.Remove(_context.Users.Find(userId));
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userQueryParam"></param>
        /// <returns></returns>
        public async Task<ExecuteOutParam<User>> GetUsersAsync(UserQueryParam userQueryParam)
        {
            var queryExpression = _context.Users as IQueryable<User>;           
            if (!(userQueryParam.UserId == Guid.Empty))
            {
                queryExpression = queryExpression.Where(x => x.ID == userQueryParam.UserId);
            }

            if (!(userQueryParam.DepartmentId == Guid.Empty))
            {
                queryExpression = queryExpression.Where(x => x.DepartmentID == userQueryParam.DepartmentId);
            }

            if (!string.IsNullOrWhiteSpace(userQueryParam.SearchStr))
            {
                queryExpression = queryExpression.Where(x => x.UserCode.Contains(userQueryParam.SearchStr) ||  x.UserName.Contains(userQueryParam.SearchStr));
            }
            //var mappingDictionary = _propertyMappingService.GetPropertyMapping<User, User>();
            //queryExpression.ApplySort(userQueryParam.OrderBy,mappingDictionary);
            queryExpression = EFSortUtil.OrderBy(queryExpression, userQueryParam.OrderBy);
            //var newExpression = _mapper.Map<IQueryable<UserQueryDto>>(queryExpression);
            var items = await ExecuteOutParam<User>.CreateAsync(queryExpression, userQueryParam.PageNumber, userQueryParam.PageSize);
            return items;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task UpdateUserAsync(User user,bool save)
        {
            user.UpdateTime = DateTime.Now;
            user.Spell = CommonUtil.GetPYCode(user.UserName);
            _context.Users.Update(user);
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(Guid userId)
        {
            return await _context.Users.AnyAsync(x => x.ID == userId);
        }

        /// <summary>
        /// 按userId查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserAsyncById(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
