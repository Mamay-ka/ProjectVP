using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System;

namespace Maze
{
    [CustomEditor(typeof(MiniCamera))]
    public class MMCUse : Editor
    {
       
                
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            MiniCamera mc = (MiniCamera)target;

            if (GUILayout.Button("MiniMap Shader Off"))
            {
               MiniCamera.MapCam.ResetReplacementShader();
               Debug.Log("Нажал!");
            }
            
            


        }
    }
}
