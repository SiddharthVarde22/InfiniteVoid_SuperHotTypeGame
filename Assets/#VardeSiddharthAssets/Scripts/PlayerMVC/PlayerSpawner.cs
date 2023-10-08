using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    PlayerScriptableObject playerScriptableObject;
    [SerializeField]
    PlayerView playerView;

    private void Awake()
    {
        PlayerController playerController = new PlayerController(playerScriptableObject, playerView);
    }
}
