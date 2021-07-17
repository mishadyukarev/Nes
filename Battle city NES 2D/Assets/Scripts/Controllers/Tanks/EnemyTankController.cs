using UnityEngine;
using static Assets.Scripts.Consts.NameConsts;

namespace Assets.Scripts.Controllers
{
    internal sealed class EnemyTankController : TankController
    {
        private float _timeBeetwenAttack = 0.8f;
        private float _currentTimeForAttack = 0.8f;

        private float _maxDistanceForRaycast = 5f;
        private float _maxDistanceForLimits = 1;
        private float _maxDistanceForEnemy = 1;
        private float _maxDistanceForWall = 0.3f;

        private byte _forInclusive = 1;

        private byte _minForRandomDirect = 1;
        private byte _maxForRandomDirect = 2;

        private DirectTypes _currentDirectType;

        internal EnemyTankController(GameObject enemyTankGO, BulletManager bulletManager) : base(enemyTankGO, bulletManager)
        {
            var randomDirect = (DirectTypes)Random.Range((byte)MinDirect, (byte)MaxDirect + _forInclusive);
            _currentDirectType = randomDirect;
        }

        public override void Update()
        {
            base.Update();

            _currentRaycast = Physics2D.Raycast(_posForStartAttack.transform.position, _posForStartAttack.transform.up, _maxDistanceForRaycast);

            if (_currentRaycast)
            {
                var currentTag = _currentRaycast.collider.gameObject.tag;

                if (_currentRaycast.distance <= _maxDistanceForLimits && currentTag == LIMITS_TAG)
                {
                    _currentDirectType = RandomDirect(_currentDirectType);
                }

                else if (_currentRaycast.distance <= _maxDistanceForEnemy && currentTag == ENEMY_TANK_TAG)
                {
                    _currentDirectType = RandomDirect(_currentDirectType);
                }

                else if (currentTag == PLAYER_TANK_TAG)
                {
                    _currentTimeForAttack += Time.deltaTime;

                    if (_currentTimeForAttack >= _timeBeetwenAttack)
                    {
                        _currentTimeForAttack = 0;
                        _bulletManager.CreateBulletAndRun(_posForStartAttack, ENEMY_BULLET_TAG);
                    }
                }

                else if (_currentRaycast.distance <= _maxDistanceForWall && currentTag == WALL_TAG)
                {
                    _currentDirectType = RandomDirect(_currentDirectType);
                }
            }

            ShiftTank(_currentDirectType);
        }


        private DirectTypes RandomDirect(DirectTypes currentDirectType)
        {
            currentDirectType += Random.Range(_minForRandomDirect, _maxForRandomDirect + _forInclusive);
            if (currentDirectType < MinDirect) currentDirectType = DirectTypes.Left;
            if (currentDirectType > MaxDirect) currentDirectType = DirectTypes.Left;

            return currentDirectType;
        }
    }
}
