using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour {

    public GameObject[] imgs;
    public Text[] grades;
    public GameObject stat;

    public static int logic_stat;
    public static int space_stat;
    public static int kinetic_stat;
    public static int lang_stat;

    private string text;
    private static bool first=true;
    private static int penalty=-1;//preventing the same game to be chosen multiple times
    
    // Use this for initialization
    void Start () {
		soundmanager.instance.PlaySounds ("background");
        //first time opening the game
        if (first == true)
        {   //building the path to the stats folder for android
            string folderpath;
            if (Application.platform == RuntimePlatform.Android)
            {
                folderpath = Application.persistentDataPath + "/Resources/";
                string filepath = folderpath + "stats.txt";
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                //creating the stats folder if it doesn't exist
                if (!File.Exists(filepath))
                {
                    string towrite = "1 1 1 1 ";
                    towrite = towrite.Replace(" ", Environment.NewLine);
                    File.WriteAllText(filepath, towrite);
                }
                //reading the stats
                text = File.ReadAllText(filepath);
            }
            else
            {
                text = File.ReadAllText(Application.dataPath + "/Resources/stats.txt");
            }
            //loading stats to parameters
            string[] lines = text.Split('\n');
            logic_stat = Int32.Parse(lines[0]);
            space_stat = Int32.Parse(lines[1]);
            kinetic_stat = Int32.Parse(lines[2]);
            lang_stat = Int32.Parse(lines[3]);
            first = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void triggerMenuBehavior(int i)
    {

        switch (i)
        {
            default:
            case (0):
                int choice = chosegame();
                switch (choice)
                {
                    case (0):
                        SceneManager.LoadScene("logic1");
                        break;
                    case (1):
                        SceneManager.LoadScene("ballongame");
                        break;
                    case (2):
                        SceneManager.LoadScene("SimpleCanvas");
                        break;
                    case (3):
                        SceneManager.LoadScene("logicm1");
                        break;
                    case (4):
                        SceneManager.LoadScene("logich1");
                        break;
                    case (5):
                        SceneManager.LoadScene("LabyrinthGame_Level1");
                        break;
                    case (6):
                        SceneManager.LoadScene("LabyrinthGame_Level2");
                        break;
                    case (7):
                        SceneManager.LoadScene("LabyrinthGame_Level3");
                        break;
                    case (8):
                        SceneManager.LoadScene("MatchGame_Level1");
                        break;
                    case (9):
                        SceneManager.LoadScene("MatchGame_Level2");
                        break;
                    case (10):
                        SceneManager.LoadScene("MatchGame_Level3");
                        break;
                    case (11):
                        
                        break;
                    case (12):
                        SceneManager.LoadScene("ballongame2");
                        break;
                }
                break;
            case (1):
                SceneManager.LoadScene("GameList");
                break;
            case (2):
                string towrite = logic_stat + " " + space_stat + " " + kinetic_stat + " " + lang_stat + " ";
                towrite = towrite.Replace(" ", Environment.NewLine);
                string folderpath;
                if (Application.platform == RuntimePlatform.Android)
                {
                    folderpath = Application.persistentDataPath + "/Resources/";
                    string filepath = folderpath + "stats.txt";
                    if (!Directory.Exists(folderpath))
                    {
                        Directory.CreateDirectory(folderpath);
                    }
                    File.WriteAllText(filepath, towrite);
                }
                else
                {
                    File.WriteAllText(Application.dataPath + "/Resources/stats.txt", towrite);
                }
                Application.Quit();
                break;
        }
    }
    //display stats function
    public void stats()
    {
       
        for(int i=0; i < imgs.Length; i++)
        {
            imgs[i].SetActive(true);
        }
        stat.SetActive(false);
        grades[0].text = grading(logic_stat);
        grades[1].text = grading(space_stat);
        grades[2].text = grading(kinetic_stat);
        grades[3].text = grading(lang_stat);
    }
    //reseting stats file
    public void resetstat()
    {
        string towrite = "1 1 1 1 ";
        logic_stat = space_stat = kinetic_stat = lang_stat = 1;
        towrite = towrite.Replace(" ", Environment.NewLine);
        string folderpath;
        if (Application.platform == RuntimePlatform.Android)
        {
            folderpath = Application.persistentDataPath + "/Resources/";
            string filepath = folderpath + "stats.txt";
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            File.WriteAllText(filepath, towrite);
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Resources/stats.txt", towrite);
        }
        SceneManager.LoadScene("Main Menu");
    }
    //auxiliary function to show stats as grades
    public string grading(int val)
    {
        if (val < 4)
            return "D";
        else if (val >= 4 && val < 8)
            return "C";
        else if (val >= 8 && val < 12)
            return "B";
        else if (val >= 12)
            return "A";
        return "n/a";
    }
    //game-choice algorithm
    public int chosegame()
    {
        int max = 0, nr = 0, i;
        int[] v = new int[13];
        for (i = 0; i <= 12; i++)
        {
            v[i] = 0;
        }
        v[0] = UnityEngine.Random.Range(1, 100);//logic easy
        v[1] = UnityEngine.Random.Range(1, 100);//ballon
        v[2] = UnityEngine.Random.Range(1, 100);//canvas
        if(logic_stat>4)
        {
            v[3] = UnityEngine.Random.Range(50, 200);//logic medium
        }
        if (logic_stat > 8)
        {
            v[4] = UnityEngine.Random.Range(100, 250);//logic hard
        }
        if(logic_stat>2 && kinetic_stat > 2)
        {
            v[5] = UnityEngine.Random.Range(50, 150);//labyrinth easy
        }
        if(logic_stat>6 && kinetic_stat > 4)
        {
            v[6] = UnityEngine.Random.Range(100, 200);//labyrinth medium
        }
        if (logic_stat > 8 && kinetic_stat > 8)
        {
            v[7] = UnityEngine.Random.Range(150, 250);//labyrinth hard
        }
        if(space_stat > 2)
        {
            v[8] = UnityEngine.Random.Range(50, 150);//matchgame easy
        }
        if(space_stat > 5)
        {
            v[9] = UnityEngine.Random.Range(100, 200);//matchgame medium
        }
        if(space_stat > 7)
        {
            v[10] = UnityEngine.Random.Range(150, 250);//matchgame hard
        }
        if(space_stat > 3)
        {
            //v[11] = UnityEngine.Random.Range(50, 150);//emotion match
        }
        if (kinetic_stat > 2)
        {
            v[12] = UnityEngine.Random.Range(50, 150);//ballon medium
        }
        for(i = 0; i <= 12; i++)
        {
            if (i == penalty)
            {
                v[i] -= 100;
            }
            if (v[i] > max)
            {
                max = v[i];
                nr = i;
            }
        }
        penalty = nr;
        return nr;
    }
}
