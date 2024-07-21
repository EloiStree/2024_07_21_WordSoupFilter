using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupStringListMono : MonoBehaviour
{
    public SoupStringList m_list;

    public void SetSoupWithNewList(SoupStringList list)
    {
        m_list = new SoupStringList();
    }
}

[System.Serializable]
public class SoupStringList
{
    public List<string> m_containedStrings = new List<string>();
}
