using System.IO;//���������� �����-������
using UnityEngine;

namespace Maze
{

    public class JSONData : ISaveData
    {
        //������� ���� �� ���������� ����������
        string SavePath = Path.Combine(Application.dataPath, "JSONData.json");//������������� ����� �� ���������� ����������. ��� �������� ����� � ��, ��� � ��� ����� ������ ���������� ����
        public void SaveData(PlayerData player)
        {
            string FileJSON = JsonUtility.ToJson(player);
            File.WriteAllText(SavePath, FileJSON);//�������� ��� ���� ���������� �� ����� ������
        }
        public PlayerData Load()
        {
            
            PlayerData result = new PlayerData();

            if (!File.Exists(SavePath))//���������, ���������� �� ����, ����� �� �������� ������
            {
                Debug.Log("FILE NOT EXIST");//���� ���� �����������, �� �������� �������...
                return result;//� ���������� ������ rusult
            }
            string json = File.ReadAllText(SavePath);//���� ���� ����������, �� ������� ���������� � ������ ���� �� ����� ������
            result = JsonUtility.FromJson<PlayerData>(json);//����������� ��� ��������� ���������� JsonUtility

            return result;
        }

       
    }
}
