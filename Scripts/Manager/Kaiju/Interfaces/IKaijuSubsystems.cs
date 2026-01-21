using System;
using UnityEngine;

namespace Kaiju.Managers
{
    public interface IKaijuSubsystem
    {
        bool IsInitialized { get; }
        string SubsystemName { get; }
        void Initialize();
        void Shutdown();
    }
}