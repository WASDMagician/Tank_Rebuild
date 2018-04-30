using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Text : MonoBehaviour {

    GUIStyle style;
    string text;
    bool draw_text;

    public static Draw_Text draw_text_inst;

    private void Start()
    {
        draw_text_inst = this;
        style = new GUIStyle();
        style.fontSize = 45;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.black;
    }

    public void Set_Text(string _text)
    {
        text = _text;
    }

    public void Set_Draw_Text(bool _draw_text)
    {
        draw_text = _draw_text;
    }

    private void OnGUI()
    {
        if (draw_text == true)
        {
            GUI.Label(new Rect(10, 10, 100, 20), text, style);
        }
    }
}
