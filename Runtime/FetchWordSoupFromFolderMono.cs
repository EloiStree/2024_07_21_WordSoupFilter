using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class FetchWordSoupFromFolderMono : MonoBehaviour
{
    public string m_absolutePathOfTargetFolder = "C:/Users/username/Desktop/WordSoupFolder";

    public UnityEvent<string> m_onTextFileFetched;

    [ContextMenu("Fetch Words in files")]
    public void FetchWordsInFiles() {
        
        if(!System.IO.Directory.Exists(m_absolutePathOfTargetFolder)) {
            return;
        }
        string[] files = System.IO.Directory.GetFiles(m_absolutePathOfTargetFolder);
       
        foreach (string file in files)
        {
            string text = System.IO.File.ReadAllText(file);
            m_onTextFileFetched.Invoke(text);

        }

    }
}
