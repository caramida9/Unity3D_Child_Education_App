using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UEPub;
using System.IO;
using UnityEngine.SceneManagement;

public class EbookRenderer : MonoBehaviour {
	public Text Title;
    public Text Author;
	public TextAsset testBook;
    public static float timespent = 0;
	//private EpubBook epubBook;

	// Use this for initialization
	void Start () {
		OpenEbookFile ();
	}

    void Update()
    {
        timespent += Time.deltaTime;
    }

    void OpenEbookFile(){
        // Opening a book

        //var epub = new UEPubReader ("Assets/Books/pg14837-images.epub");

        var epub = new UEPubReader(EpubMenuBehavior.path);
        Debug.Log (epub.epubFolderLocation);

        //reading title and author from metadata
        Title.text = epub.metadata.title;
        Author.text ="by " + epub.metadata.creator;

        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "test.txt");
        //retaining the path to images
        sw.Write(epub.epubImageLocation);
        int i = 0;
        while (i < epub.chapters.Count)
        {
            //writing epub data to test.txt
            
            sw.Write(epub.chapters[i]);
            sw.Write("Html page:" + i + 1);
            i++;
            
        } 
        
        sw.Close();
	}
    //simple return to main menu function
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
