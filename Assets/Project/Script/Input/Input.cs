using System.Collections;
using UnityEngine;

namespace Polygon
{
    public class Input : MonoBehaviour
    {
        private InputController action;
        private IInputDevice device;

        [SerializeField] private Controller controller;

        private void Start()
        {
            action = new InputController();
            device = SystemInfo.deviceType == DeviceType.Desktop || SystemInfo.deviceType == DeviceType.Console ? new InputComputer(action) : new InputPhone(action);

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
            }
        }
    }
}