using System.IO;
using System;
using UnityEngine;

//этот способ просто запись в файл

namespace Maze
{

    public class StreamData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "StreamData.XYZ");//комбинировать будем из нескольких аргументов. Ёто название файла и то, где у нас будет лежать директори€ игры
        public void SaveData(PlayerData player)
        {
            using (StreamWriter sw = new StreamWriter(SavePath))//здес все пишем через StreamWriter
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

            if (!File.Exists(SavePath))//провер€ем, существует ли файл, чтобы не получить ошибку
            {
                Debug.Log("FILE NOT EXIST");//если файл отсутствует, то ƒебагЋог выводим...
                return result;//и возвращаем пустой rusult
            }
            using (StreamReader sr = new StreamReader(SavePath))//здес все читаем через StreamReader
            {
                result.Name = sr.ReadLine();
                result.Health = Convert.ToInt32(sr.ReadLine());
               
                result.PlayerDead = Convert.ToBoolean(sr.ReadLine());
            }


                return result;
        }
    }
}
