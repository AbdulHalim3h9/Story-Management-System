using Autofac;
using ListeningRoom.Infrastructure.DbContexts;
using ListeningRoom.Infrastructure.Repositories;
using ListeningRoom.Infrastructure.Services;
using ListeningRoom.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningRoom.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();
            builder.RegisterType<StoryService>().As<IStoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StoryRepository>().As<IStoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
