using System.IO;
using UnityEngine;

namespace Maze
{
    public class JSonDataBadBonus : ISaveDataBadBonus
    {
        string SavePathBB = Path.Combine(Application.dataPath, "JSONDataBB.json");
        public void SaveBBData(BBData _bb)
        {
            string FileJSONBB = JsonUtility.ToJson(_bb);
            File.WriteAllText(SavePathBB, FileJSONBB);
        }
        public BBData LoadBB()
        {
            BBData resultBB = new BBData();

            if(!File.Exists(SavePathBB))
            {
                Debug.Log("File Not Exist");
                return resultBB;
            }
            string jsonBB = File.ReadAllText(SavePathBB);
            resultBB = JsonUtility.FromJson<BBData>(jsonBB);
            return resultBB;

        }
    }
}
