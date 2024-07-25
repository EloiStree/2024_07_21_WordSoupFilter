using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoupTextAreaToUnityEventMono : MonoBehaviour
{
    [TextArea(5,10)]
    public string m_text;
    public UnityEvent<string > m_onChange;


    [ContextMenu("Push")]
    public void Push()
    {
        m_onChange.Invoke(m_text);
    }
    [ContextMenu("Push and clear")]
    public void PushAndClear()
    {
        m_onChange.Invoke(m_text);
        m_text = "";
    }
}
