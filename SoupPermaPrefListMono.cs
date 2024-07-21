using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class SoupPermaPrefListMono : MonoBehaviour
{
    public SoupStringListMono m_affected;
    public string m_fileName;

    public UnityEvent m_afterLoading;
    public UnityEvent m_beforeSaving;

    private void Reset()
    {
        NewGUID();
    }
    public bool m_useEnableToSaveAndLoad = true;

    private void OnEnable()
    {
        if (m_useEnableToSaveAndLoad)
        {
            Load();
        }
    }
    
    private void OnDisable()
    {
        if (m_useEnableToSaveAndLoad)
        {
            SaveOverride();
        }
    }

    [ContextMenu("New GUID")]
    private void NewGUID()
    {
        m_fileName = Guid.NewGuid().ToString();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(GetPath()))
        {
            string text = File.ReadAllText(GetPath());
            SoupStringListUtility.AppendWords(m_affected.m_list, text);
        }
        m_afterLoading.Invoke();    
    }

    [ContextMenu("Open Folder")]
    public void OpenFolder()
    {
        Application.OpenURL(Application.persistentDataPath);

    }
    [ContextMenu("Open File")]
    public void OpenFile()
    {
        Application.OpenURL(GetPath());

    }
    public string GetPath() { 
        return Application.persistentDataPath + "/" + m_fileName+".txt";
    }

    [ContextMenu("Save override")]
    public void SaveOverride() { 
        
        m_beforeSaving.Invoke();
        string text= SoupStringListUtility.GetItemsAsText(m_affected.m_list,"\n");
        if(!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }
        File.WriteAllText(GetPath(), text);

    }


}
