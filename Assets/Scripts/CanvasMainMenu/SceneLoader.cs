using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour // Чтобы сохранять объекты MainScene. Так как при загрузке уровня они пропадают.
{
    private void Awake()
    {
        DontDestroyOnLoad(this); //пометит объект this(а именно компонент - SceneLoader) и перенесет в любую сцену, которую мы загрузим.03
    }

    public static void LoadScene (int index) //будем передавать индекс сцены.01 //static - чтобы не вызывать SceneLoader каждый раз.04
    {
        SceneManager.LoadScene(index); //загружаем сцену с индексом с помощью данного компонента.метода.02
    }
}
