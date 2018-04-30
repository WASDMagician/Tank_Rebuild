using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public Text timer_text;
    int time;
    
    // Use this for initialization
	void Start () {
        timer_text = GetComponentInChildren<Text>();
	}

    public void Set_Time(int _time)
    {
        time = _time;
    }
    
    public int Get_Time()
    {
        return time;
    }

    public void Start_Countdown()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            timer_text.text = time.ToString();
        }
    }
}
