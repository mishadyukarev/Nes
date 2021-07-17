using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal abstract class TankController : IUpdate
    {
        private Vector3 _forAddingPos;
        private Vector3 _forSetRot;

        protected RaycastHit2D _currentRaycast;
        protected GameObject _tankGO;
        protected Transform _posForStartAttack;
        protected int _speedTank = 3;
        protected BulletManager _bulletManager;

        protected float DeltaTime => Time.deltaTime;
        protected DirectTypes MinDirect => DirectTypes.Left;
        protected DirectTypes MaxDirect => DirectTypes.Up;
        internal int InstanceID => _tankGO.GetInstanceID();


        protected TankController(GameObject tankGO, BulletManager bulletManager)
        {
            _tankGO = tankGO;
            _bulletManager = bulletManager;
            _posForStartAttack = _tankGO.transform.Find("PosForStartAttack");
            _forAddingPos = new Vector3();
            _forSetRot = new Vector3();
        }

        public virtual void Update()
        {

        }

        internal void ShiftTank(DirectTypes directType)
        {
            switch (directType)
            {
                case DirectTypes.None:
                    throw new System.Exception();

                case DirectTypes.Left:
                    _forAddingPos.x = -_speedTank * DeltaTime;
                    _forAddingPos.y = default;
                    _tankGO.transform.position += _forAddingPos;

                    _forSetRot.z = 90;
                    _tankGO.transform.eulerAngles = _forSetRot;
                    break;

                case DirectTypes.Right:
                    _forAddingPos.x = _speedTank * DeltaTime;
                    _forAddingPos.y = 0;
                    _tankGO.transform.position += _forAddingPos;

                    _forSetRot.z = -90;
                    _tankGO.transform.eulerAngles = _forSetRot;
                    break;

                case DirectTypes.Down:
                    _forAddingPos.x = 0;
                    _forAddingPos.y = -_speedTank * DeltaTime;
                    _tankGO.transform.position += _forAddingPos;

                    _forSetRot.z = 180;
                    _tankGO.transform.eulerAngles = _forSetRot;
                    break;

                case DirectTypes.Up:
                    _forAddingPos.x = 0;
                    _forAddingPos.y = _speedTank * DeltaTime;
                    _tankGO.transform.position += _forAddingPos;

                    _forSetRot.z = 0;
                    _tankGO.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;

                default:
                    throw new System.Exception();
            }
        }
    }
}
