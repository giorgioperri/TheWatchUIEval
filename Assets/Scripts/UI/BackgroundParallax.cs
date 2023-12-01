using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This script is responsible for the parallax effect on the background.
/// It uses the mouse position to calculate the parallax effect.
/// </summary>

public class BackgroundParallax : MonoBehaviour
{

    private UIDocument _uiDocument;
    private VisualElement _parallaxItem;

    public bool Inverted;
    public int InverseParallaxSpeed;
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _parallaxItem = _uiDocument.rootVisualElement.Query(className: "parallax");
    }

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
       _parallaxItem.style.translate = Inverted 
           ? new Translate(mousePos.x / InverseParallaxSpeed, -mousePos.y / InverseParallaxSpeed)
              : new Translate(-mousePos.x / InverseParallaxSpeed, mousePos.y / InverseParallaxSpeed);
    }
}
