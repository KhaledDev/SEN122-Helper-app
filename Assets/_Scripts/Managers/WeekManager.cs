using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekManager : MonoBehaviour
{

    public static WeekManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int Week;
    public int Practice;

    public TMP_InputField textview;

    public GameObject PracticeBtnPrefab;
    public Transform Content;
    
    public void SelectWeek(int _week)
    {
        Week = _week;
        GetPractices();
    }

    void GetPractices() 
    {
        string file ;
        
        
        //Hard coded solution for now Until I fix it later.
        if(Week == 4 || Week == 6)
        {
            file = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}-Part1/",Week == 6 ? 5 : 4);
        }else if(Week == 5 || Week == 7)
        {
            file = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}-Part2/",Week == 7 ? 5 : 4);
        }
        else
        {
            file = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}/",Week);
        }
        
        if(Directory.Exists(file))
        {
            string[] files = Directory.GetFiles(file,"*.*")
                                      .Where(file => file.EndsWith(".meta"))
                                      .ToArray();
            int filecount = files.Length;
            print(filecount);
            
            for (int i = 0; i < filecount; i++)
            {
                GameObject currentBtn = Instantiate(PracticeBtnPrefab, Content);
                currentBtn.GetComponentInChildren<TMP_Text>().text = string.Format("Practice {0}",i+1);
                int practiceIndex = i+1;
                currentBtn.GetComponent<Button>().onClick.AddListener(() => SelectPractice(practiceIndex));
            }
            
            
        }

    }

    public void SelectPractice(int _practice)
    {
        Practice = _practice;
        displayPractice();
    }

    public void displayPractice()
    {
        textview.text = "";
        string readfromfile;
        //Hard coded solution for now Until I fix it later.
        if(Week == 4 || Week == 6)
        {
            readfromfile = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}-Part1/",Week == 6 ? 5 : 4) + string.Format("Practice{0}.java",Practice);
        }else if(Week == 5 || Week == 7)
        {
            readfromfile = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}-Part2/",Week == 7 ? 5 : 4) + string.Format("Practice{0}.java",Practice);
        }
        else
        {
            readfromfile = Application.streamingAssetsPath + string.Format("/Resources/Week-{0}/",Week) + string.Format("Practice{0}.java",Practice);
        }

        List<string> files = File.ReadAllLines(readfromfile).ToList();

        foreach (string line in files)
        {
            textview.text += line + "\n";
        }
    }

}
