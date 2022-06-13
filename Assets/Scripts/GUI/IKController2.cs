using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController2 : MonoBehaviour
{
    [SerializeField] private Transform _handPoint; //����� ��������� ����.01
    [SerializeField] private Transform _handPoint2;
    [SerializeField] private Transform _headPoint; //����� ��������� ������.02

    [SerializeField, Range(0f, 1f)] private float _handWeight;//��� ����.03
    [SerializeField] private Vector3 _handOffSet;//����� ���� ������� �������.12

    [SerializeField, Range(0f, 1f)] private float _lookIKWeight;//��� ������.04

    private Animator _animator; //��� �������� �������� �� ��������, ������� �������� ��������.05

    void Start()
    {
        _animator = GetComponent<Animator>();//�������� ������ � ��������� ���������.06
    }

    private void OnAnimatorIK(int layerIndex)//����������� ����� ��� ������ � ��-���������.07
    {
        if(_handPoint)//���������, ���� �� � ��� �������� � ���� ������ ������, ����.08
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);//����� ����.09
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);//������� ����, ���� ����� �������� ������ ��� �����.10

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _handWeight);

            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint.position + _handOffSet);//������ ��� �������, �� ������� ����� ��������� ���.11
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint.rotation);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, _handPoint2.position + _handOffSet);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _handPoint2.rotation);
        }

        if(_headPoint)//��� ������.12
        {
            _animator.SetLookAtWeight(_lookIKWeight);//�����.13
            //_animator.SetLookAtPosition(_headPoint.position);//�������� �� �������� ��� ������.14

            var position = transform.InverseTransformPoint(_headPoint.position);//������� ������ �� ������ �� ������������ ����������.15
            var strength = position.magnitude;

            if(strength < 4)
            {
                _animator.SetLookAtPosition(_headPoint.position); 
            }
            else
            {
                
            }
        }
    }
   
}
