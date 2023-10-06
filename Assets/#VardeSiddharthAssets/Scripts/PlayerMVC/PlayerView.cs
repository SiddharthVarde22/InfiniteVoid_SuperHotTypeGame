
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;
    private InputService playerInput;

    [SerializeField]
    public Rigidbody playerRigidbody;

    private void Start()
    {
        ServiceLocator.Instance.GetService<GameObjectsCollectorService>(TypesOfService.CollecterService).playerView = this;
    }

    private void Update()
    {
        if (playerInput == null)
        {
            GetInputService();
        }
        PlayerMove();
        PlayerRotate();
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void PlayerMove()
    {
        if (playerInput.HorizontalInput != 0 || playerInput.VerticalInput != 0)
        {
            playerController.PlayerMove(playerInput.HorizontalInput, playerInput.VerticalInput);
        }
    }

    private void PlayerRotate()
    {
        if(playerInput.RotationXInput != 0)
        {
            playerController.PlayerRotate(playerInput.RotationXInput);
        }
    }

    private void GetInputService()
    {
        playerInput = ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService);
    }
}
