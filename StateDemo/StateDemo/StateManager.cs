using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateDemo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateDemo.Controllers
{
    public class StateManager
    {
        const string StatusMessageKey = "Message";
        const string CompanyNameKey = "CompanyName";
        const string SupportEmailKey = "SupportEmail";

        public string StatusMessage
        {
            get { return controller.TempData[StatusMessageKey]?.ToString(); }
            set { controller.TempData[StatusMessageKey] = value; }
        }

        public string CompanyName
        {
            get { return controller.HttpContext.Session.GetString(CompanyNameKey); }
            set { controller.HttpContext.Session.SetString(CompanyNameKey, value); }
        }
        public string SupportEmail
        {
            get { return cache.Get(SupportEmailKey)?.ToString(); }
            set { cache.Set(SupportEmailKey, value); }
        }

        Controller controller;
        IMemoryCache cache;
        public StateManager(Controller controller, IMemoryCache cache)
        {
            this.controller = controller;
            this.cache = cache;
        }
    }
}
