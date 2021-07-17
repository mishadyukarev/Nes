using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal class BulletController : IUpdate
    {
        private GameObject _bulletGO;
        private Vector3 _vectorSpeedAndDirect;

        private float _speedBullet = 5;

        internal int InstanceID => _bulletGO.GetInstanceID();

        internal BulletController(GameObject bulletGO)
        {
            _bulletGO = bulletGO;
        }


        public void Update()
        {
            _vectorSpeedAndDirect = _bulletGO.transform.up * Time.deltaTime * _speedBullet;
            _bulletGO.transform.localPosition += _vectorSpeedAndDirect;
        }
    }
}
