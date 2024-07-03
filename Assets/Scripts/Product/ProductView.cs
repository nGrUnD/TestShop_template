using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ProductView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnPointerEnterEvent;
    public event Action OnPointerExitEvent;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke();
    }
    
    public void SetNameText(string value)
    {
        nameText.text = value;
    }

    public void SetPriceText(string value)
    {
        priceText.text = value;
    }
    
    public void SetIconSprite(Sprite icon)
    {
        iconImage.sprite = icon;
    }
}