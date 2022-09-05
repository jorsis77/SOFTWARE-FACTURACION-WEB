using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MULTI.Models;
using MULTI.Util;
namespace MULTI.Services;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class TenantService
    {
        private TenantSettings tenantSettings;
        private HttpContext httpContext;
        private TenantData tenant;
        private string tenantCode;

        public TenantService(IOptions<TenantSettings> options, IHttpContextAccessor contextAccessor)
        {
            tenantSettings = options.Value;
            httpContext = contextAccessor.HttpContext;

            if (httpContext.Request.Cookies.TryGetValue("tenant-code", out string site) && tenantSettings.Sites.ContainsKey(site))
            {
                tenantCode = site;
                tenant = tenantSettings.Sites[site];
            }
        }

        public string GetConnectionString()
        {
            return tenant?.connectionString;
        }

        public string GetTenantCode()
        {
            return tenantCode;
        }

        public TenantData GetTenant()
        {
            return tenant;
        }
    }



