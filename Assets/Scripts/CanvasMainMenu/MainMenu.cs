
using UnityEngine.UI; //��� ������ � ���������� UI ������ ���� ��� ����������.
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Button; //��������� ������.01

    void Start()
    {
        Button.onClick.AddListener(OnButtonClick); // �������� ���������, ����������� �� ������� ��������.04
    }

    void OnButtonClick() //�������, ������� ����� ���������� ��� ������� �� ������ Start � �������.02
    {
        SceneLoader.LoadScene(1); //�������� �� ������� SceneLoader.05
        //SceneManager.LoadScene(1); //��������� ����� � �������� 1 � ������� ������� ����������.������.03
    }
}
