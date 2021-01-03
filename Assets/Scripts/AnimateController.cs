using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class AnimateController : MonoBehaviour
{

    public InputDeviceCharacteristics controllerChars;
    public GameObject controllerPrefab;
    private InputDevice _controller;

    private GameObject spawnedController;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChars, devices);

        foreach (var device in devices)
        {
            Debug.Log(device.name + " was added with char " + device.characteristics);
            
        }

        if (devices.Count > 0)
        {
            _controller = devices[0];
            if (controllerPrefab)
            {
                spawnedController = Instantiate(controllerPrefab, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _controller.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
            Debug.Log("pressing main button in right controller");

        _controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
            Debug.Log("trigger!");

        _controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxis);
        if (primary2DAxis != Vector2.zero)
            Debug.Log("moving stick");
    }
}
