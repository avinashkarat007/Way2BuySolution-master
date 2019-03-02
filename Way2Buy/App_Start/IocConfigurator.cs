﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Way2Buy.DataPersistenceLayer.Abstract;
using Way2Buy.DataPersistenceLayer.Concrete;
using Way2Buy.Infrastructure;

namespace Way2Buy.App_Start
{
    public class IocConfigurator
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new DemoUnityDependencyResolver(container));
            return container;
        }

        public static IUnityContainer BuildUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            RegisterServices(container);            
            return container;
        } 

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ICategoryRepository, EfCategoryRepository>();
            container.RegisterType<IProductRepository, EfProductRepository>();
        }
    }
}