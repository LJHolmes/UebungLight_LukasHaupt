using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragUI : MonoBehaviour
{
    public float rotationSpeed = 2f;

    [SerializeField] private GameObject hammer;

    [SerializeField] private bool rotateRight;
    [SerializeField] private bool rotateLeft;

    void Start()
    {
        hammer = GameObject.Find("Hammer_Low");
    }

    private void Update()
    {
        if (rotateRight)
        {
            hammer.transform.Rotate(Vector3.right, rotationSpeed, Space.World);
        }

        if (rotateLeft)
        {
            hammer.transform.Rotate(Vector3.left, rotationSpeed, Space.World);
        }
    }

    public void RotateOnButtonDownRight()
    {
        rotateRight = true;
    }

    public void RotateOnButtonDownLeft()
    {
        rotateLeft = true;
    }

    public void RotateOnButtonUp()
    {
        rotateLeft =  false;
        rotateRight = false;
    }
}
