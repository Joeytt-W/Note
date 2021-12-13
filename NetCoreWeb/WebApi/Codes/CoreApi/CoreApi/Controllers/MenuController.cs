using AutoMapper;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Interfaces;
using Core.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entity.DBEntity;
using Core.Utility.LogHelper;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuService;
        private readonly IBase _baseService;
        private readonly IMapper _mapper;

        public MenuController(IMenuRepository menuService, IBase baseService, IMapper mapper)
        {
            _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));

            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 按ID获取菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenuById(Guid menuId)
        {
            try
            {
                if (menuId == Guid.Empty)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = "入参为空" };
                    NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var menu = _mapper.Map<MenuQueryDto>(await _menuService.GetMenuById(menuId));
                if (menu == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = "未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, menuId, HttpStatusCode.NotFound, LogType.Api, menuId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    Data = menu
                };
                NLogUtil.WriteDBLog(LogLevel.Info, menuId, HttpStatusCode.OK, LogType.Api, menuId.ToString(), JsonConvert.SerializeObject(returnValue));
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
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetMenus))]
        public async Task<IActionResult> GetMenus()
        {
            try
            {
                var menus = await _menuService.GetMenus();
                if (menus == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam()
                        {statusCode = HttpStatusCode.NotFound, Information = "未查询到数据"};
                    NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, string.Empty,
                        JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    TotalCount = menus.Count,
                    Data = _mapper.Map<IEnumerable<MenuQueryDto>>(menus)
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, string.Empty,
                    JsonConvert.SerializeObject(returnValue));
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
        /// 创建菜单
        /// </summary>
        /// <param name="menuAddDto"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateMenu))]
        public async Task<IActionResult> CreateMenu(MenuAddDto menuAddDto)
        {
            if (menuAddDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                var menu = _mapper.Map<Menu>(menuAddDto);
                await _menuService.AddMenuAsync(menu, false);
                if (await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.Created, Information = $"新增成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, menu.ID, HttpStatusCode.Created, LogType.Api, JsonConvert.SerializeObject(menuAddDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"新增失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, menu.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(menuAddDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
            }
            catch (Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="menuUpdateDto"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateMenu))]
        public async Task<IActionResult> UpdateMenu(MenuUpdateDto menuUpdateDto)
        {
            if (menuUpdateDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                if (!await _menuService.ExistsAsync(menuUpdateDto.ID))
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"菜单不存在" };
                    NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, JsonConvert.SerializeObject(menuUpdateDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var menu = _mapper.Map<Menu>(menuUpdateDto);
                await _menuService.UpdateMenuAsync(menu, false);

                if (await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = $"修改成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, menuUpdateDto.ID, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(menuUpdateDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"修改失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, menuUpdateDto.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(menuUpdateDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
            }
            catch (Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, menuUpdateDto.ID, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpDelete("{menuId}")]
        public async Task<IActionResult> DeleteMenu(Guid menuId)
        {
            if (menuId == Guid.Empty)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                if (!await _menuService.ExistsAsync(menuId))
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"部门不存在" };
                    NLogUtil.WriteDBLog(LogLevel.Error, menuId, HttpStatusCode.NotFound, LogType.Api, menuId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                await _menuService.DeleteMenu(menuId, false);
                if (!await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"删除失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, menuId, HttpStatusCode.InternalServerError, LogType.Api, menuId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = $"删除成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, menuId, HttpStatusCode.OK, LogType.Api, menuId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
            }
            catch (Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, menuId, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }
    }
}
