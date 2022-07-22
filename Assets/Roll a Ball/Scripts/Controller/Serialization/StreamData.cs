using System.IO;
using System;
using UnityEngine;

//���� ������ ������ ������ � ����

namespace Maze
{

    public class StreamData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "StreamData.XYZ");//������������� ����� �� ���������� ����������. ��� �������� ����� � ��, ��� � ��� ����� ������ ���������� ����
        public void SaveData(PlayerData player)
        {
            using (StreamWriter sw = new StreamWriter(SavePath))//���� ��� ����� ����� StreamWriter
            {
                sw.WriteLine(player.Name);
                sw.WriteLine(player.Health);
                //sw.WriteLine(player.Position);
                //sw.WriteLine(player.Rotation);
                sw.WriteLine(player.PlayerDead);
            }
        }

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();

            if (!File.Exists(SavePath))//���������, ���������� �� ����, ����� �� �������� ������
            {
                Debug.Log("FILE NOT EXIST");//���� ���� �����������, �� �������� �������...
                return result;//� ���������� ������ rusult
            }
            using (StreamReader sr = new StreamReader(SavePath))//���� ��� ������ ����� StreamReader
            {
                result.Name = sr.ReadLine();
                result.Health = Convert.ToInt32(sr.ReadLine());
               
                result.PlayerDead = Convert.ToBoolean(sr.ReadLine());
            }


                return result;
        }
    }
}