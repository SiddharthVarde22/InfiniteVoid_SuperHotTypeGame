
using UnityEngine;

public class PlayerView : MonoBehaviour, IDamagable
{
    private PlayerController playerController;
    private InputService playerInput;
    [SerializeField]
    private TimeSpeedController timeController;

    public Rigidbody playerRigidbody;
    public Transform gunHoldingPoint;
    bool hasGun = false;

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
            timeController.IncreaseTimeScale();
        }
    }

    private void PlayerRotate()
    {
        if(playerInput.RotationXInput != 0)
        {
            playerController.PlayerRotate(playerInput.RotationXInput);
            timeController.IncreaseTimeScale();
        }
    }

    private void GetInputService()
    {
        playerInput = ServiceLocator.Instance.GetService<InputService>(TypesOfService.InputService);
    }

    public float GetPlayerRotationSpeed()
    {
        return playerController.GetPlayerRotationSpeed();
    }

    public void OnPlayerShootsBullet()
    {
        timeController.OnFirePressed();
    }

    public void SetHasGun(bool hasGun)
    {
        this.hasGun = hasGun;
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactableObject;

        if(!hasGun && other.TryGetComponent<IInteractable>(out interactableObject))
        {
            interactableObject.OnInteraction(gunHoldingPoint);
        }
    }

    public void GetDamage()
    {
        //player die
    }
}
