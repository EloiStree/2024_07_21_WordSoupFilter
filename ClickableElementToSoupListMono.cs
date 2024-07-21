using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableElementToSoupListMono : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<string> m_onTextSet;
    public UnityEvent<string> m_onTextClicked;
    public string m_textStored;
    public bool m_flushOnClick = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        m_onTextClicked.Invoke(m_textStored);
        if (m_flushOnClick)
        {
            SetText("");
        }
    }

    public void SetText(string text)
    {
        m_textStored = text;
        m_onTextSet.Invoke(text);
    }

    public string GetText()
    {
        return m_textStored;
    }

    private void Start()
    {
        SetText(m_textStored);
    }

}
