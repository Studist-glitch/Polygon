using System.Threading.Tasks;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 30f;
    [SerializeField] private string tagEnemy = "Enemy";

    private ParticlePool pool;

    private void Start()
    {
        pool = FindFirstObjectByType<ParticlePool>(FindObjectsInactive.Include);
    }

    public async Task OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(tagEnemy))
        {
            if (collider.TryGetComponent(out IDamageble enemy))
            {
                await pool.TryActive("Damage", collider.ClosestPoint(transform.position));
                enemy.TakeDamage(damage);
            }
        }
    }
}