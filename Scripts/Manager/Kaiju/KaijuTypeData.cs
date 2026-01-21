using UnityEngine;

namespace Kaiju.Managers
{
    [System.Serializable]
    public class KaijuTypeData
    {
        [SerializeField] public string TypeName;
        [SerializeField] public string Description;
        [SerializeField] public int MinLevel = 1;
        [SerializeField] public int MaxLevel = 9999;
    }
}