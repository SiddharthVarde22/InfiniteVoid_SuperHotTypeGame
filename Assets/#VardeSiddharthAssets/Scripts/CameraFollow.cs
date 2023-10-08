using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offSet;
    [SerializeField]
    private float maxXRotation, minXRotation;

    private float rotationSpeed;
    private Vector3 rotation;
    private InputService playerInput;

    // Update is called once per frame
    private void LateUpdate()
    {
        if(playerTransform == null)
        {
            GetPlayerRefrence();
            GetRotationSpeed();
            rotation = playerTransform.rotation.eulerAngles;
            ChangeCameraPosition();
        }

        if (playerInput == null)
        {
            GetInputService();
        }
        ChangeCameraRotation();
    }

    private void ChangeCameraPosition()
    {
        transform.position = playerTransform.position + (Quaternion.Euler(0,rotation.y,0) * offSet);
    }

    private void ChangeCameraRotation()
    {
        rotation.x = (rotationSpeed * playerInput.RotationYInput) + transform.eulerAngles.x;
        ClampXRotation();
        rotation.y = playerTransform.rotation.eulerAngles.y;
        rotation.z = 0;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void GetPlayerRefrence()
    {
        playerTransform = ServiceLocator.Instance.GetService<GameObjectsCollectorService>
            (TypesOfService.CollecterService).playerView.transform;
    }

    private void GetInputService()
    {
        playerInput = ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService);
    }

    private void GetRotationSpeed()
    {
        rotationSpeed = playerTransform.GetComponent<PlayerView>().GetPlayerRotationSpeed();
    }

    private void ClampXRotation()
    {
        if(rotation.x <= (360 + minXRotation) && rotation.x > 180)
        {
            rotation.x = 360 + minXRotation;
        }
        else if(rotation.x >= maxXRotation && rotation.x <= 180)
        {
            rotation.x = maxXRotation;
        }
    }
}
