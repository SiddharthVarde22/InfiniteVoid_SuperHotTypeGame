using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offSet;

    // Update is called once per frame
    private void LateUpdate()
    {
        if(playerTransform == null)
        {
            GetPlayerRefrence();
        }
        ChangeCameraPosition();
        ChangeCameraRotation();
    }

    private void ChangeCameraPosition()
    {
        transform.position = playerTransform.position + (transform.rotation * offSet);
    }

    private void ChangeCameraRotation()
    {
        transform.rotation = playerTransform.rotation;
    }

    private void GetPlayerRefrence()
    {
        playerTransform = ServiceLocator.Instance.GetService<GameObjectsCollectorService>
            (TypesOfService.CollecterService).playerView.transform;
    }
}
