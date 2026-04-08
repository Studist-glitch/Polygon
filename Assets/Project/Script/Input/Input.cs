using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Polygon
{
    public class Input : MonoBehaviour
    {
        private InputController action;
        private IInputDevice device;

        [SerializeField] private Controller controller;
        [SerializeField] private AnimController animator;

        private void Start()
        {
            action = new InputController();
            device = (SystemInfo.deviceType == DeviceType.Desktop || SystemInfo.deviceType == DeviceType.Console) ? new InputComputer(action, controller) : new InputPhone(action, controller);
            action?.Enable();

            action.Player.Attack.started += StartAttack;
            action.Player.Attack.canceled += CancelAttack;

            StartCoroutine(InputUpdate());
        }

        private void OnEnable() => action?.Enable();
        private void OnDisable() => action?.Disable();
        private void OnDestroy() => action?.Dispose();

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