using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupStringListWrapperMono : MonoBehaviour
{

    public SoupStringListMono m_target;
    public SoupStringListMono [] m_banList;


    public void RemoveBanned() { 
    
        for(int i=0; i< m_banList.Length; i++)
        {
            SoupStringListUtility.RemoveFromBanList(m_target.m_list, m_banList[i].m_list);
        }
    }

    [ContextMenu("Reset to zero")]
    public void ResetToZero() {

        SoupStringListUtility.ResetToZero(m_target.m_list);
    }

    [ContextMenu("Clipboard append")]
    public void AppendFromUnityClipboard()
    {

        string text = GUIUtility.systemCopyBuffer;
        SoupStringListUtility.AppendWords(m_target.m_list, text);
    }
    [ContextMenu("Clipboard append as words")]
    public void AppendFromUnityClipboardAndFilterWords()
    {
        AppendFromUnityClipboard();
        SetToDefaultLowerCaseSoup();
    }

    [ContextMenu("Set to default lower case soup")]
    public void SetToDefaultLowerCaseSoup() {

        RemoveEmpty();
        SetToLowerCase();
        RemoveExtraSpaceDouble();
        FrenchToAlphaNumerical();
        RemoveExtraSpaceDouble();
        RemoveLetters();
        RemoveDouble();
        RemoveEmpty();
        TurnGroupOfWordsStillInListToWordInList();
        RemoveBanned();

    }

    public void AppendWordsOnlyInTarget(string text) {

        SoupStringListUtility.AppendWords(m_target.m_list, text);
    }
    public void AppendGroupOfWordsInTarget(string text) {

        SoupStringListUtility.AppendGroupOfWords(m_target.m_list, text);
    }

    private void TurnGroupOfWordsStillInListToWordInList()
    {
        SoupStringListUtility.TurnGroupOfWordsStillInListToWordsInList(m_target.m_list);
    }

    private void RemoveLetters()
    {
        SoupStringListUtility.RemoveLetters(m_target.m_list);
    }

    [ContextMenu("Set to lower case")]
    public void SetToLowerCase() {

        SoupStringListUtility.SetToLowerCase(m_target.m_list);
    }
    [ContextMenu("Set to upper case")]
    public void SetToUpperCase() {

        SoupStringListUtility.SetToUpperCase(m_target.m_list);
    }
    [ContextMenu("Remove extra space double")]
    public void RemoveExtraSpaceDouble() {

        SoupStringListUtility.RemoveExtraSpaceDouble(m_target.m_list);
    }
    [ContextMenu("French to alphanumerical")]
    public void FrenchToAlphaNumerical() {

        SoupStringListUtility.FrenchToAlphaNumerical(m_target.m_list);
    }
    [ContextMenu("Remove double")]
    public void RemoveDouble() {

        SoupStringListUtility.RemoveDouble(m_target.m_list);
    }

    [ContextMenu("Remove empty")]
    public void RemoveEmpty() {

        SoupStringListUtility.RemoveEmpty(m_target.m_list);
    }
}
