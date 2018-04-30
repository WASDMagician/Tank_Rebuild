using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Slider_Update : MonoBehaviour {

    public Text value_display;
    public Slider slider;

    public void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        if(slider != null)
        {
            slider.onValueChanged.AddListener(delegate { On_Value_Change(); });
        }
        On_Value_Change();
    }

    public void On_Value_Change()
    {
        if(value_display != null)
        {
            value_display.text = slider.value.ToString();
        }
    }
}
