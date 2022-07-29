using System.IO;//понадобится ввод/вывод, потому что будем работать с директориями
using System.Collections.Generic;//понадобится, потому что будем хранить здесь список трансформов
using UnityEngine;
using UnityEditor.SceneManagement;

//это отладочный скрипт. При сборке игры он не будет отображаться

#if UNITY_EDITOR//флаги компиляции
public class SaveBonusesView : MonoBehaviour
{
   //здесь будет лист всех нод, которые мы будем сохранять(лист трансформов)
    public List<Transform> bonuses = new List<Transform>();//пусть будут бонусы
    private string savePath;//эта строка будет свойством для удобства
    public string directoryName;//добавим строку для имени директории, чтобы здесь хранить папки
    public string SceneName;//добавим имя сцены
    public string SavingPath { get => savePath; set => savePath = value; }

    private void OnDrawGizmos()//этот метод работает в редакторе
    {//будем запрашивать имя сцены и остальные необходимые нам параметры
     //здесь мы формируем наш SavingPath
        SceneName = EditorSceneManager.GetActiveScene().name;
        directoryName = "Bonuses Data";
        SavingPath = Path.Combine(Application.dataPath + "/" + directoryName, "BonusesData_" + SceneName + ".xml");
    }
}
#endif //то что между этими тегами в итоговой сборке будет вырезаться, если мы работаем не на этой платформе