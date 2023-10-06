
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField]
    PlayerInput playerInput;

    [SerializeField]
    public Rigidbody playerRigidbody;

    void Update()
    {
        PlayerMove();
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    void PlayerMove()
    {
        if (playerInput.HorizontalInput != 0 || playerInput.VerticalInput != 0)
        {
            playerController.PlayerMove(playerInput.HorizontalInput, playerInput.VerticalInput);
        }
    }
}
