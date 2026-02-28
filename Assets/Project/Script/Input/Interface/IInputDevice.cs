using UnityEngine;

namespace Polygon
{
    interface IInputDevice
    {
        Vector2 GetMove();
        Vector2 GetLook();
    }
}