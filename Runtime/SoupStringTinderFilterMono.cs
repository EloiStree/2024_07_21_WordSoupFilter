using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SoupStringTinderFilterMono : MonoBehaviour
{


    public SoupStringListMono m_toFilterList;
    public SoupStringListMono m_banList;
    public SoupStringListMono m_skipList;
    public SoupStringListMono m_keepList;


    public string m_currentWord;
    public UnityEvent<string> m_onCurrentFocusChanged;
    public UnityEvent<int > m_onLeftToFilterChanged;



    private void Start()
    {
        RefreshLastWord();
    }

    [ContextMenu("Ban Current")]
    public void CurrentToBan()
    {

        SoupStringListUtility.UnqueueLastIndex(m_toFilterList.m_list, out string word);
        SoupStringListUtility.AppendWords(m_banList.m_list, word);
        RefreshLastWord();
    }
    [ContextMenu("Skip Current")]
    public void CurrentToSkipList()
    {

        SoupStringListUtility.UnqueueLastIndex(m_toFilterList.m_list, out string word);
        SoupStringListUtility.AppendWords(m_skipList.m_list, word);
        RefreshLastWord();
    }

    private void RefreshLastWord()
    {
        SoupStringListUtility.GetLastWord(m_toFilterList.m_list, out m_currentWord);
        m_onCurrentFocusChanged.Invoke(m_currentWord);
        m_onLeftToFilterChanged.Invoke(m_toFilterList.m_list.m_containedStrings.Count);
    }

    [ContextMenu("Keep Current")]
    public void CurrentToKeep() {
        SoupStringListUtility.UnqueueLastIndex(m_toFilterList.m_list, out string word);
        SoupStringListUtility.AppendWords(m_keepList.m_list, word);
        RefreshLastWord();

    }

   
}
