using Zenject;

public class ShopProductsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IProductService>().To<ProductService>().AsSingle();
        Container.Bind<ProductPresenter>().AsSingle().NonLazy();
        Container.Bind<ShopProductsView>().FromComponentInHierarchy().AsSingle();
    }
}