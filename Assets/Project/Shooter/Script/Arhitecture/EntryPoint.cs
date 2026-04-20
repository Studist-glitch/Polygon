using UnityEngine;

namespace Polygon.Samurai
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Camera camera = FindFirstObjectByType<Camera>(FindObjectsInactive.Include);
            Controller controller = FindFirstObjectByType<Controller>(FindObjectsInactive.Include);
            PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>(FindObjectsInactive.Include);
            DeathPanel deathPanel = FindFirstObjectByType<DeathPanel>(FindObjectsInactive.Include);
            Input input = FindFirstObjectByType<Input>(FindObjectsInactive.Include);

            controller.Init(camera);
            deathPanel.Init(playerHealth);
            input.Init(playerHealth);
        }
    }
}