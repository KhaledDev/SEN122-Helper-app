using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekPageManager : MonoBehaviour
{

    public TMP_Text Week_text;
    public TMP_InputField FileText;
    public Transform Content;

    private void OnEnable()
    {
        
        //Very hard coded solution for now Until I fix it later.
        
        if(WeekManager.instance.Week == 4)
        {
            Week_text.text = "Week 4 Part 1";
        }else if (WeekManager.instance.Week == 5)
        {
            Week_text.text = "Week 4 Part 2";
        }else if(WeekManager.instance.Week == 6)
        {
            Week_text.text = "Week 5 Part 1";
        }else if (WeekManager.instance.Week == 7)
        {
            Week_text.text = "Week 5 Part 2";
        }else
        {
            Week_text.text = "Week " + WeekManager.instance.Week.ToString();
        }
        
    }
    
    public void DestroyContentChildren()
    {
        for(int i = 0; i < Content.childCount; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
        
        FileText.text = string.Empty;
        
    }
    
}
