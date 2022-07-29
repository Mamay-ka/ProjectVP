using UnityEditor;
using UnityEngine;

namespace Maze
{
    public class MyWindow2 : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string _nameObject = "Good Bonus";

        public static GameObject ObjectInstantiate2;
        public string _nameObject2 = "Bad Bonus";

        public bool _groopEnabled;
        //public bool _randomColor = true;
        public int _countObject = 1;
        public int _countObject2 = 1;

        public float _radius = 1;

        



        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);

            ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);

            ObjectInstantiate2 = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate2, typeof(GameObject), true) as GameObject;
            _nameObject2 = EditorGUILayout.TextField("Имя объекта", _nameObject2);

            _groopEnabled = EditorGUILayout.BeginToggleGroup("дополнительные настройки", _groopEnabled);
            //_randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
            _countObject = EditorGUILayout.IntSlider("Количество ГудБонусов", _countObject, 1, 100);
            _countObject2 = EditorGUILayout.IntSlider("Количество БэдБонуов", _countObject2, 1, 100); 

            _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 1, 50);

            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Создать объекты");
            if (button)
            {
                GameObject root = new GameObject("Root");
                GameObject rootBB = new GameObject("RootBB");

                for (int i = 0; i < _countObject; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;

                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (_radius * Random.value);

                    GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                    temp.name = _nameObject + "(" + i + ")";
                    temp.transform.parent = root.transform;

                    /*var tempRenderer = temp.GetComponent<Renderer>();
                    if (tempRenderer && _randomColor)
                    {
                        tempRenderer.material.color = Random.ColorHSV();
                    }*/
                }
                for (int i = 0; i < _countObject2; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject2;

                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (_radius * Random.value);

                    GameObject temp = Instantiate(ObjectInstantiate2, pos, Quaternion.identity);
                    temp.name = _nameObject2 + "(" + i + ")";
                    temp.transform.parent = rootBB.transform;
                }
            }

        }

    }
}
