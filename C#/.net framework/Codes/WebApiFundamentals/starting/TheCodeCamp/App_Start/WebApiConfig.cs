using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http.Versioning;
using Microsoft.Web.Http.Versioning.Conventions;
using Newtonsoft.Json.Serialization;
using TheCodeCamp.Controllers;

namespace TheCodeCamp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacConfig.Register();

            //版本控制 api-version=1.1
            config.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 1);
                cfg.AssumeDefaultVersionWhenUnspecified = true;//true请求时不需要在url 加默认的版本值 api-version=1.1
                cfg.ReportApiVersions = true;//响应头包含版本 api-supported-version
                cfg.ApiVersionReader =  ApiVersionReader.Combine(
                    new HeaderApiVersionReader("X-Version"),//从X-Version请求头中读取版本
                    new QueryStringApiVersionReader("ver")//ver url参数                                       
                                                            );//new UrlSegmentApiVersionReader();url版本控制   [RoutePrefix(api/v{version:apiVersion}/camps)]
                //单独代码配置不使用特性
                cfg.Conventions.Controller<TalksController>()
                    .HasApiVersion(1, 0)
                    .HasApiVersion(1, 1)
                    .Action(m => m.Get(default(string), default(int), default(bool)))
                    .MapToApiVersion(2, 0);

            });


            //字段改为驼峰命名规则
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            #region url版本控制
            //var constrainResolver = new DefaultInlineConstraintResolver()
            //{
            //    ConstraintMap =
            //    {
            //        ["apiVersion"] = typeof(ApiVersionRouteConstraint)
            //    }
            //};

            //// Web API routes
            //config.MapHttpAttributeRoutes(constrainResolver);
            #endregion


            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
