using UnityEngine;

namespace Polygon
{
    public class InputPhone : IInputDevice
    {
        private readonly InputController action;

        public InputPhone(InputController action)
        {
            this.action = action;
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
    }
}