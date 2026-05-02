using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jysk.BLL.Infrastructure
{
    public static class JyskContextExtensions
    {
        public static void AddJyskContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<JyskContext>(options => options.UseSqlServer(connection));
        }
    }
}
