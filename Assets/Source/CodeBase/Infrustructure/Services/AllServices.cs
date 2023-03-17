namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public class AllServices
    {
        private readonly AllServices _instance;

        public AllServices Container => _instance;

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.Instance = implementation;
        }

        public TService Get<TService>() where TService : IService
        {
            return Implementation<TService>.Instance;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService Instance;
        }
    }

}