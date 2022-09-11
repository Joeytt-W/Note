using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using Microsoft.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{   
    //支持两个版本
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [RoutePrefix("api/camps")]
    public class CampsController : ApiController
    {
        private readonly ICampRepository _resRepository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository resRepository,IMapper mapper)

        {
            _resRepository = resRepository;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get(bool includeTalks = false)
        {
            try
            {
                var result = await _resRepository.GetAllCampsAsync(includeTalks);

                var mapperResult = _mapper.Map<IEnumerable<CampModel>>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [MapToApiVersion("1.1")]//Version to Action
        [Route("{moniker}",Name = "GetCamp")]
        public async Task<IHttpActionResult> Get(string moniker, bool includeTalks = false)
        {
            try
            {
                var result = await _resRepository.GetCampAsync(moniker, includeTalks);

                if (result == null)
                    return NotFound();

                var mapperResult = _mapper.Map<CampModel>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [MapToApiVersion("1.0")]
        [Route("{moniker}", Name = "GetCamp2")]
        public async Task<IHttpActionResult> Get(string moniker)
        {
            try
            {
                var result = await _resRepository.GetCampAsync(moniker);

                if (result == null)
                    return NotFound();

                var mapperResult = _mapper.Map<CampModel>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("searchByDate/{eventDate:datetime}")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByEventDate(DateTime eventDate, bool includeTalks = false)
        {
            try
            {
                var result = await _resRepository.GetAllCampsByEventDate(eventDate, includeTalks);

                var mapperResult = _mapper.Map<IEnumerable<CampModel>>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route()]
        public async Task<IHttpActionResult> Post(CampModel model)
        {
            try
            {
                if (await _resRepository.GetCampAsync(model.Moniker) != null)
                {
                    //return BadRequest("Moniker has been used");
                    ModelState.AddModelError("Moniker", "Moniker has been used");
                }

                if (ModelState.IsValid)
                {
                    var camp = _mapper.Map<Camp>(model);

                    _resRepository.AddCamp(camp);
                    if (await _resRepository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<CampModel>(camp);

                        //var location = Url.Link("GetCamp", new { moniker = newModel.Moniker });
                        //return Created(location, newModel);
                        return CreatedAtRoute("GetCamp", new { moniker = newModel.Moniker }, newModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
            //{
            //    "message": "The request is invalid.",
            //    "modelState": {
            //        "model.Moniker": [
            //        "Moniker 字段是必需的。"
            //            ],
            //        "model.Length": [
            //        "字段 Length 必须在 1 和 30 之间。"
            //            ]
            //    }
            //}
        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Put(string moniker,CampModel model)
        {
            try
            {
                var camp = await _resRepository.GetCampAsync(moniker);
                if (camp == null)
                    return NotFound();

                _mapper.Map(model, camp);//update

                if (await _resRepository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<CampModel>(camp));
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Delete(string moniker)
        {
            try
            {
                var camp = await _resRepository.GetCampAsync(moniker);
                if (camp == null)
                    return NotFound();

                _resRepository.DeleteCamp(camp);

                if (await _resRepository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
