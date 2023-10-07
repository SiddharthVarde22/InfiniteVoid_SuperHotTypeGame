
using UnityEngine;

public class TimeSpeedController : MonoBehaviour
{
    //InputService playerInput;

    [SerializeField]
    float timeScaleReductionSpeed = 0.05f, timeScaleIncrementSpeed = 0.1f, minimumTimeScale = 0.02f, maximumTimeScale = 0.8f;

    float currentTimeScale;

    private void Start()
    {
        Time.timeScale = minimumTimeScale;
    }

    private void Update()
    {
        UpdateTimeScale();
    }

    void UpdateTimeScale()
    {
        if (currentTimeScale > minimumTimeScale)
        {
            currentTimeScale -= timeScaleReductionSpeed;
            currentTimeScale = Mathf.Clamp(currentTimeScale, minimumTimeScale, maximumTimeScale);
        }
        Time.timeScale = currentTimeScale;
    }

    public void IncreaseTimeScale()
    {
        currentTimeScale += timeScaleIncrementSpeed;
    }

    public void OnFirePressed()
    {
        currentTimeScale = maximumTimeScale;
    }
}
