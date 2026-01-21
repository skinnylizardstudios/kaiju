using UnityEngine;

public class EarthGolemProceduralGait : MonoBehaviour, IProceduralAnimator
{
    [Header("Gait Parameters")]
    [SerializeField] private int golemLevel = 3;
    [SerializeField] private float baseWalkSpeed = 2f;
    [SerializeField] private float movementInput = 0f;

    private int _currentLevel;
    private float _gaitTime = 0f;
    private Transform _rootTransform;

    public bool IsInitialized { get; private set; }
    public string SubsystemName => "EarthGolemProceduralGait";

    private void OnEnable()
    {
        if (!IsInitialized)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        if (IsInitialized) return;

        _rootTransform = transform;
        _currentLevel = golemLevel;
        IsInitialized = true;
    }

    public void Shutdown()
    {
        IsInitialized = false;
    }

    private void Update()
    {
        if (!IsInitialized || _rootTransform == null) return;

        _gaitTime += Time.deltaTime;
        UpdateGait(Time.deltaTime);
    }

    private void UpdateGait(float deltaTime)
    {
        var gaitData = GetGaitDataForLevel(_currentLevel);
        if (_rootTransform.childCount > 0)
        {
            ApplyGaitDeformations(gaitData, movementInput);
        }
    }

    private GaitData GetGaitDataForLevel(int level)
    {
        float levelNormalized = Mathf.Clamp01((level - 1f) / 9998f);

        return new GaitData
        {
            WalkSpeed = baseWalkSpeed / (1f + levelNormalized * 0.8f),
            GroundShakeRadius = 5f + levelNormalized * 15f,
            StepCadence = 1.2f / (1f + levelNormalized * 0.6f)
        };
    }

    private void ApplyGaitDeformations(GaitData gait, float movementBlend)
    {
        float walkAmount = Mathf.Clamp01(movementBlend);
        float animTime = _gaitTime * gait.StepCadence * Mathf.Lerp(0.3f, 1f, walkAmount);

        if (movementBlend > 0.01f)
        {
            Debug.DrawRay(_rootTransform.position, _rootTransform.forward * gait.GroundShakeRadius * 0.5f, Color.green);
        }
    }

    public void SetMovementInput(float input)
    {
        movementInput = Mathf.Clamp01(input);
    }

    public void SetLevel(int newLevel)
    {
        if (!EarthGolemScaling.IsValidLevel(newLevel))
        {
            Debug.LogWarning($"Invalid level {newLevel}");
            return;
        }
        _currentLevel = newLevel;
    }

    private class GaitData
    {
        public float WalkSpeed;
        public float GroundShakeRadius;
        public float StepCadence;
    }
}