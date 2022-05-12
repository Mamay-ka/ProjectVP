using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float VisionRadius = 0;
    [SerializeField] Transform Ghost;
    [SerializeField] Transform Sphere;
    [SerializeField] Transform AmmoHead;
    [SerializeField] float RotationSpeed = 1;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float CooldownTime;
   

    private SphereCollider _visionCollider;
    private Transform _playerPos;
    private float _currentTime;

    

    void Awake()
    {
        _visionCollider = GetComponent<SphereCollider>();
    }

    void Start()
    {
        _visionCollider.radius = VisionRadius;
        _currentTime = CooldownTime;
        //StartCoroutine(Fire());// ������ ��������. 
        //StopCoroutine(Fire());// ���������� ��������(���������� ���� ���).
        //StopAllCoroutines();// ���������� ��� ��������.
    }

    
    void Update()
    {
        if (_playerPos != null)
        {
            _currentTime += Time.deltaTime;
            var rotDirection = Ghost.position - Sphere.position;
            var targetRotation = Quaternion.LookRotation(rotDirection.normalized);
            Sphere.rotation = Quaternion.Lerp(Sphere.rotation, targetRotation, RotationSpeed * Time.deltaTime);// ��������� ������� ������ ����� �� �������.
        }

        
        


    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player")) 
        {
            _playerPos = other.gameObject.transform;
        }
        
    }

    /*private void OnTriggerStay(Collider other) // ����������, ��� ��� ����� ������������ ���
    {
        if (other.CompareTag("Player") && _currentTime >= CooldownTime)
        {
            
            var bullet = Instantiate(BulletPrefab, AmmoHead.position, Quaternion.identity);
            //bullet.GetComponent<Bullet>().TargetPos = _playerPos.position; - �� ����������, ���� ���������� ���� �� ������ ������, � �� ����� ���������.
            bullet.GetComponent<Bullet>().MoveBullet(_playerPos.position - bullet.transform.position);
            _currentTime = 0;
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (_currentTime >= CooldownTime)
        {
            var ray = new Ray(AmmoHead.position, AmmoHead.forward); // ������� ���
            Debug.DrawRay(AmmoHead.position, AmmoHead.forward * 100, Color.red);

            if (Physics.Raycast(ray, out var hit, Single.PositiveInfinity)) //������� ������ ����. ���� ����� �� ������������, ��� ���������� ��������� �� ����������� � ������ �� ��������.
            {
                if (hit.collider.CompareTag("Player"))
                {
                    var bullet = Instantiate(BulletPrefab, AmmoHead.position, Quaternion.identity);
                    
                    bullet.GetComponent<Bullet>().MoveBullet(_playerPos.position - bullet.transform.position);
                }
            }
           // Physics.RaycastAll(); // ���������� ������ � ���� ������������ � �����.

            
            _currentTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerPos = null;
        }
    }

    /*IEnumerator Fire() //�������� ��� ������������ ��������.
    {
        while(true)
        {
            var bullet = Instantiate(BulletPrefab, AmmoHead.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().MoveBullet(Sphere.forward);
            yield return new WaitForSeconds(1); //null;
        }
         
    }*/
}
