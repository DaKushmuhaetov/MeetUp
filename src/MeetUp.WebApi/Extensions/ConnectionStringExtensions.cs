using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Extensions
{
    internal static class ConnectionStringExtensions
    {
        public static string AppendApplicationName(string connectionString)
        {
            var builder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            if (string.IsNullOrEmpty(builder.ApplicationName))
            {
                var @namespace = typeof(ConnectionStringExtensions).Namespace;
                builder.ApplicationName = @namespace.Remove(@namespace.LastIndexOf('.'));
            }

            return builder.ConnectionString;
        }
    }
}
