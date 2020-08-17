using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Crosstales.FB;

public class FileExplorer : MonoBehaviour {

    public static string path;
    public InputField loc;
    private string aux;

    public void Writein()
    {
        path = loc.text;
        Debug.Log(path);
    }
    public void Browse()
    {
        aux = FileBrowser.OpenSingleFile("Open File", "", "epub");
        path = aux.Replace("/","\\");
        Debug.Log(path);
    }
    public void Next()
    {

        SceneManager.LoadScene("Ebook2d");
    }
}
