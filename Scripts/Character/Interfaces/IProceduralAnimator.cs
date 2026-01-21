using UnityEngine;

public interface IProceduralAnimator
{
    bool IsInitialized { get; }
    string SubsystemName { get; }
    void Initialize();
    void Shutdown();
    void SetMovementInput(float input);
    void SetLevel(int level);
}