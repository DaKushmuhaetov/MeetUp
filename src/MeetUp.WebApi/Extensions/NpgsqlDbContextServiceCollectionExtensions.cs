﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Extensions
{
    internal static class NpgsqlDbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddNpgsqlDbContextPool<TContext>(this IServiceCollection services,
            string connectionString)
            where TContext : DbContext
        {
            return services.AddDbContextPool<TContext>(
                opts => { opts.UseNpgsql(ConnectionStringExtensions.AppendApplicationName(connectionString)); });
        }

        public static IServiceCollection AddNpgsqlDbContext<TContext>(this IServiceCollection services,
            string connectionString)
            where TContext : DbContext
        {
            return services.AddDbContext<TContext>(
                opts => { opts.UseNpgsql(ConnectionStringExtensions.AppendApplicationName(connectionString)); });
        }
    }
}
