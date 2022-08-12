using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    internal sealed class Shooting : IShoot
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;

        public Shooting(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }
        public void Shoot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
    }
}
