using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGO : MonoBehaviour
{
    private bool isRotating = false;
    private Vector3 startMousePosition;

    void OnMouseDown()
    {
        isRotating = true;
        startMousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }

    void OnMouseDrag()
    {
        if (isRotating)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = currentMousePosition.x - startMousePosition.x;
            float deltaY = currentMousePosition.y - startMousePosition.y;

            // Adjust the sensitivity based on your preference
            float rotationSpeed = 0.5f;

            // Rotate the object based on mouse movement
            transform.Rotate(Vector3.up, -deltaX * rotationSpeed, Space.World);
            transform.Rotate(Vector3.right, deltaY * rotationSpeed, Space.World);

            startMousePosition = currentMousePosition;
        }
    }
}
