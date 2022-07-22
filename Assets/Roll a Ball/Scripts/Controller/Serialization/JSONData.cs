using System.IO;//библиотека ввода-вывода
using UnityEngine;

namespace Maze
{

    public class JSONData : ISaveData
    {
        //заведем путь до директории сохранени€
        string SavePath = Path.Combine(Application.dataPath, "JSONData.json");//комбинировать будем из нескольких аргументов. Ёто название файла и то, где у нас будет лежать директори€ игры
        public void SaveData(PlayerData player)
        {
            string FileJSON = JsonUtility.ToJson(player);
            File.WriteAllText(SavePath, FileJSON);//записать все наши результаты по этому адресу
        }
        public PlayerData Load()
        {
            
            PlayerData result = new PlayerData();

            if (!File.Exists(SavePath))//провер€ем, существует ли файл, чтобы не получить ошибку
            {
                Debug.Log("FILE NOT EXIST");//если файл отсутствует, то ƒебагЋог выводим...
                return result;//и возвращаем пустой rusult
            }
            string json = File.ReadAllText(SavePath);//если файл существует, то заводим переменную и читаем текс по этому адресу
            result = JsonUtility.FromJson<PlayerData>(json);//присваеваем ему результат выполнени€ JsonUtility

            return result;
        }

       
    }
}
