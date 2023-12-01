using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
///  This script is responsible for the timer decrease effect.
/// </summary>

public class TimerDecrease : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Label _timerText;
    private string _originalValue;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _timerText = _uiDocument.rootVisualElement.Q(className: "timer") as Label;
        _originalValue = _timerText.text;

        Debug.Log(_originalValue);
        
        //this is of course a placeholder value for mockup purposes
        var time = TimeSpan.FromSeconds(60152);
        _timerText.text = time.ToString(@"hh\:mm\:ss");
        
        StartCoroutine(DecreaseTimer());
    }
    
    private IEnumerator DecreaseTimer()
    {
        var time = TimeSpan.Parse(_timerText.text);
        
        while (time.TotalSeconds > 0)
        {
            time = time.Subtract(TimeSpan.FromSeconds(1));
            _timerText.text = time.ToString(@"hh\:mm\:ss");
            yield return new WaitForSeconds(1);
        }
    }
    
}
