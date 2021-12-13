using AutoMapper;
using Core.Entity.DBEntity;
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
using Core.Utility.LogHelper;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentService;
        private readonly IBase _baseService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentService,IBase baseService, IMapper mapper)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 按ID查询部门
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        [HttpGet("{deptId}")]
        public async Task<IActionResult> GetDepartmentById(Guid deptId)
        {
            try
            {
                if (deptId == Guid.Empty)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = "入参为空" };
                    NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var department = await _departmentService.GetDepartmentById(deptId);

                if (department == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, deptId, HttpStatusCode.NotFound, LogType.Api, deptId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return NotFound(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    Data = _mapper.Map<DepartmentQueryDto>(department)
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, string.Empty, JsonConvert.SerializeObject(returnValue));
                return Ok(returnValue);

            }
            catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, deptId, HttpStatusCode.InternalServerError, LogType.Api, deptId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 查询部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetDepartments))]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _departmentService.GetDepartments();

                if (departments == null)
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"未查询到数据" };
                    NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                    return NotFound(noneExecuteOutParam);
                }

                var returnValue = new
                {
                    statusCode = HttpStatusCode.OK,
                    Information = "查询完成",
                    TotalCount = departments.Count,
                    Data = _mapper.Map<IEnumerable<DepartmentQueryDto>>(departments)
                };

                NLogUtil.WriteDBLog(LogLevel.Info, Guid.Empty, HttpStatusCode.OK, LogType.Api, string.Empty, JsonConvert.SerializeObject(returnValue));
                return Ok(returnValue);
            }catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="departmentDto">实体</param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateDepartment))]
        public async Task<IActionResult> CreateDepartment(DepartmentAddDto departmentDto)
        {
            if (departmentDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                var department = _mapper.Map<Department>(departmentDto);
                await _departmentService.AddDepartmentAsync(department,false);
                if (await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.Created, Information = $"新增成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, department.ID, HttpStatusCode.Created, LogType.Api, JsonConvert.SerializeObject(departmentDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"新增失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, department.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(departmentDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
            }catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="departmentDto">实体</param>
        /// <returns></returns>
        [HttpPut(Name = nameof(UpdateDepartment))]
        public async Task<IActionResult> UpdateDepartment(DepartmentUpdateDto departmentDto)
        {
            if (departmentDto == null)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                if (!await _departmentService.ExistsAsync(departmentDto.ID))
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"部门不存在" };
                    NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.NotFound, LogType.Api, JsonConvert.SerializeObject(departmentDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                var department = _mapper.Map<Department>(departmentDto);
                await _departmentService.UpdateDepartmentAsync(department,false);

                if (await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = $"修改成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, departmentDto.ID, HttpStatusCode.OK, LogType.Api, JsonConvert.SerializeObject(departmentDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"修改失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, departmentDto.ID, HttpStatusCode.InternalServerError, LogType.Api, JsonConvert.SerializeObject(departmentDto), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
            }catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, departmentDto.ID, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="deptId">ID</param>
        /// <returns></returns>
        [HttpDelete("{deptId}")]
        public async Task<IActionResult> DeleteDepartment(Guid deptId)
        {
            if (deptId == Guid.Empty)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.BadRequest, Information = $"入参为空" };
                NLogUtil.WriteDBLog(LogLevel.Error, Guid.Empty, HttpStatusCode.BadRequest, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));
                return BadRequest(noneExecuteOutParam);
            }

            try
            {
                if (!await _departmentService.ExistsAsync(deptId))
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.NotFound, Information = $"部门不存在" };
                    NLogUtil.WriteDBLog(LogLevel.Error, deptId, HttpStatusCode.NotFound, LogType.Api, deptId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }

                await _departmentService.DeleteDepartmentAsync(deptId,false);
                if (!await _baseService.SaveAsync())
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"删除失败" };
                    NLogUtil.WriteDBLog(LogLevel.Error, deptId, HttpStatusCode.InternalServerError, LogType.Api, deptId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return BadRequest(noneExecuteOutParam);
                }
                else
                {
                    var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.OK, Information = $"删除成功" };
                    NLogUtil.WriteDBLog(LogLevel.Info, deptId, HttpStatusCode.OK, LogType.Api, deptId.ToString(), JsonConvert.SerializeObject(noneExecuteOutParam));
                    return Ok(noneExecuteOutParam);
                }
            }catch(Exception ex)
            {
                var noneExecuteOutParam = new NonExecuteOutParam() { statusCode = HttpStatusCode.InternalServerError, Information = $"操作出现异常,{ex.ToString()}" };
                NLogUtil.WriteDBLog(LogLevel.Error, deptId, HttpStatusCode.InternalServerError, LogType.Api, string.Empty, JsonConvert.SerializeObject(noneExecuteOutParam));

                return BadRequest(noneExecuteOutParam);
            }
        }
    }
}
