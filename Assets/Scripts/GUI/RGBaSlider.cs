using UnityEngine;



public class RGBaSlider : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)]
    [Tooltip("�������� ��������� � ��������� �� 0 �� 5")]
    private float mySlider = 1.0f; // ��������� ����������������� ��������
    [Header("Custom color")]
    public Color myColor;         // �������� �����
    public MeshRenderer GO;      // ������ �� ������ �������

    [SerializeField, TextArea(5, 10)]
    private string field;

    [SerializeField] public Sprite sprite;

    void OnGUI()
    {
        mySlider = LabelSlider(new Rect(10, 10, 200, 20), mySlider, 0.5f, 5.0f, "My Slider"); // ��������� ����������������� ��������

        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);  // ��������� ����������������� ������ ��������� ��� ��������� ��������� �����
        GO.material.color = myColor; // �������� �������
       

        //mySlider = LabelSlider(new Rect(10, 120, 200, 20), mySlider, 5.0f, "Learning Aim Slider");//����� ��������� ���� �������.
    }

    // ��������� ����������������� ��������
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) // �� �������� MinValue
    {
        // ������ ������������� � ������������ � ������������ � ������� ������� � ������� 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // ������ Label �� ������

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // ����� ������� ��������
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue); // ������������ ������� � ��������� ��� ��������
       
        return sliderValue; // ���������� �������� ��������
    }

    // ��������� ������� ������� ������, ������ ������� �������� �� ���� ����
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // ��������� ���������������� �������, ������ ���
        rgb.r = LabelSlider(screenRect, rgb.r, 0.0f, 1.0f, "Red");

        // ������ ����������
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0.0f, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0.0f, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0.0f, 1.0f, "Alpha");
                       
        return rgb; // ���������� ����
    }
}
