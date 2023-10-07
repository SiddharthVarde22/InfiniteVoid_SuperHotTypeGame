
using UnityEngine;

public class InputService : MonoBehaviour, IGameService
{
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public float RotationXInput { get; private set; }
    public float RotationYInput { get; private set; }

    private void OnEnable()
    {
        RegisterServive(TypesOfService.InputService, this);
    }

    public void RegisterServive(TypesOfService typeOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<InputService>(typeOfService, (InputService)gameService);
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        RotationXInput = Input.GetAxis("Mouse X");
        RotationYInput = Input.GetAxis("Mouse Y") * -1f;
    }
}
