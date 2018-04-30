using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour_Switch : MonoBehaviour {

    public MeshRenderer[] renderers;
    Vehicle_Control_Holder control_holder;
    private void Start()
    {
        control_holder = GetComponent<Vehicle_Control_Holder>();
        renderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        if (control_holder != null)
        {
            print(control_holder.Get_Player_Index());
            switch (control_holder.Get_Player_Index())
            {
                case 0:
                    Switch_Colour(new Color(100f/255, 176f/255, 88f/255));
                    break;
                case 1:
                    Switch_Colour(new Color(64f/255, 127f/255, 127f/255));
                    break;
                case 2:
                    Switch_Colour(new Color(125f/255, 73f/255, 141f/255));
                    break;
                case 3:
                    Switch_Colour(new Color(205f/255, 103f/255, 113f/255));
                    break;
                default:
                    Switch_Colour(Color.magenta);
                    break;
            }
        }
        else
        {
            Switch_Colour(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }
    }

    public void Switch_Colour(Color _colour)
    {
        for(int i=  0;i < renderers.Length; i++)
        {
            Material mat = renderers[i].material;
            mat.color = _colour;
        }
    }
}
