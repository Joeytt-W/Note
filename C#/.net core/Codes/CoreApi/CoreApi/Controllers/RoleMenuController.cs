using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Interfaces;
using Core.Utility;
using Core.Utility.LogHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/RoleMenus")]
    public class RoleMenuController:ControllerBase
    {
        private readonly IRoleMenuRepository _roleMenuService;

        public RoleMenuController(IRoleMenuRepository roleMenuService)
        {
            _roleMenuService = roleMenuService ?? throw new ArgumentNullException(nameof(roleMenuService));
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(CreateRoleMenus))]
        public async Task<IActionResult> CreateRoleMenus(RoleMenuAddDto roleMenuAddDto)
        {
            try
            {
                if (await _roleMenuService.CreateRoleMenuAsync(roleMenuAddDto))
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = $"授权成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, roleMenuAddDto.RoleId, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(roleMenuAddDto), JsonConvert.SerializeObject(noneExecuteOutParam));

                    return Ok(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"授权失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, roleMenuAddDto.RoleId, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(roleMenuAddDto), JsonConvert.SerializeObject(noneExecuteOutParam));

                    return BadRequest(noneExecuteOutParam);
                }
            }
            catch (Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(roleMenuAddDto), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }
    }
}
