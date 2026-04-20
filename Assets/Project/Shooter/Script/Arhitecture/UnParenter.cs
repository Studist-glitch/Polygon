using UnityEngine;

namespace Polygon.Samurai
{
    public class UnParenter : MonoBehaviour
    {
        private void Start()
        {
            transform.parent = null;
        }
    }
}