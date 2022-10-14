using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.XR;

public class Module_XRInput : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] XRBinding[] L_bindings;
    [SerializeField] XRBinding[] R_bindings;
    private InputDevice L_Con;
    private InputDevice R_Con;
#pragma warning restore 0649
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        L_Con = devices[1];
        R_Con = devices[2];
    }
    private void Update()
    {
        foreach (var binding in L_bindings)
            binding.Update(L_Con);
        foreach (var binding in R_bindings)
            binding.Update(R_Con);
    }
}

[Serializable]
public class XRBinding
{
#pragma warning disable 0649
    [SerializeField] XRButton button;
    [SerializeField] PressType pressType;
    [SerializeField] UnityEvent OnActive;
#pragma warning restore 0649

    bool isPressed;
    bool wasPressed;

    public void Update(InputDevice device)
    {
        device.TryGetFeatureValue(XRStatics.GetFeature(button), out isPressed);
        bool active = false;

        switch (pressType)
        {
            case PressType.Continuous: active = isPressed; break;
            case PressType.Begin: active = isPressed && !wasPressed; break;
            case PressType.End: active = !isPressed && wasPressed; break;
        }

        if (active) OnActive.Invoke();
        wasPressed = isPressed;
    }
}

public enum XRButton
{
    Trigger,
    Grip,
    Primary,
    PrimaryTouch,
    Secondary,
    SecondaryTouch,
    Primary2DAxisClick,
    Primary2DAxisTouch
}

public enum PressType
{
    Begin,
    End,
    Continuous
}

public static class XRStatics
{
    public static InputFeatureUsage<bool> GetFeature(XRButton button)
    {
        switch (button)
        {
            case XRButton.Trigger: return CommonUsages.triggerButton;
            case XRButton.Grip: return CommonUsages.gripButton;
            case XRButton.Primary: return CommonUsages.primaryButton;
            case XRButton.PrimaryTouch: return CommonUsages.primaryTouch;
            case XRButton.Secondary: return CommonUsages.secondaryButton;
            case XRButton.SecondaryTouch: return CommonUsages.secondaryTouch;
            case XRButton.Primary2DAxisClick: return CommonUsages.primary2DAxisClick;
            case XRButton.Primary2DAxisTouch: return CommonUsages.primary2DAxisTouch;
            default: Debug.LogError("button " + button + " not found"); return CommonUsages.triggerButton;
        }
    }
}