using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

namespace Maze
{
    [CustomEditor(typeof(SaveBonusesView))]//атрибут нашего класса. Через typeof укажем класс, который хотим расширить

    public class SaveBonuses : Editor//наследуемся от этого пространства имен
    {
        private static XmlSerializer serializer;//определяем переменную сериализатора
        public List<SVect3> SavingBonusesT = new List<SVect3>();//теперь необходимо завести список сериализуемых нод

        //все основное действие будет происходить в методе ОнИнспекторГУИ
        public override void OnInspectorGUI()//переопределим метод через оверрайд
        {
            base.OnInspectorGUI();//сначала выполнится основной родительский класс, который отрисует нам интерфейс

            //а затем мы поверх этого родительского класса внесем свои изменения
            SaveBonusesView saveBonusesView = (SaveBonusesView)target;//создадим ссылку целевого класса, в котором будем применять расширение

            if (serializer == null)//дальше проверяем, что сериалайзер нулл
            {
                serializer = new XmlSerializer(typeof(SVect3[]));//если нулл, то создаем новый экземпляр сериализатора
            }

            //дальше сделаем кнопку Сохранить
            if(GUILayout.Button("Save"))
            {//дальше будем проверять. Если внутри целевого класса есть элементы для сохранения
                if(saveBonusesView.bonuses.Count>0)
                {
                    foreach(Transform item in saveBonusesView.bonuses)//то в этом случае будем их сохранять.Обходить наши трансформы
                    {
                        if(!SavingBonusesT.Contains(item.position))//если SavingBonusesT не содержит текущую трансформу, то мы ее будем туда добавлять
                        {
                            SavingBonusesT.Add(item.position);
                        }
                    }
                }
                //запись будет происходить при нажатии на кнопку, поэтому используем юзинг
                using(FileStream fs = new FileStream(saveBonusesView.SavingPath, FileMode.Create))
                {
                    serializer.Serialize(fs, SavingBonusesT.ToArray());//здесь преобразовываем сериализацию
                }

            }
        }
    }
}
