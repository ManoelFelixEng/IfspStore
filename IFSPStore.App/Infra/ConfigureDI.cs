using AutoMapper;
using IFSPStore.App.Others;
using IFSPStore.App.Register;
using IFSPStore.App.ViewModel;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using IFSPStore.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace IFSPStore.App.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection services;
        public static IServiceProvider? serviceProvider;

        public static void ConfigureServices()
        {
            // Database config
            var dbConfigFile = "Config/DBConfig.txt";
            var strCon = File.ReadAllText(dbConfigFile);
            services = new ServiceCollection();
            services.AddDbContext<IFSPStoreContext>(
                options =>
                {
                    options.LogTo(Console.WriteLine);
                    options.UseMySQL(strCon); 
                }
            );

            #region Repositories
            services.AddScoped<IBaseRepository<Sale>, BaseRepository<Sale>>();
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<City>, BaseRepository<City>>();
            services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();

            #endregion

            #region Services

            services.AddScoped<IBaseService<Category>, BaseService<Category>>();
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddScoped<IBaseService<City>, BaseService<City>>();
            services.AddScoped<IBaseService<Customer>, BaseService<Customer>>();
            services.AddScoped<IBaseService<Sale>, BaseService<Sale>>();
            services.AddScoped<IBaseService<Product>, BaseService<Product>>();

            #endregion

            #region Forms
            services.AddScoped<SaleForm, SaleForm>(); 
            services.AddTransient<Login, Login>();
            services.AddScoped<CategoryForm, CategoryForm>();
            services.AddScoped<UserForm, UserForm>();
            services.AddScoped<CityForm, CityForm>();
            services.AddScoped<CustomerForm, CustomerForm>();

            #endregion

            #region Mappings
            services.AddSingleton(
                new MapperConfiguration(
                    config => {
                        config.CreateMap<Sale, SaleViewModel>();
                        config.CreateMap<Product, ProductViewModel>();
                        config.CreateMap<Category, CategoryViewModel>();
                        config.CreateMap<User, UserViewModel>();
                        config.CreateMap<City, CityViewModel>();
                        config.CreateMap<Customer, CustomerViewModel>();
                    },
                    NullLoggerFactory.Instance).CreateMapper()
                );

            #endregion

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
