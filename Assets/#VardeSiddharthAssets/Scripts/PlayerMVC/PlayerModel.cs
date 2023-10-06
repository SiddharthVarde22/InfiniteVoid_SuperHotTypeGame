
using UnityEngine;

public class PlayerModel
{
    PlayerController playerController;
    public PlayerScriptableObject PlayerScriptableObject { get; private set; }

    public PlayerModel(PlayerScriptableObject playerScriptableObject, PlayerController playerController)
    {
        this.PlayerScriptableObject = playerScriptableObject;
        this.playerController = playerController;
    }
}
