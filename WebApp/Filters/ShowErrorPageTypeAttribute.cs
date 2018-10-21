using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Filters
{
    public class ShowErrorPageTypeAttribute : TypeFilterAttribute
    {
        public ShowErrorPageTypeAttribute() : base(typeof(ShowErrorPageAttribute))
        {
        }
    }
}