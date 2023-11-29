using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonClicker : MonoBehaviour
{
    private UIDocument document;
    private Button button;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        
        button = document.rootVisualElement.Q<Button>("Play");

        Debug.Log(button);
        
        button.RegisterCallback<ClickEvent>(OnButtonClick);
    }
    
    private void OnButtonClick(ClickEvent evt)
    {
        Debug.Log("Button clicked!");
    }
}
