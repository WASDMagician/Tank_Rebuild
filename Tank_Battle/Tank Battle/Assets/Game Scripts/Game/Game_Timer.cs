using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour {

    Text timer_text;
    private void Start()
    {
        timer_text = GetComponent<Text>();
    }

    public void Set_Time(int _time)
    {
        if(timer_text == null)
        {
            timer_text = GetComponent<Text>();
        }
        if(timer_text != null)
        {
            timer_text.text = _time.ToString();
        }
    }
}
