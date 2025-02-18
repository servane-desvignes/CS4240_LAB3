using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class Grab : MonoBehaviour
{
    public InputActionReference grabAction;
    public InputActionProperty haptic;
    public float _amplitude = 1.0f;
    public float _duration = 0.1f;
    public float _frequency = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (grabAction == null)
            return;
        grabAction.action.Enable();
        haptic.action.Enable();

        grabAction.action.performed += OnActionPerformed;

    }

    void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        var control = grabAction.action.activeControl;
        if (null == control)
            return;

        OpenXRInput.SendHapticImpulse(haptic.action, _amplitude, _frequency, _duration, control.device);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
