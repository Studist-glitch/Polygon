using UnityEngine;

namespace Polygon
{
    public class UnParenter : MonoBehaviour
    {
        private void Start()
        {
            transform.parent = null;
        }
    }
}