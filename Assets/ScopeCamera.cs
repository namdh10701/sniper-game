using System;
using UnityEngine;

public class ScopeCamera : MonoBehaviour
{
    Camera cam;
    float withoutZoomFOV = 60;
    float minZoomFOV = 40;
    float maxZoomFOV = 20;

    public float lastAmount;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = withoutZoomFOV;
    }

    public void OnZoomAdjust(float amount)
    {
        lastAmount = amount;
        if (amount == 0)
        {
            OnZoomCancel();
        }
        else
        {
            cam.fieldOfView = minZoomFOV - amount * Math.Abs(maxZoomFOV - minZoomFOV);
        }
    }
    private void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * 1000, Color.red);
    }

    public void OnZoomAdjust()
    {
        cam.fieldOfView = minZoomFOV - lastAmount * Math.Abs(maxZoomFOV - minZoomFOV);
    }
    public void OnZoomCancel()
    {
        cam.fieldOfView = withoutZoomFOV;
    }
}
