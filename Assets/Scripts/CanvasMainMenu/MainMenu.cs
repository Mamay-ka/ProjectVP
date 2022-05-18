
using UnityEngine.UI; //для работы с элементами UI должна быть это библиотека.
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Button; //компонент кнопки.01

    void Start()
    {
        Button.onClick.AddListener(OnButtonClick); // добавить слушателя, подписаться на событие напрямую.04
    }

    void OnButtonClick() //функция, которая будет вызываться при нажатии на кнопку Start в канвасе.02
    {
        SceneLoader.LoadScene(1); //вызываем из скрипта SceneLoader.05
        //SceneManager.LoadScene(1); //загружаем сцену с индексом 1 с помощью данного компонента.метода.03
    }
}
