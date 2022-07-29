using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    public static Shader _replShader;
    public static Camera MapCam;
       


    public void Awake()
    {
        _replShader = Shader.Find("Unlit/Texture");//чтобы карта выглядела поинтереснее мы можем заменить шейдер
                                                   //будет работать с директорией шейдеров Unlit/Texture
        MapCam = GetComponent<Camera>();//запросим компонент камеры

        

        if(_replShader)//если есть _replShader, то будем его заменять 
        {
            MapCam.SetReplacementShader(_replShader, "RenderType");//сделали подмену
        }

                
    }

    private void OnDisable()//сделаем метод, чтобы при выключении камеры шейдер менялся обратно
    {
        MapCam.ResetReplacementShader();//таким образом мы возвращаемся к исходному
    }

      
}
