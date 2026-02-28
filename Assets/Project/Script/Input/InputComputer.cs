using UnityEngine;

namespace Polygon
{
    public class InputComputer : IInputDevice
    {
        private readonly InputController action;

        public InputComputer(InputController action)
        {
            this.action = action;
        }

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