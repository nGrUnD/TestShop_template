using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopProductsView : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ProductView productViewPrefab;
    [SerializeField] private GameObject loadingIndicator;

    private List<ProductView> _productViews = new();

    public void ShowLoading()
    {
        loadingIndicator.SetActive(true);
    }

    public void HideLoading()
    {
        loadingIndicator.SetActive(false);
    }

    public void AddProductView(Chair productModel, TooltipView tooltipView)
    {
        var filename = productModel.filename.Split(".");
        var spriteIcon = Resources.Load<Sprite>($"Images/{filename[0]}");
        var productView = Instantiate(productViewPrefab, content);
        productView.SetNameText(productModel.name);
        productView.SetPriceText($"${productModel.price}");
        productView.SetIconSprite(spriteIcon);
        _productViews.Add(productView);
        
        productView.OnPointerEnterEvent += () =>
        {
            tooltipView.SetNameText(productModel.name);
            tooltipView.SetPriceText($"${productModel.price}");
            tooltipView.SetDescriptionText(productModel.description);
            tooltipView.Show(); 
        };
        productView.OnPointerExitEvent += () => { tooltipView.Hide(); };
        
    }
}