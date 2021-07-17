using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal sealed class InputController : IUpdate
    {
        private bool _isRightArrow;
        private bool _isLeftArrow;
        private bool _isUpArrow;
        private bool _isDownArrow;

        private bool _isSpace;

        private bool _isLeftMouseButton;

        internal bool IsRightArrow => _isRightArrow;
        internal bool IsLeftArrow => _isLeftArrow;
        internal bool IsUpArrow => _isUpArrow;
        internal bool IsDownArrow => _isDownArrow;

        internal bool IsSpace => _isSpace;

        internal bool IsLeftMouseButton => _isLeftMouseButton;

        internal InputController()
        {

        }

        public void Update()
        {
            _isRightArrow = Input.GetKey(KeyCode.RightArrow);
            _isLeftArrow = Input.GetKey(KeyCode.LeftArrow);
            _isUpArrow = Input.GetKey(KeyCode.UpArrow);
            _isDownArrow = Input.GetKey(KeyCode.DownArrow);

            _isSpace = Input.GetKeyDown(KeyCode.Space);

            _isLeftMouseButton = Input.GetMouseButtonDown(0);
        }
    }
}
