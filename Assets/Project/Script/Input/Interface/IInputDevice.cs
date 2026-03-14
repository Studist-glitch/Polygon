using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Polygon
{
    interface IInputDevice
    {
        Vector2 GetMove();
        Vector2 GetLook();

        void Jump(InputAction.CallbackContext context);
    }
}