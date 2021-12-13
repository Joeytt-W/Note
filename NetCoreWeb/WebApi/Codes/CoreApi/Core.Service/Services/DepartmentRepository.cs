using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Enum;
using Core.Service.Data;
using Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CoreDbContext _context;

        public DepartmentRepository(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="department"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task AddDepartmentAsync(Department department, bool save)
        {
            department.CreateTime = DateTime.Now;
            await _context.Departments.AddAsync(department);
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task DeleteDepartmentAsync(Guid deptId, bool save)
        {
            _context.Departments.Remove(_context.Departments.Find(deptId));
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(Guid Id)
        {
            return await _context.Departments.AnyAsync(x => x.ID == Id);
        }

        /// <summary>
        /// 按ID获取部门信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<Department> GetDepartmentById(Guid departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        /// <summary>
        /// 查询部门列表
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
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
        /// <param name="department"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task UpdateDepartmentAsync(Department department, bool save)
        {
            department.UpdateTime = DateTime.Now;
            _context.Departments.Update(department);
            if (save)
                await SaveAsync();
        }
    }
}
