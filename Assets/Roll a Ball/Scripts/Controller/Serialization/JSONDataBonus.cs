using System.IO;
using UnityEngine;

namespace Maze
{
    public class JSONDataBonus : ISaveDataBonus
    {
        string SavePathBonus = Path.Combine(Application.dataPath, "JSONDataBonus.json");
        
        public void SaveBonus(GBData gB)
        {
            
            string FileJSONBonus = JsonUtility.ToJson(gB);
            File.WriteAllText(SavePathBonus, FileJSONBonus);
        }

        public GBData LoadBonus()
        {
            GBData resultBonus = new GBData();

            if(!File.Exists(SavePathBonus))
            {
                Debug.Log("FILE NOT EXIST");
                return resultBonus;
            }
            string jsonBonus = File.ReadAllText(SavePathBonus);
            resultBonus = JsonUtility.FromJson<GBData>(jsonBonus);

            return resultBonus;
        }

        
    }
}
