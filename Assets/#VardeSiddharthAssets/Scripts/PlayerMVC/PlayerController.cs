
using UnityEngine;

public class PlayerController
{
    PlayerModel playerModel;
    PlayerView playerView;

    public PlayerController(PlayerScriptableObject playerScriptableObject, PlayerView playerView)
    {
        playerModel = new PlayerModel(playerScriptableObject, this);
        this.playerView = GameObject.Instantiate<PlayerView>(playerView);
        this.playerView.SetPlayerController(this);
    }

    public void PlayerMove(float horizontalInput, float verticalInput)
    {
        playerView.playerRigidbody.MovePosition( 
            ((verticalInput * playerView.transform.forward) + (horizontalInput * playerView.transform.right)) *
            playerModel.PlayerScriptableObject.moveSpeed * Time.deltaTime);
    }
}
