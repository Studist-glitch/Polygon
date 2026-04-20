using UnityEngine;


namespace Polygon.Samurai
{
    public class DeathPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        private PlayerHealth health;

        public void Init(PlayerHealth health)
        {
            this.health = health;

            health.DeathReceived += OnDeathReceived;

            panel.SetActive(false);
        }

        private void OnDestroy()
        {
            if (health != null) health.DeathReceived -= OnDeathReceived;
        }

        private void OnDeathReceived()
        {
            panel.SetActive(true);
        }
    }
}