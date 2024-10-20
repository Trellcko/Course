using System;

namespace CodeBase.Infastructure
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance => _instance ?? (_instance = new());

        private static ServiceLocator _instance;

        public void RegisterSingle<TService>(TService gameFactory) where TService : IService 
            => Implemention<TService>.ServiceInstance = gameFactory;

        public TService Single<TService>() where TService : IService 
            => Implemention<TService>.ServiceInstance;

        public static class Implemention<TService>  where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
