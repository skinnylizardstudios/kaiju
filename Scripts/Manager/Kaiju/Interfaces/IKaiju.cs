using UnityEngine;
using System.Collections.Generic;

namespace Kaiju.Managers
{
    public interface IKaiju
    {
        string KaijuName { get; }
        int CurrentLevel { get; }
        void SetLevel(int level);
        void Attack();
        void Move(Vector3 direction);
    }
}