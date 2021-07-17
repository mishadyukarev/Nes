using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class ManagerTank : IUpdate
    {
        private PlayerTankController _playerTankController;
        private List<EnemyTankController> _enemyTankControllerList;

        internal ManagerTank(PlayerTankController playerTankController, List<EnemyTankController> enemyTankControllerList)
        {
            _playerTankController = playerTankController;
            _enemyTankControllerList = enemyTankControllerList;
        }

        public void Update()
        {
            _playerTankController?.Update();

            foreach (var enemyTankController in _enemyTankControllerList)
                enemyTankController.Update();
        }

        internal void RemoveTank(bool isPlayerTank, GameObject tankForRemove)
        {
            if (isPlayerTank)
            {
                int instanceIDforRemove = tankForRemove.GetInstanceID();

                if (_playerTankController.InstanceID == instanceIDforRemove)
                {
                    GameObject.Destroy(tankForRemove);
                    _playerTankController = default;
                }
            }
            else
            {
                int instanceIDforRemove = tankForRemove.GetInstanceID();
                for (int numberEnemyTankContr = 0; numberEnemyTankContr < _enemyTankControllerList.Count; numberEnemyTankContr++)
                {
                    var curEnemyTank = _enemyTankControllerList[numberEnemyTankContr];
                    if (curEnemyTank.InstanceID == instanceIDforRemove)
                    {
                        _enemyTankControllerList.RemoveAt(numberEnemyTankContr);
                        GameObject.Destroy(tankForRemove);
                    }
                }
            }
        }
    }
}
