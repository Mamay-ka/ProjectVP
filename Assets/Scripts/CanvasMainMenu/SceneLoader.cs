using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour // ����� ��������� ������� MainScene. ��� ��� ��� �������� ������ ��� ���������.
{
    private void Awake()
    {
        DontDestroyOnLoad(this); //������� ������ this(� ������ ��������� - SceneLoader) � ��������� � ����� �����, ������� �� ��������.03
    }

    public static void LoadScene (int index) //����� ���������� ������ �����.01 //static - ����� �� �������� SceneLoader ������ ���.04
    {
        SceneManager.LoadScene(index); //��������� ����� � �������� � ������� ������� ����������.������.02
    }
}
