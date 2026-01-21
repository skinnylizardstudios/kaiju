using System.Collections.Generic;
using UnityEngine;

namespace Kaiju.Managers
{
    [System.Serializable]
    public class KaijuTypeRegistry
    {
        [SerializeField] private List<KaijuTypeData> registeredTypes = new List<KaijuTypeData>();

        public KaijuTypeData GetTypeData(string typeName)
        {
            foreach (var type in registeredTypes)
            {
                if (type.TypeName == typeName)
                    return type;
            }
            return null;
        }

        public void RegisterType(KaijuTypeData typeData)
        {
            registeredTypes.Add(typeData);
        }
    }
}