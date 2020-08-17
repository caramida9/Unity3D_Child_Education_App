using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class EpubMenuBehavior : MonoBehaviour
{

    public Dropdown m_Dropdown;
    public static string path;

    // Update is called once per frame
    void Update()
    {
        //calling get path based on the selected option
        if (m_Dropdown.value == 0)
        {
            getPath("pg14837-images.epub");
        }
        else if (m_Dropdown.value == 1)
        {
            getPath("pg219.epub");
        }
        else if (m_Dropdown.value == 2)
        {
            getPath("pg236.epub");
        }
        else if (m_Dropdown.value == 3)
        {
            getPath("pg11-images.epub");
        }
        else if(m_Dropdown.value == 4)
        {
            getPath("pg74-images.epub");
        }
        else if(m_Dropdown.value == 5)
        {
            getPath("pg521.epub");
        }
        else if(m_Dropdown.value == 6)
        {
            getPath("pg2542-images.epub");
        }
    }

    public void getPath(string file)
    {
        string oriPath = "";
        string realpath= "";
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            //building the path for Windows based applications
            oriPath = Application.dataPath + "/StreamingAssets/" + file;
            realpath = Application.persistentDataPath + "/" + file;
            path = realpath.Replace("/", "\\");
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            //building the path for Android based applications
            oriPath = "jar:file://" + Application.dataPath + "!/assets/" + file;
            realpath = "/storage/emulated/0/Download/" + file;
            path = realpath;
        }

        // Android only use WWW to read file
        WWW reader = new WWW(oriPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(realpath, reader.bytes);
    }

    public void Next()
    {
        SceneManager.LoadScene("Ebook2d");
    }
    public void Quit()
    {
        SceneManager.LoadScene("GameList");
    }
}
