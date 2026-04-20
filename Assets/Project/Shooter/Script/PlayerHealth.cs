using System;
using UnityEngine;


namespace Polygon.Samurai
{
    public class PlayerHealth : MonoBehaviour, IDamageble
    {
        public Action DeathReceived;

        [SerializeField] private float health = 100f;
        public float Health { get; private set; }


        private void Start()
        {
            Health = health;
        }

        public bool TakeDamage(float damage)
        {
            Health -= damage;

            if (Health <= 0f)
            {
                Death();
                return true;
            }

            return false;
        }

        private void Death()
        {
            DeathReceived?.Invoke();
        }
    }
}