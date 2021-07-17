using Assets.Scripts.Consts;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal class PlayerTankController : TankController
    {
        private InputController _inputController;

        internal PlayerTankController(GameObject playerTankGO, BulletManager bulletManager, InputController inputController) : base(playerTankGO, bulletManager)
        {
            _inputController = inputController;
        }

        public override void Update()
        {
            base.Update();

            if (_inputController.IsRightArrow) ShiftTank(DirectTypes.Right);
            else if (_inputController.IsLeftArrow) ShiftTank(DirectTypes.Left);
            else if (_inputController.IsUpArrow) ShiftTank(DirectTypes.Up);
            else if (_inputController.IsDownArrow) ShiftTank(DirectTypes.Down);

            if (_inputController.IsLeftMouseButton)
                _bulletManager.CreateBulletAndRun(_posForStartAttack, NameConsts.PLAYER_BULLET_TAG);
        }
    }
}
