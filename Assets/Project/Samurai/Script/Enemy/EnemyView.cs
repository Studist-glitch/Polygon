using UnityEngine;

namespace Polygon.Samurai
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private AnimController animator;
        [SerializeField] private string tagEnemy = "Player";

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(tagEnemy))
            {
                animator.SetAttack(true);
            }
        }

        public void OnTriggerExit(Collider collider)
        {
            if (collider.CompareTag(tagEnemy))
            {
                animator.SetAttack(false);
            }
        }
    }
}