using System.IO;//ввод/вывод, чтобы сохран€ть и загружать
using System;
using System.Xml;
using UnityEngine;

//способ сохранени€ через XML-документ 
namespace Maze
{

    public class XMLData : ISaveData
    {
        //заведем путь до директории сохранени€
        string SavePath = Path.Combine(Application.dataPath, "XMLData.xml");//комбинировать будем из нескольких аргументов. Ёто название файла и то, где у нас будет лежать директори€ игры
        public void SaveData(PlayerData player)
        {
            XmlDocument xmlDoc = new XmlDocument();//воспользуемс€ классом XmlDocument и создадим его экземпл€р
            XmlNode rootNode = xmlDoc.CreateElement("Player"); //необходимо создать рутЌоду
            xmlDoc.AppendChild(rootNode);//дальше нужно св€зать XmlDocument и rootNode(добавить дочерний элемент внутрь)

            XmlElement element = xmlDoc.CreateElement("PlayerName");//дальше создадим XmlElement и добавим внутрь ноды. —оздадим переменную дл€ XmlElement
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);//после того, как элемент создан, прикрепл€ем его к рутЌоду

            //повторим это несколько раз и будем мен€ть только название элемента
            
            element = xmlDoc.CreateElement("PlayerHealth");
            element.SetAttribute("value", player.Health.ToString());//данные по здоровью нужно преобразовать в строку
            rootNode.AppendChild(element);                          //потому что атрибут SetAttribute устанавливаетс€, как строка

            element = xmlDoc.CreateElement("isDead");
            element.SetAttribute("value", player.PlayerDead.ToString());//здесь то же самое преобразование в строку
            rootNode.AppendChild(element);

            //дальше нам необходимо сохранить наш документ.
            //дл€ этого есть метод Save
            xmlDoc.Save(SavePath);//передаем путь, куда бы мы хотели записать

        }

        public PlayerData Load()
        {

            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))//провер€ем, существует ли файл, чтобы не получить ошибку
            {
                Debug.Log("FILE NOT EXIST");//если файл отсутствует, то ƒебагЋог выводим...
                return result;//и возвращаем пустой rеsult
            }

            using (XmlTextReader reader = new XmlTextReader(SavePath))//загрузку файла делаем через юзинг
            {
                while(reader.Read())//до тех пор, пока –идер может читать(возвращать true)
                {
                    if(reader.IsStartElement("PlayerName"))//если –идер читает стартовый элемент
                    {
                        result.Name = reader.GetAttribute("value");//то мы добавл€ем результат считывани€ в переменную резалт
                    }

                    if(reader.IsStartElement("PlayerHealth"))//если –идер читает стартовый элемент
                    {
                        result.Health = Convert.ToInt32(reader.GetAttribute("value"));//то мы добавл€ем результат считывани€ в переменную резалт
                    }

                    if(reader.IsStartElement("isDead"))//если –идер читает стартовый элемент
                    {
                        result.PlayerDead = Convert.ToBoolean(reader.GetAttribute("value"));//то мы добавл€ем результат считывани€ в переменную резалт
                    }
                }
            }
            return result;

            
        }
    }
}
    

    

