using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{

    public float sensitivityX = 1.5f;
    public float sensitivityY = 1.5f;

    public float minimumX = -360f;
    public float maximumX = 360f;

    public float minimumY = -60f;
    public float maximumY = 60f;

    public float smoothSpeed = 5f; // Adjust this value to control the smoothness

    float rotationY = 0f;
    float rotationX = 0f;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseX * sensitivityX;
        rotationY += mouseY * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        // Smoothly interpolate between the current rotation and the new rotation
        Quaternion targetRotation = Quaternion.Euler(-rotationY, rotationX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        Debug.DrawLine(transform.position, transform.forward * 1000, Color.green);
    }
}