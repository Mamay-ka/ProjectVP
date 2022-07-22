using System;
using UnityEngine;

//здесь будет располагаться только структура
//структура сериализуемого Вектора3, Кватерниона и ГеймОбжекта

//укажем, что структура будет сериализуемая
[Serializable]

public struct SVect3
{
    public float X;
    public float Y;
    public float Z;

    //напишем конструктор для нашей структуры
    public SVect3(float x, float y, float z)
    {
        //в конструктор будем передавать все три параметра, которые нужно будет преобразовывать
        X = x;//назначаем нужные поля
        Y = y;
        Z = z;

    }

    //сделаем явное преобразование. Как оно должно к нам возвращаться.
    public static implicit operator SVect3(Vector3 val)//во что преобразуем что преобразуем
    {
        return new SVect3(val.x, val.y, val.z);//возвращать будем  SVect3. Расписываем, как будет происходить преобразование, какими значениями будет заполняться
    }

    //обратное преобразование из Вектор3 в SVect3
    public static implicit operator Vector3(SVect3 val)//во что преобразуем что преобразуем
    {
        return new Vector3(val.X, val.Y, val.Z);//указываем большие буква, так как передаем другие значения обратно в Вектор3
    }
        
}

//тоже самое сделаем для Кватерниона
[Serializable]

public struct SQuater
{
    public float X;
    public float Y;
    public float Z;
    public float W;//для Кватерниона добавится 4-й параметр  

    //напишем конструктор для нашей структуры
    public SQuater(float x, float y, float z, float w)
    {
        //в конструктор будем передавать все три параметра, которые нужно будет преобразовывать
        X = x;//назначаем нужные поля
        Y = y;
        Z = z;
        W = w;//для Кватерниона добавим 4-й параметр

    }

    //сделаем явное преобразование. Как оно должно к нам возвращаться.
    public static implicit operator SQuater(Quaternion val)//во что преобразуем что преобразуем
    {
        return new SQuater(val.x, val.y, val.z, val.w);//возвращать будем  SQuater. Расписываем, как будет происходить преобразование, какими значениями будет заполняться
    }

    //обратное преобразование из Quaternion в SQuater
    public static implicit operator Quaternion(SQuater val)//во что преобразуем что преобразуем
    {
        return new Quaternion(val.X, val.Y, val.Z, val.W);//указываем большие буква, так как передаем другие значения обратно в Quaternion
    }
}
//для GameObject заведем структуру
[Serializable]
  public struct SObject
  {//заведем некоторое количество переменных
    public string Name;
    public SVect3 Position;
    public SVect3 Scale;
    public SQuater Rotation;

    public SObject(GameObject go)
    {
        Name = go.name;
        Position = go.transform.position;
        Scale = go.transform.localScale;
        Rotation = go.transform.rotation;
    }
  }