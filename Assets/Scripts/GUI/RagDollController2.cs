using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagDollController2 : MonoBehaviour
{
    private Rigidbody[] _rbs; //��� ����������� ������ ����� ���������.01
    private Collider[] _colliders; // ����� ����������� ����������.02

    private Animator _animator; //.03
    //private NavMeshAgent _agent; //.04  
    // ����� �� ������ ��������� �������. ����� �� ���� ������.05 (� ������ ������ ��� ������ ���������)

    
    void Start()
    {
        _animator = GetComponent<Animator>();// ������ ��� ��� ����� �����.05
        //_agent = GetComponent<NavMeshAgent>();

        _rbs = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Kill();

        if (Input.GetKeyDown(KeyCode.L))
            Revive();
    }

    private void SetRagDoll(bool isActive)//.06
    {
        foreach(var rb in _rbs)//��������� �� ��� ����� �����������
        {
            rb.isKinematic = !isActive;
            if(isActive)//���� �������, �� ������ ������(���� �������)
            {
                rb.AddForce(Vector3.up * 0.5f, ForceMode.Impulse);
            }
        }

        foreach (var collider in _colliders)//��������� �� ��� ����� �����������
        {
                       
                collider.enabled = isActive;
            
        }

        _rbs[0].isKinematic = isActive;
        _colliders[0].enabled = !isActive;
    }

    public void Kill()
    {
        SetRagDoll(true);

        _animator.enabled = false;
        //_agent.enabled = false;
        

    }

    public void Revive()
    {
        SetRagDoll(false);

        _animator.enabled = true;
        //_agent.enabled = true;
    }
}
