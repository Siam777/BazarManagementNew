using app.Entities.Models;
using app.Service;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;

using Unity;
using Unity.AspNet.Mvc;

namespace erp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container
                .RegisterType<IDataContextAsync, AppContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IStoredProcedures, AppContext>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<UserInfo>, Repository<UserInfo>>()
                .RegisterType<IUserInfoService, UserInfoService>()
                .RegisterType<IRepositoryAsync<Image>, Repository<Image>>()
                .RegisterType<IImageService, ImageService>()
                .RegisterType<IRepositoryAsync<MonthlyActivatedUser>, Repository<MonthlyActivatedUser>>()
                .RegisterType<IMonthlyActivatedUserService, MonthlyActivatedUserService>()
                .RegisterType<IRepositoryAsync<BazarExpense>, Repository<BazarExpense>>()
                .RegisterType<IBazarExpenseService,BazarExpenseService>()
                .RegisterType<IRepositoryAsync<BazarType>, Repository<BazarType>>()
                .RegisterType<IBazarTypeService, BazarTypeService>()
                .RegisterType<IRepositoryAsync<CollectionForBazarAndInstallation>, Repository<CollectionForBazarAndInstallation>>()
                .RegisterType<ICollectionForBazarAndInstallationService, CollectionForBazarAndInstallationService>()
                .RegisterType<IRepositoryAsync<MealManagement>, Repository<MealManagement>>()
                .RegisterType<IMealManagementService, MealManagementService>();
        }
    }
}