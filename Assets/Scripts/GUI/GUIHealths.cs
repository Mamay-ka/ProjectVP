using System.Collections;
using UnityEngine;
using UnityEditor;

public class GUIHealths : MonoBehaviour
{
    //[SerializeField] HealthController HealthController;
    //float _GuiHealth = GetComponent<HealthController>()._currentHealth;
    private string Text = "150";




    void OnGUI()
    {
        
        GUI.Box(new Rect(Screen.width/2 - 100, 0, 200, 25), Text);
       
    }
}
