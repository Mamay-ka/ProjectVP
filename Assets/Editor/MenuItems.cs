using UnityEditor;
using UnityEngine;

namespace Maze
{

    public class MenuItems
    {
        [MenuItem("Maze/Test")]
        

        private static void MenuOption()
        {
            
            EditorWindow.GetWindow(typeof(MyWindow2), false, "Maze");
        }

        

        

    }
}