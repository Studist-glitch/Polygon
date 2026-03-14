using UnityEngine;
using UnityEngine.InputSystem;

namespace Polygon
{
    public class InputPhone : IInputDevice
    {
        private readonly InputController action;
        private readonly Controller controller;

        public InputPhone(InputController action, Controller controller)
        {
            this.action = action;
            this.controller = controller;

            action.Player.Jump.started += Jump;
        }

        //Временно, требуется ввод из интерфейса
        public Vector2 GetMove()
        {
            return action.Player.Move.ReadValue<Vector2>();
        }

        public Vector2 GetLook()
        {
            return action.Player.Look.ReadValue<Vector2>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            controller.Jump();
        }
    }
}