using UnityEngine;

namespace Polygon.Samurai
{
    public class AnimController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private int attackHash;

        private void Start()
        {
            attackHash = Animator.StringToHash("IsAttack");
        }

        public void SetAttack(bool value)
        {
            animator.SetBool(attackHash, value);
        }
    }
}