using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Interfaces;
using Core.Service.Services;
using Core.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Utility.LogHelper;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleService;
        private readonly IBase _baseService;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository roleService, IBase baseService, IMapper mapper)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));

            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 按ID查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(Guid roleId)
        {
            if (roleId == Guid.Empty)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"角色Id为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
            try
            {
                var role = await _roleService.GetRoleById(roleId);

                if (role == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, roleId, HttpStatusCode.NotFound, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return NotFound(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    Data = _mapper.Map<RoleQueryDto>(role)
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, string.Empty, JsonConvert.SerializeObject(returnValue));
                return Ok(returnValue);
            }
            catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, roleId, HttpStatusCode.InternalServerError, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 条件查询角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetRoles))]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleService.GetRoles();

                if (roles == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                    return NotFound(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    TotalCount = roles.Count,
                    Data = _mapper.Map<IEnumerable<RoleQueryDto>>(roles)
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, string.Empty, JsonConvert.SerializeObject(returnValue));
                return Ok(returnValue);
            }
            catch (Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleDto">角色实体</param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateRole))]
        public async Task<IActionResult> CreateRole(RoleAddDto roleDto)
        {
            if (roleDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }

            var role = _mapper.Map<Role>(roleDto);
            await _roleService.AddRoleAsync(role, false);
            if (await _baseService.SaveAsync())
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.Created, Information = "新增角色成功" };
                NLogUtil.WriteDBLog(LogLevel.Info, role.ID, HttpStatusCode.Created, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                return Ok(noneExecuteOutParam);
            }
            else
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"新增角色失败" };
                NLogUtil.WriteDBLog(LogLevel.Error, role.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [HttpPut(Name = nameof(UpdateRole))]
        public async Task<IActionResult> UpdateRole(RoleUpdateDto roleDto)
        {
            if (roleDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }

            if (!await _roleService.ExistsAsync(roleDto.ID))
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = "角色不存在" };
                NLogUtil.WriteDBLog(LogLevel.Error, roleDto.ID, HttpStatusCode.NotFound, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            var role = _mapper.Map<Role>(roleDto);
            await _roleService.UpdateRoleAsync(role, false);

            if (await _baseService.SaveAsync())
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = "修改成功" };
                NLogUtil.WriteDBLog(LogLevel.Info, roleDto.ID, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                return Ok(noneExecuteOutParam);
            }
            else
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"修改失败" };
                NLogUtil.WriteDBLog(LogLevel.Error, roleDto.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(roleDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(Guid roleId)
        {
            if (roleId == Guid.Empty)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"角色Id为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }

            if (!await _roleService.ExistsAsync(roleId))
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = "角色不存在" };
                NLogUtil.WriteDBLog(LogLevel.Error, roleId, HttpStatusCode.NotFound, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            await _roleService.DeleteRoleAsync(roleId,false);
            if (!await _roleService.SaveAsync())
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = "删除失败" };
                NLogUtil.WriteDBLog(LogLevel.Error, roleId, HttpStatusCode.InternalServerError, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }
            else
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = "删除成功" };
                NLogUtil.WriteDBLog(LogLevel.Info, roleId, HttpStatusCode.OK, LogType.Api, roleId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }
        }

    }
}
