using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Polygon.Samurai
{
    public class Input : MonoBehaviour
    {
        private InputController action;
        private IInputDevice device;
        private PlayerHealth health;

        [SerializeField] private Controller controller;
        [SerializeField] private AnimController animator;

        public void Init(PlayerHealth health)
        {
            action = new InputController();
            device = (SystemInfo.deviceType == DeviceType.Desktop || SystemInfo.deviceType == DeviceType.Console) ? new InputComputer(action, controller) : new InputPhone(action, controller);
            action?.Enable();

            action.Player.Attack.started += StartAttack;
            action.Player.Attack.canceled += CancelAttack;

            health.DeathReceived += OnDeathReceived;

            StartCoroutine(InputUpdate());
        }

        private void OnDeathReceived()
        {
            OnDisable();
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void OnEnable() => action?.Enable();
        private void OnDisable() => action?.Disable();
        private void OnDestroy()
        {
            action?.Dispose();

            if (health != null) health.DeathReceived -= OnDeathReceived;
        }

        private IEnumerator InputUpdate()
        {
            while (true)
            {
                controller.Move(device.GetMove());
                //controller.Look(device.GetLook());
                yield return null;
            }
        }

        private void StartAttack(InputAction.CallbackContext context)
        {
            animator.SetAttack(true);
        }

        private void CancelAttack(InputAction.CallbackContext context)
        {
            animator.SetAttack(false);
        }
    }
}