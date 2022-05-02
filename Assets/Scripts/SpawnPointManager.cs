using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] List<Transform> Positions;
    [SerializeField] int MaxEnemyCount = 1;

    private int _currentEnemyCount = 0;

    void Start()
    {
        /*foreach(var pos in Positions)
        {
            Instantiate(Prefab, pos.position, Quaternion.identity); - спаун объектов на игровой сцене
        }*/
    }

   
    void Update()
    {
        if(_currentEnemyCount < MaxEnemyCount)
        {
            var PointIndex = Random.Range(0, Positions.Count); // создание рандомных точек появления объектов
            var HealsGO = Instantiate(Prefab, Positions[PointIndex].position, Quaternion.identity);//создаем нового моба(в данном случае лечилку)
            HealsGO.GetComponent<GetHeals>().GetHealsDestroyed += OnGetHealsDestroyed; //подписка на событие
            _currentEnemyCount++;
        }
    }

    private void OnGetHealsDestroyed()
    {
        _currentEnemyCount--;
    }
}
