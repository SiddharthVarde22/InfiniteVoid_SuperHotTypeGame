
using UnityEngine;

public class PlayerController
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    public PlayerController(PlayerScriptableObject playerScriptableObject, PlayerView playerView)
    {
        playerModel = new PlayerModel(playerScriptableObject, this);
        this.playerView = GameObject.Instantiate<PlayerView>(playerView);
        this.playerView.SetPlayerController(this);
    }

    public void PlayerMove(float horizontalInput, float verticalInput)
    {
        playerView.playerRigidbody.MovePosition(playerView.transform.position +
            ((verticalInput * playerView.transform.forward) + (horizontalInput * playerView.transform.right)) *
            playerModel.PlayerScriptableObject.moveSpeed * Time.deltaTime);
    }

    public void PlayerRotate(float rotationInput)
    {
        playerView.playerRigidbody.MoveRotation(
            Quaternion.Euler(playerModel.PlayerScriptableObject.rotationSpeed * rotationInput * playerView.transform.up) * 
            playerView.transform.rotation);
    }
}
