using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Hepler;
using Core.Service.Interfaces;
using Core.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Utility.LogHelper;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IRoleUserRepository _roleUserService;
        private readonly IDepartmentRepository _departmentService;
        private readonly IRoleRepository _roleService;
        private readonly IWriteLog _writeLog;
        private readonly IMapper _mapper;
        private readonly IBase _baseService;

        public UserController(IUserRepository userService, IMapper mapper, IRoleUserRepository roleUserService, IBase BaseService, IDepartmentRepository DepartmentService, IRoleRepository RoleService,IWriteLog writeLog)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            _roleUserService = roleUserService ?? throw new ArgumentNullException(nameof(roleUserService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _baseService = BaseService ?? throw new ArgumentNullException(nameof(BaseService));

            _departmentService = DepartmentService ?? throw new ArgumentNullException(nameof(DepartmentService));

            _roleService = RoleService ?? throw new ArgumentNullException(nameof(RoleService));

            _writeLog = writeLog ?? throw new ArgumentNullException(nameof(writeLog));
        }

        /// <summary>
        /// 根据ID查询user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns> 
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"用户Id为空" };
                //NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                _writeLog.WriteDBLog(LogLevel.Error, HttpStatusCode.BadRequest, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }
            try
            {
                var user = _mapper.Map<UserQueryDto>(await _userService.GetUserAsyncById(userId));
                if (user == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    _writeLog.WriteDBLog(LogLevel.Info, HttpStatusCode.NotFound, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                    return NotFound(noneExecuteOutParam);
                }
                user.Department = _mapper.Map<DepartmentQueryDto>(await _departmentService.GetDepartmentById(user.DepartmentID));
                var userRoles = await _roleUserService.GetUserRoleByUserIDAsync(user.ID);
                var roles = await _roleService.GetRoles();
                roles = roles.Where(x => userRoles.Any(y => y.RoleID == x.ID)).ToList();
                user.Roles = new List<RoleQueryDto>();
                if (roles != null)
                {
                    user.Roles = _mapper.Map<IEnumerable<RoleQueryDto>>(roles);
                }

                _writeLog.WriteDBLog(LogLevel.Info, HttpStatusCode.OK, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(user), userId.ToString());

                return Ok(new { statusCode = HttpStatusCode.OK, Information = "查询成功", Data = user });
            }
            catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                _writeLog.WriteDBLog(LogLevel.Error, HttpStatusCode.InternalServerError, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 获取所需用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetUsers))]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryParam userQueryParam)
        {
            
            //var paginationMetadata = new
            //{
            //    totalCount = items.TotalCount,
            //    pageSize = items.PageSize,
            //    currentPage = items.CurrentPage,
            //    totalPages = items.TotalPages
            //};
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
            try
            {
                var items = await _userService.GetUsersAsync(userQueryParam);

                if (items == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, JsonConvert.SerializeObject(userQueryParam), JsonConvert.SerializeObject(noneExecuteOutParam));

                    return NotFound(noneExecuteOutParam);
                }
                var userList = (List<UserQueryDto>)_mapper.Map<IEnumerable<UserQueryDto>>(items.AsEnumerable());
                foreach (var item in userList)
                {
                    item.Department = _mapper.Map<DepartmentQueryDto>(await _departmentService.GetDepartmentById(item.DepartmentID));
                    var userRoles = await _roleUserService.GetUserRoleByUserIDAsync(item.ID);
                    var roles = await _roleService.GetRoles();
                    roles = roles.Where(x => userRoles.Any(y => y.RoleID == x.ID)).ToList();
                    item.Roles = new List<RoleQueryDto>();
                    if (roles != null)
                    {
                        item.Roles = _mapper.Map<IEnumerable<RoleQueryDto>>(roles);
                    }
                }


                var executeParam = new ExecuteParam<UserQueryDto>()
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    data = new Inparam<UserQueryDto>()
                    {
                        TotalCount = items.TotalCount,
                        PageSize = items.PageSize,
                        CurrentPage = items.CurrentPage,
                        TotalPages = items.TotalPages,
                        dataList = userList
                    }
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(userQueryParam), JsonConvert.SerializeObject(executeParam));

                return Ok(executeParam);
            }catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(userQueryParam), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userAddDto">用户信息</param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateUser))]
        public async Task<IActionResult> CreateUser(UserAddDto userAddDto)
        {
            var nonExecuteOutParam = new NonExecuteOutParam();
            var KeyId = Guid.Empty;
            if (userAddDto == null)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = "入参为空" };

                NLogUtil.WriteDBLog(LogLevel.Warn, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, JsonConvert.SerializeObject(userAddDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                return BadRequest(nonExecuteOutParam);
            }
            try
            {
                var user = _mapper.Map<User>(userAddDto);
                var newUser = await _userService.AddUserAsync(user, false);

                KeyId = newUser.ID;
                //添加角色
                if (!userAddDto.RoldIDs.Count.Equals(0))
                {
                    foreach (var id in userAddDto.RoldIDs)
                    {
                        await _roleUserService.AddRoleUserAsync(new RoleUser()
                        {
                            RoleID = id,
                            UserID = KeyId,
                            CreateTime = DateTime.Now,
                            CreateUser = user.CreateUser
                        }, false);
                    }
                }

                if (!await _baseService.SaveAsync())
                {
                    nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = "添加失败" };

                    NLogUtil.WriteDBLog(LogLevel.Error, KeyId, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(userAddDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                    return BadRequest(nonExecuteOutParam);
                }


                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.Created, Information = "添加用户成功" };

                NLogUtil.WriteDBLog(LogLevel.Info, KeyId, HttpStatusCode.Created, LogType.Api, JsonConvert.SerializeObject(userAddDto), JsonConvert.SerializeObject(nonExecuteOutParam));

                return Ok(nonExecuteOutParam);
            }
            catch (Exception ex)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常:{ex.ToString()}" };

                NLogUtil.WriteDBLog(LogLevel.Error, KeyId, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(userAddDto), JsonConvert.SerializeObject(nonExecuteOutParam));

                return BadRequest(nonExecuteOutParam);
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userUpdateDto">用户信息</param>
        /// <returns></returns>
        [HttpPut(Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var nonExecuteOutParam = new NonExecuteOutParam();
            if (userUpdateDto == null)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = "入参为空" };

                NLogUtil.WriteDBLog(LogLevel.Warn, userUpdateDto.ID, HttpStatusCode.BadRequest, LogType.Api, JsonConvert.SerializeObject(userUpdateDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                return BadRequest(nonExecuteOutParam);
            }
            try
            {
                if (!await _userService.ExistsAsync(userUpdateDto.ID))
                {

                    nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = "用户不存在" };

                    NLogUtil.WriteDBLog(LogLevel.Warn, userUpdateDto.ID, HttpStatusCode.NotFound, LogType.Api, JsonConvert.SerializeObject(userUpdateDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                    return NotFound(nonExecuteOutParam);
                }

                var updateUser = _mapper.Map<User>(userUpdateDto);
                await _userService.UpdateUserAsync(updateUser, false);
                //角色
                if (!userUpdateDto.RoldIDs.Count.Equals(0))
                {
                    var item = await _roleUserService.GetUserRoleByUserIDAsync(userUpdateDto.ID);

                    await _roleUserService.DeleteRoleUserAsync(item, false);

                    foreach (var id in userUpdateDto.RoldIDs)
                    {
                        await _roleUserService.AddRoleUserAsync(new RoleUser()
                        {
                            RoleID = id,
                            UserID = userUpdateDto.ID,
                            CreateTime = DateTime.Now,
                            CreateUser = userUpdateDto.UpdateUser
                        }, false);
                    }
                }

                if (!await _baseService.SaveAsync())
                {
                    nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = "修改失败" };

                    NLogUtil.WriteDBLog(LogLevel.Error, userUpdateDto.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(userUpdateDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                    return BadRequest(nonExecuteOutParam);
                }

                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = "修改成功" };

                NLogUtil.WriteDBLog(LogLevel.Info, userUpdateDto.ID, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(userUpdateDto), JsonConvert.SerializeObject(nonExecuteOutParam));
                return Ok(nonExecuteOutParam);
            }
            catch (Exception ex)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常:{ex.ToString()}" };

                NLogUtil.WriteDBLog(LogLevel.Error, userUpdateDto.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(userUpdateDto), JsonConvert.SerializeObject(nonExecuteOutParam));

                return BadRequest(nonExecuteOutParam);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var nonExecuteOutParam = new NonExecuteOutParam();
            if (userId == Guid.Empty)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = "入参为空" };

                NLogUtil.WriteDBLog(LogLevel.Warn, userId, HttpStatusCode.BadRequest, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(nonExecuteOutParam));
                return BadRequest(nonExecuteOutParam);
            }

            try
            {
                if (!await _userService.ExistsAsync(userId))
                {
                    nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = "用户不存在" };

                    NLogUtil.WriteDBLog(LogLevel.Warn, userId, HttpStatusCode.NotFound, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(nonExecuteOutParam));
                    return NotFound(nonExecuteOutParam);
                }

                var items = await _roleUserService.GetUserRoleByUserIDAsync(userId);

                await _roleUserService.DeleteRoleUserAsync(items, false);

                await _userService.DeleteUserAsync(userId, false);

                if (!await _baseService.SaveAsync())
                {
                    nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = "删除用户失败" };

                    NLogUtil.WriteDBLog(LogLevel.Error, userId, HttpStatusCode.InternalServerError, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(nonExecuteOutParam));
                    return BadRequest(nonExecuteOutParam);
                }

                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = "删除成功" };

                NLogUtil.WriteDBLog(LogLevel.Info, userId, HttpStatusCode.OK, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(nonExecuteOutParam));
                return Ok(nonExecuteOutParam);
            }
            catch (Exception ex)
            {
                nonExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常:{ex.ToString()}" };

                NLogUtil.WriteDBLog(LogLevel.Error, userId, HttpStatusCode.InternalServerError, LogType.Api, userId.ToString(), JsonConvert.SerializeObject(nonExecuteOutParam));

                return BadRequest(nonExecuteOutParam);
            }
        }

    }
}
