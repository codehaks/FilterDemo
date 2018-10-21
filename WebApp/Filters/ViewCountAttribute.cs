using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Filters
{
    public class ViewCountAttribute : Attribute, IAsyncResultFilter
    {
        private readonly AppDbContext _db;

        public ViewCountAttribute(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Before - Executing
            await next();
            var id = Convert.ToInt32(context.RouteData.Values["id"]);
            var movie = _db.Movies.Find(id);
            movie.ViewCount++;
            await _db.SaveChangesAsync();
        }
    }
}