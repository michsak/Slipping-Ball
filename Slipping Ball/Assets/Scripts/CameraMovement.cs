using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 newPositionCamera = new Vector3(0f, 0f, -3.5f);
    Vector3 newPositionCollision = new Vector3(-1.5f, 1f, -0.5f);
    Vector3 cameraTranslation = new Vector3(0.15f, 1.75f, 4f);
    Vector3 cameraCollisionTranslation = new Vector3(-0.5f, 2f, 4f);

    bool clearSlip = true;
    bool playerMove = true;
    bool firstChange = true;

    private void FixedUpdate()
    {
        if (!clearSlip)
        {
            MoveCameraOnCollision();
        }

        if (!playerMove)
        {
            MoveCameraStraight();
        }
    }

    private void MoveCameraStraight()
    {
        float speed = 3f;
        if (!firstChange)
        {
            newPositionCamera += cameraTranslation;
            newPositionCollision += cameraCollisionTranslation;
            firstChange = true;
        }
        transform.position = Vector3.Lerp(transform.position, newPositionCamera, speed*Time.deltaTime);
    }

    private void MoveCameraOnCollision()
    {
        float speed = 2f;
        transform.position = Vector3.Slerp(transform.position, newPositionCollision, Time.deltaTime * speed);
        transform.LookAt(player);
    }

    public void SetCameraOnCollision (bool parameter)
    {
        clearSlip = parameter;
    }

    public void SetCameraMove(bool parameter)
    {
        playerMove = parameter;
        firstChange = false;
    }
}
