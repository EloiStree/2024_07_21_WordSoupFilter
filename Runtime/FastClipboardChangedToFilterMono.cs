using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FastClipboardChangedToFilterMono : MonoBehaviour
{

    string m_previousText = "";
    public UnityEvent<string> m_onClipboardChanged;
    
    public float m_checkInterval = 0.1f;
    public bool m_useFastClipboardChangedToFilter = true;
    public void SetAsUsing(bool use)
    {
        m_useFastClipboardChangedToFilter = use;
    }
    public void Start()
    {
        m_previousText = GUIUtility.systemCopyBuffer;
        InvokeRepeating("CheckForChange", 0, m_checkInterval);

    }

    private void CheckForChange()
    {
        string t = GUIUtility.systemCopyBuffer;
        if (t != m_previousText)
        {
            m_previousText = t;
            m_onClipboardChanged.Invoke(t);
        }
    }
}
