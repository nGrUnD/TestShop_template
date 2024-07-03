using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ProductPresenter
{
    private readonly ShopProductsView _shopProductsView;
    private readonly IProductService _productService;
    private readonly TooltipView _tooltipView;

    private List<Chair> _productList = new();

    [Inject]
    public ProductPresenter(ShopProductsView shopProductsView, IProductService productService, TooltipView tooltipView)
    {
        _shopProductsView = shopProductsView;
        _productService = productService;
        _tooltipView = tooltipView;

        Debug.Log("Initialize");
        _ = Initialize();
    }

    public async UniTaskVoid Initialize()
    {
        Debug.Log("ShowLoading");
        _shopProductsView.ShowLoading();    

        _productList = await _productService.GetProductsAsync();;
        foreach (var product in _productList)
        {
            _shopProductsView.AddProductView(product, _tooltipView);
        }

        _shopProductsView.HideLoading();
        Debug.Log("HideLoading");
    }
}