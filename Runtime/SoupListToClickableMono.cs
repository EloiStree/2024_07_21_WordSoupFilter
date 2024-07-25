using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoupListToClickableMono : MonoBehaviour
{
    public SoupStringListMono m_toLoad;
    public List<ClickableElementToSoupListMono> m_clickables;


    public UnityEvent<string> m_onFlushWordsInClickable;
    public UnityEvent<string> m_onListSizeRefresh;

    [ContextMenu("Load from list")]
    public void LoadElementOfList() {
        int count = m_clickables.Count;
        for (int i = 0; i < count; i++) {
            m_clickables[i].SetText(SoupStringListUtility.GetAtIndex(m_toLoad.m_list, i));
        }
        m_onListSizeRefresh.Invoke(m_toLoad.m_list.m_containedStrings.Count.ToString());
    }


    [ContextMenu("Flush and Refresh")]
    public void FlushAndRefresh()
    {
        FlushTextInClickable();
        LoadElementOfList();

    }

    [ContextMenu("Flush text")]
    public void FlushTextInClickable()
    {
        for (int i = 0; i < m_clickables.Count; i++)
        {
            m_onFlushWordsInClickable.Invoke(m_clickables[i].GetText());
            m_clickables[i].SetText("");
        }
    }
}
