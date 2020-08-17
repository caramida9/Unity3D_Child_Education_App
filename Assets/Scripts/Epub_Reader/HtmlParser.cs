using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HtmlParser : MonoBehaviour {

    public Text Story;
    public Text pageno;
    public GameObject Picture;
    public GameObject Showable;
    public GameObject next_but;
    public GameObject prev_but;
    private Sprite mysprite;
    private List<GameObject> ShowableList = new List<GameObject>();
    private SpriteRenderer sr;
    private string textfile;
    private int pagenr=0;

    string[] dontshow = new string[3];
    int[] pagesize = new int[100];

    // Use this for initialization
    void Start () {
        
        //VerticalLayoutGroup box;
        //box = GetComponent<VerticalLayoutGroup>();

        //html data that we don't want to be shown
        dontshow[0] = "<br/>";
        dontshow[1] = "<!--  H2 anchor -->";
        dontshow[2] = "Html page:";

        StartCoroutine(waitthenread(1f));
        StartCoroutine(first(1.5f));
        
        //box.childControlHeight = true;
        //Canvas.ForceUpdateCanvases();


    }

    //extracting a string from a paragraph tag
    string Extract(string s)
    {
        
        Regex regex = new Regex("<p>(.*?)</p>");
        var v = regex.Match(s);
        string sub = v.Groups[1].ToString();
        sub = sub.Replace("~~", "\n");
        //add emphasis text
        if(sub.Contains("<span class=\"emphasis\">"))
        {
            sub = sub.Replace("<span class=\"emphasis\"><em>", "<b>");
            sub = sub.Replace("</em></span>", "</b>");
        }
        //marking character dialogue
        if(sub.Contains("<span class=\"character\">"))
        {
            sub = sub.Replace("<span class=\"character\">", "<b>");
            var reg = new Regex(Regex.Escape("</span>"));
            sub = reg.Replace(sub, "</b>", 1);
        }
        //marking stage direction for dramatic play
        if(sub.Contains("<span class=\"stage-direction\">"))
        {
            sub = sub.Replace("<span class=\"stage-direction\">", "<i>");
            var reg = new Regex(Regex.Escape("</span>"));
            sub = reg.Replace(sub, "</i>", 4);
        }
        return sub;
    }

    //extracting image location from an img src tag
    string Extractimg(string s)
    {
        string sub = "";
        if (s.Contains("<img"))
        {
            Regex regex = new Regex("src=\"(.*?)\" ");
            var v = regex.Match(s);
            sub = v.Groups[1].ToString();
        }
        return sub;
    }

    //extracting chapter name from header tag
    string Extractchapter(string s)
    {
        Regex regex = new Regex("<h[1-3] id=\"pgepubid\\d{5}\">(.*?)</h[1-3]>");
        var v = regex.Match(s);
        string sub = v.Groups[1].ToString();
        return sub;
    }

    //extracting verse-like paragraphs
    string Extractverse(string s)
    {
        Regex regex = new Regex("<div xml:space=\"preserve\" class=\"pgmonospaced\">(.*?)</div>");
        var v = regex.Match(s);
        string sub = v.Groups[1].ToString();
        sub = sub.Replace("<br/>", "\r\n");
        return sub;
    }

    //We wait before reading to make sure the file is written
    IEnumerator waitthenread(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        //we read the file from persistent data path and process it line by line
        textfile = File.ReadAllText(Application.persistentDataPath + "test.txt");
        string[] textlines = textfile.Split('\n');
        string imgslocation = textlines[0];
        int page = 0;
        List<string> chapterlines = new List<string>();
        for(int i=0; i<textlines.Length; i++)
        {
            textlines[i] = textlines[i].Replace("</p><p>", "~~");
        }

        for(int i=0; i<textlines.Length; i++)
        {
            string line = textlines[i];
            
            if (!line.Contains("Html page:"))
            {
                //moving all paragraph tags to a single line
                if (line.Contains("<p>") && !line.Contains("</p>"))
                {
                    int j = i+1;
                    string aux = "";
                    do
                    {
                        aux = textlines[j];
                        line = line + " " + aux;
                        j++;
                    } while (!aux.Contains("</p>") && j<textlines.Length);
                    i = j-1;
                }
                //we add lines until we meet the page separator "html page:"
                chapterlines.Add(line);
            }
            else
            {
                //we create a new page and add it to the pagelist, we also remember the page nr of lines.
                string[] auxiliar;
                auxiliar = chapterlines.ToArray();
                pagesize[page] = chapterlines.Count;
                page++;
                GameObject clone;
                clone = Instantiate(Showable, transform);
                StartCoroutine(showtext(0.25f, auxiliar, imgslocation, clone.transform.GetChild(0).gameObject));

                ShowableList.Add(clone);
                
                chapterlines.Clear();
            }
        }
        ShowableList.ToArray();

        
    }
    //the main showing function
    IEnumerator showtext(float time, string[] textlines, string imgslocation, GameObject parent)
    {
        yield return new WaitForSeconds(time);

        foreach (string line in textlines)
        {
            //from each line we can extract regular paragraph text, chapter text, verses or image location
            string show = Extract(line);
            string img = Extractimg(line);
            string chapter = Extractchapter(line);
            string verse = Extractverse(line);
            int ok = 1;

            for (int i = 0; i <= 1; i++)
            {
                //we make sure the paragraph doesn't contain html data irrelevant to the reader
                if (show.Contains(dontshow[i]))
                {
                    ok = 0;
                }
            }

            if ((show != "") && (ok == 1))
            {
                //we instantiate a new story paragraph to show
                Text clone;
                clone = Instantiate(Story, parent.transform) as Text;
                
                clone.supportRichText = true;
                clone.text = show;
            }
            if (chapter != "")
            {
                Text clone;
                clone = Instantiate(Story, parent.transform) as Text;
                clone.fontSize = 20;
                clone.text = chapter;
            }
            if (verse != "")
            {
                Text clone;
                clone = Instantiate(Story, parent.transform) as Text;
                clone.supportRichText = true;
                clone.text = verse;
            }

            if (img != "")
            {
                //we instantiate a game object for the picture
                GameObject clone2;
                Texture2D tex = new Texture2D(3, 3);
                string location = imgslocation + "/" + img;
                clone2 = Instantiate(Picture, parent.transform);
                //the picture is created by reading all the bites from the imgslocation and using the sprite function to create a new texture

                byte[] bytes = File.ReadAllBytes(location);
                tex.LoadImage(bytes);
                mysprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                clone2.GetComponent<Image>().sprite = mysprite;

            }

        }
    }
    //showing the first page
    IEnumerator first(float time)
    {
        
        yield return new WaitForSeconds(time);
        GameObject clone3;
        clone3 = Instantiate(ShowableList[pagenr], GameObject.Find("Canvas").transform);

        next_but.SetActive(true);
    }

    //flip to next page
    public void next()
    {
		soundmanager.instance.PlaySounds ("page");
        if (pagenr < ShowableList.Count -1 )
        {
            //max read 8sec min read 3sec
            if(EbookRenderer.timespent>3*pagesize[pagenr] && EbookRenderer.timespent < 9 * pagesize[pagenr])
            {
                //user read the page within a resonable time
                MainMenuBehaviour.lang_stat += 2;
                EbookRenderer.timespent = 0;
            }
            Destroy(GameObject.Find("Image(Clone)(Clone)"));
            pagenr++;
            pageno.text = "Page: " + System.Convert.ToString(pagenr+1);
            GameObject clone;
            clone = Instantiate(ShowableList[pagenr], GameObject.Find("Canvas").transform);
        }
        //displaying buttons based on pages(aka no prev on first page no next at last page)
        if(pagenr != ShowableList.Count - 1)
        {
            next_but.SetActive(true);
        }
        else
        {
            next_but.SetActive(false);
        }
        if(pagenr != 0)
        {
            prev_but.SetActive(true);
        }
    }

    //flip to previous page
    public void prev()
    {
		soundmanager.instance.PlaySounds ("page");
        if (pagenr > 0)
        {
            EbookRenderer.timespent = 0;
            Destroy(GameObject.Find("Image(Clone)(Clone)"));
            pagenr--;
            pageno.text = "Page: " + System.Convert.ToString(pagenr+1);
            GameObject clone;
            clone = Instantiate(ShowableList[pagenr], GameObject.Find("Canvas").transform);
        }
        //displaying buttons based on pages
        if(pagenr == 0)
        {
            prev_but.SetActive(false);
        }
        if(pagenr != ShowableList.Count - 1)
        {
            next_but.SetActive(true);
        }
    }
}
