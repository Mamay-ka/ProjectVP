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
            Instantiate(Prefab, pos.position, Quaternion.identity); - ����� �������� �� ������� �����
        }*/
    }

   
    void Update()
    {
        if(_currentEnemyCount < MaxEnemyCount)
        {
            var PointIndex = Random.Range(0, Positions.Count); // �������� ��������� ����� ��������� ��������
            var HealsGO = Instantiate(Prefab, Positions[PointIndex].position, Quaternion.identity);//������� ������ ����(� ������ ������ �������)
            HealsGO.GetComponent<GetHeals>().GetHealsDestroyed += OnGetHealsDestroyed; //�������� �� �������
            _currentEnemyCount++;
        }
    }

    private void OnGetHealsDestroyed()
    {
        _currentEnemyCount--;
    }
}
