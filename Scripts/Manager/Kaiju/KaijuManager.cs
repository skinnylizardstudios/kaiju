using UnityEngine;

namespace Kaiju.Managers
{
    public class KaijuManager : MonoBehaviour
    {
        [Header("Debug Settings")]
        [SerializeField] private int debugKaijuLevel = 3;
        [SerializeField] private bool autoSpawnOnStart = true;

        private static KaijuManager _instance;
        private KaijuTypeRegistry _typeRegistry;

        public static KaijuManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _typeRegistry = new KaijuTypeRegistry();
        }

        public void SetDebugLevel(int level)
        {
            debugKaijuLevel = level;
        }

        public int GetDebugLevel()
        {
            return debugKaijuLevel;
        }
    }
}