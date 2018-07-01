﻿using Unity;
using Unity.Lifetime;
using Unity.Extension;

namespace POS.BLogic
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();

        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        public static void InjectStub<I>(I instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        public static void AddExtension<T>() where T : UnityContainerExtension
        {
            UnityContainer.AddNewExtension<T>();
        }
    }
}
