using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class BulletManager : IUpdate
    {
        private List<BulletController> _bulletControllerList = new List<BulletController>();

        internal BulletManager()
        {

        }

        public void Update()
        {
            foreach (var item in _bulletControllerList)
                item.Update();
        }


        internal void CreateBulletAndRun(Transform posForStartAttack, string tag)
        {
            var bulletGORes = Resources.Load<GameObject>("Bullet");

            var bulletGO = GameObject.Instantiate(bulletGORes);

            bulletGO.tag = tag;

            bulletGO.transform.position = posForStartAttack.position;
            bulletGO.transform.rotation = posForStartAttack.rotation;

            var bulletController = new BulletController(bulletGO);

            _bulletControllerList.Add(bulletController);
        }

        internal void RemoveBullet(GameObject bulletForRemove)
        {
            for (int currentNumberBullet = 0; currentNumberBullet < _bulletControllerList.Count; currentNumberBullet++)
            {
                var curPlayerBullet = _bulletControllerList[currentNumberBullet];

                if (curPlayerBullet.InstanceID == bulletForRemove.GetInstanceID())
                {
                    GameObject.Destroy(bulletForRemove);
                    _bulletControllerList.RemoveAt(currentNumberBullet);
                }
            }
        }
    }
}
