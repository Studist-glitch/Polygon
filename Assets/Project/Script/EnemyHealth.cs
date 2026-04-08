using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private float health = 100f;
    public float Health { get; private set; }


    private void Start()
    {
        Health = health;
    }

    public bool TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log(Health);

        if (Health <= 0f)
        {
            Death();
            return true;
        }

        return false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
