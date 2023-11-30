using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopItems : MonoBehaviour
{
    private UIDocument _document;
    private List<VisualElement> shopItems;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        
        shopItems = _document.rootVisualElement.Query(className: "buttonWrapper").ToList();
        
        foreach (var item in shopItems)
        {
            item.RegisterCallback<MouseEnterEvent>(evt => OnMouseEnter(item));
            item.RegisterCallback<MouseLeaveEvent>(evt => OnMouseLeave(item));
        }
    }
    
    private void OnMouseEnter(VisualElement item)
    {
        foreach (var shopItem in shopItems)
        {
            shopItem.RemoveFromClassList("active");
        }
        
        item.AddToClassList("active");
    }
    
    private void OnMouseLeave(VisualElement item)
    {
        if (item.ClassListContains("active"))
        {
            item.RemoveFromClassList("active");
        }
    }
}
