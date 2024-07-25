using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SoupStringListUtility {

    public static void SetToLowerCase(SoupStringList list)
    {
        for (int i = 0; i < list.m_containedStrings.Count; i++)
        {
            list.m_containedStrings[i] = list.m_containedStrings[i].ToLower();
        }
    }
    public static void SetToUpperCase(SoupStringList list)
    {
        for (int i = 0; i < list.m_containedStrings.Count; i++)
        {
            list.m_containedStrings[i] = list.m_containedStrings[i].ToUpper();
        }
    }
    public static void RemoveExtraSpaceDouble(SoupStringList list) { 
        for (int i = 0; i < list.m_containedStrings.Count; i++)
        {
            while (list.m_containedStrings[i].Contains("  "))
                list.m_containedStrings[i] = list.m_containedStrings[i].Replace("  ", " ");
        }
    }

    public static void FrenchToAlphaNumerical(SoupStringList list) { 
        for (int i = 0; i < list.m_containedStrings.Count; i++)
        {
            list.m_containedStrings[i] = ReplaceFrenchCharToAlpha(list.m_containedStrings[i]);
            list.m_containedStrings[i] = System.Text.RegularExpressions.Regex.Replace(list.m_containedStrings[i], "[^a-zA-Z0-9_\\-\\.]", " ");
        }
    }
    public static void TurnGroupOfWordsStillInListToWordsInList(SoupStringList list)
    {
       for(int i= list.m_containedStrings.Count-1; i>=0; i--)
        {
            if (list.m_containedStrings[i].Contains(" "))
            {
                list.m_containedStrings.AddRange(list.m_containedStrings[i].Split(new string[] { " " }, StringSplitOptions.None));
                list.m_containedStrings.RemoveAt(i);
            }
        }
    }
    public static void RemoveDouble(SoupStringList list)
    {

        list.m_containedStrings = new List<string>(new HashSet<string>(list.m_containedStrings));
    }
    public static void RemoveEmpty(SoupStringList list)
    {
        list.m_containedStrings.RemoveAll(x => x ==null|| x == "");

    }
    public static void RemoveFromBanList(SoupStringList list, SoupStringList banList)
    {
        for (int i = 0; i < banList.m_containedStrings.Count; i++)
        {
            list.m_containedStrings.RemoveAll(x => x == banList.m_containedStrings[i]);
        }
    }
    public static void RemoveLetters(SoupStringList list)
    {
        list.m_containedStrings.RemoveAll(x => x.Length == 1);
    }
    private static string ReplaceFrenchCharToAlpha(string v)
    {
        //ZàâäæáãåāèéêëęėēîïīįíìôōøõóòöœùûüūúÿçćčńñÀÂÄÆÁÃÅĀÈÉÊËĘĖĒÎÏĪĮÍÌÔŌØÕÓÒÖŒÙÛÜŪÚŸÇĆČŃÑ
        v = v.Replace("é", "e");
        v = v.Replace("è", "e");
        v = v.Replace("ê", "e");
        v = v.Replace("à", "a");
        v = v.Replace("â", "a");
        v = v.Replace("ç", "c");
        v = v.Replace("ù", "u");
        v = v.Replace("û", "u");
        v = v.Replace("î", "i");
        v = v.Replace("ô", "o");
        v = v.Replace("ö", "o");
        v = v.Replace("ï", "i");
        v = v.Replace("ë", "e");

        v = v.Replace("Z", "Z");
        v = v.Replace("à", "a");
        v = v.Replace("â", "a");
        v = v.Replace("ä", "a");
        v = v.Replace("æ", "ae");
        v = v.Replace("á", "a");
        v = v.Replace("ã", "a");
        v = v.Replace("å", "a");
        v = v.Replace("ā", "a");
        v = v.Replace("è", "e");
        v = v.Replace("é", "e");
        v = v.Replace("ê", "e");
        v = v.Replace("ë", "e");
        v = v.Replace("ę", "e");
        v = v.Replace("ė", "e");
        v = v.Replace("ē", "e");
        v = v.Replace("î", "i");
        v = v.Replace("ï", "i");
        v = v.Replace("ī", "i");
        v = v.Replace("į", "i");
        v = v.Replace("í", "i");
        v = v.Replace("ì", "i");
        v = v.Replace("ô", "o");
        v = v.Replace("ō", "o");
        v = v.Replace("ø", "o");
        v = v.Replace("õ", "o");
        v = v.Replace("ó", "o");
        v = v.Replace("ò", "o");
        v = v.Replace("ö", "o");
        v = v.Replace("œ", "oe");
        v = v.Replace("ù", "u");
        v = v.Replace("û", "u");
        v = v.Replace("ü", "u");
        v = v.Replace("ū", "u");
        v = v.Replace("ú", "u");
        v = v.Replace("ÿ", "y");

        v = v.Replace("ç", "c");
        v = v.Replace("ć", "c");
        v = v.Replace("č", "c");
        v = v.Replace("ń", "n");
        v = v.Replace("ñ", "n");
        v = v.Replace("À", "A");
        v = v.Replace("Â", "A");
        v = v.Replace("Ä", "A");
        v = v.Replace("Æ", "AE");
        v = v.Replace("Á", "A");
        v = v.Replace("Ã", "A");
        v = v.Replace("Å", "A");
        v = v.Replace("Ā", "A");
        v = v.Replace("È", "E");
        v = v.Replace("É", "E");
        v = v.Replace("Ê", "E");
        v = v.Replace("Ë", "E");
        v = v.Replace("Ę", "E");
        v = v.Replace("Ė", "E");
        v = v.Replace("Ē", "E");
        v = v.Replace("Î", "I");
        v = v.Replace("Ï", "I");
        v = v.Replace("Ī", "I");
        v = v.Replace("Į", "I");
        v = v.Replace("Í", "I");
        v = v.Replace("Ì", "I");
        v = v.Replace("Ô", "O");
        v = v.Replace("Ō", "O");
        v = v.Replace("Ø", "O");
        v = v.Replace("Õ", "O");
        v = v.Replace("Ó", "O");
        v = v.Replace("Ò", "O");
        v = v.Replace("Ö", "O");
        v = v.Replace("Œ", "OE");
        v = v.Replace("Ù", "U");
        v = v.Replace("Û", "U");
        v = v.Replace("Ü", "U");
        v = v.Replace("Ū", "U");
        v = v.Replace("Ú", "U");
        v = v.Replace("Ÿ", "Y");
        v = v.Replace("Ç", "C");
        v = v.Replace("Ć", "C");
        v = v.Replace("Č", "C");
        v = v.Replace("Ń", "N");
        v = v.Replace("Ñ", "N");
        return v;
    }

    public static void TextToSoup(string text, out SoupStringList list, string[] spliter)
    {
        list = new SoupStringList();
        list.m_containedStrings = new List<string>(text.Split(spliter, StringSplitOptions.None));
    }
    public static void TextToSoupWordOnly(string text, out SoupStringList list)
    {
        TextToSoup(text, out list, new string[] { " ", "\n", "\r", "\t" });
    }
    public static void TextToSoupGroupOfWords(string text, out SoupStringList list)
    {
        TextToSoup(text, out list, new string[] {",", "\n", "\r", "\t" });
    }


    public static void ResetToZero(SoupStringList target)
    {
        target.m_containedStrings.Clear();
    }

    public static void AppendWords(SoupStringList m_list, string text)
    {
        m_list.m_containedStrings.AddRange(text.Split(new string[] { " ", ",", ";", ".", "\n", "\r", "\t" }, StringSplitOptions.None));
    }
    public static void AppendGroupOfWords(SoupStringList m_list, string text)
    {
        m_list.m_containedStrings.AddRange(text.Split(new string[] { ",", ";", ".", "\n", "\r", "\t" }, StringSplitOptions.None));
    }

    public static string GetItemsAsText(SoupStringList m_list, string spliter)
    {
        return string.Join(spliter, m_list.m_containedStrings);
    }

    internal static void UnqueueLastIndex(SoupStringList m_list, out string word)
    {
        if(m_list.m_containedStrings.Count>0)
        {
            word = m_list.m_containedStrings[m_list.m_containedStrings.Count - 1];
            m_list.m_containedStrings.RemoveAt(m_list.m_containedStrings.Count - 1);
        }
        else
        {
            word = "";
        }
    }

    public static void GetLastWord(SoupStringList list, out string word)
    {
        if (list.m_containedStrings.Count > 0)
        {
            word = list.m_containedStrings[list.m_containedStrings.Count - 1];
        }
        else
        {
            word = "";
        }
    }

    internal static string GetAtIndex(SoupStringList m_list, int i)
    {
        if(i>=0 && i< m_list.m_containedStrings.Count)
        {
            return m_list.m_containedStrings[i];
        }
        else
        {
            return "";
        }
    }
}
