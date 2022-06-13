using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController2 : MonoBehaviour
{
    [SerializeField] private Transform _handPoint; //точка положения руки.01
    [SerializeField] private Transform _handPoint2;
    [SerializeField] private Transform _headPoint; //точка положения головы.02

    [SerializeField, Range(0f, 1f)] private float _handWeight;//вес руки.03
    [SerializeField] private Vector3 _handOffSet;//чтобы рука сжимала предмет.12

    [SerializeField, Range(0f, 1f)] private float _lookIKWeight;//вес головы.04

    private Animator _animator; //все действие завязано на анимации, поэтому вызываем Аниматор.05

    void Start()
    {
        _animator = GetComponent<Animator>();//получаем доступ к Аниматору персонажа.06
    }

    private void OnAnimatorIK(int layerIndex)//специальный метод для работы с ИК-Анимацией.07
    {
        if(_handPoint)//проверяем, ести ли у нас трансфор к чему тянуть голову, руки.08
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);//тянем руку.09
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);//поворот руки, если нужно схватить объект под углом.10

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _handWeight);

            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint.position + _handOffSet);//данные для формулы, по которой будет рассчитан код.11
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint.rotation);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, _handPoint2.position + _handOffSet);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _handPoint2.rotation);
        }

        if(_headPoint)//для головы.12
        {
            _animator.SetLookAtWeight(_lookIKWeight);//общий.13
            //_animator.SetLookAtPosition(_headPoint.position);//слежение за объектом для головы.14

            var position = transform.InverseTransformPoint(_headPoint.position);//поворот головы на объект на определенном расстоянии.15
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
