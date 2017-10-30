using AmazonTool.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AmazonTool.DataAccess.Extensions
{
    public static class DbContextExtensions
    {
        public static DbSet<T> GetDbSet<T>(this DbContext context)
     where T : class, IEntity
        {
            //var typeOfContext = context.GetType();
            //var properties = typeOfContext.GetProperties();
            //var matchingProperty = properties.FirstOrDefault(a => a.PropertyType == typeof(DbSet<T>));
            //var valueOfIt = matchingProperty?.GetValue(context, null);
            //return (DbSet<T>)valueOfIt;




            var runtimeProps = context.GetType().GetRuntimeProperties();
            var isGeneric = runtimeProps.Where(o => o.PropertyType.IsGenericType &&
                    o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .FirstOrDefault();

            return (DbSet<T>)isGeneric?.GetValue(context, null);
        }
        /// <summary>
        /// Gets the build configuration by the context's connection string.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns the <see cref="BuildConfiguration"/> determined by the context's connection string.</returns>
        //public static BuildConfiguration GetBuildConfiguration(this DbContext context)
        //{
        //    var connectionString = context.Database.Connection.ConnectionString;
        //    if (connectionString.IndexOf(DbConstants.DEBUG_IDENTIFIER, StringComparison.OrdinalIgnoreCase) >= 0)
        //    {
        //        return BuildConfiguration.Debug;
        //    }

        //    // Default is release, since the database names in production are usually unknown to the developers
        //    return BuildConfiguration.Release;
        //}
    }
}
