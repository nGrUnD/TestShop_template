using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TooltipView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private CanvasGroup canvasGroup;

    private Sequence _sequence;

    private void Start()
    {
        gameObject.SetActive(false);
        AnimateHide();
    }

    private void Update()
    {
        SetPositionOnMouse();
    }

    public void Show()
    {
        AnimateShow();
    }

    public void Hide()
    {
        AnimateHide();
    }

    public void SetNameText(string value)
    {
        nameText.text = value;
    }

    public void SetPriceText(string value)
    {
        priceText.text = value;
    }

    public void SetDescriptionText(string value)
    {
        descriptionText.text = value;
    }

    private void SetPositionOnMouse()
    {
        transform.position = Input.mousePosition;
    }

    private void AnimateShow()
    {
        if (_sequence != null && _sequence.IsActive())
        {
            _sequence.Kill();
        }

        gameObject.SetActive(true);
        
        _sequence = DOTween.Sequence();
        _sequence.Append(canvasGroup.DOFade(1f, 0.2f));
    }

    private void AnimateHide()
    {
        if (_sequence != null && _sequence.IsActive())
        {
            _sequence.Kill();
        }

        _sequence = DOTween.Sequence();
        _sequence
            .Append(canvasGroup.DOFade(0f, 0.2f))
            .OnComplete(() => { gameObject.SetActive(false); });
    }
}