using Assets.Scripts.Controllers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal sealed class Main : MonoBehaviour
    {
        [SerializeField] private GameObject _playerTankGO;
        [SerializeField] private GameObject[] _enemyTankGOs;

        private static Main _instance;
        private InputController _inputController;
        private ManagerTank _managerTank;
        private BulletManager _bulletManager;

        private List<IUpdate> _updatesList = new List<IUpdate>();

        internal static Main Instance => _instance;
        internal ManagerTank ManagerTank => _managerTank;
        internal BulletManager BulletManager => _bulletManager;

        private void Start()
        {
            _instance = this;
            _inputController = new InputController();
            _bulletManager = new BulletManager();


            var enemyTankControllerList = new List<EnemyTankController>();

            for (int numberEnemyTankGO = 0; numberEnemyTankGO < _enemyTankGOs.Length; numberEnemyTankGO++)
            {
                var enemyTankController = new EnemyTankController(_enemyTankGOs[numberEnemyTankGO], _bulletManager);
                enemyTankControllerList.Add(enemyTankController);
            }


            var playerTankController = new PlayerTankController(_playerTankGO, _bulletManager, _inputController);


            _managerTank = new ManagerTank(playerTankController, enemyTankControllerList);


            _updatesList.Add(_inputController);
            _updatesList.Add(_managerTank);
            _updatesList.Add(_bulletManager);
        }

        private void Update()
        {
            for (int numberUpdate = 0; numberUpdate < _updatesList.Count; numberUpdate++)
                _updatesList[numberUpdate].Update();

            if (_inputController.IsSpace) RestartScene();
        }

        internal void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}