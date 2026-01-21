using UnityEngine;

public class PlayerKaijuController : MonoBehaviour
{
    [Header("Player Kaiju Settings")]
    [SerializeField] private int initialLevel = 3;
    [SerializeField] private GameObject kaijuPrefab;
    
    private GameObject _playerKaiju;
    private ProceduralEarthGolem _golemComponent;
    private EarthGolemProceduralGait _gaitComponent;

    private void Awake()
    {
        SpawnPlayerKaiju();
    }

    private void SpawnPlayerKaiju()
    {
        if (kaijuPrefab != null)
        {
            _playerKaiju = Instantiate(kaijuPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            _playerKaiju = new GameObject("PlayerKaiju");
            _playerKaiju.transform.parent = transform;
        }

        _golemComponent = _playerKaiju.GetComponent<ProceduralEarthGolem>();
        if (_golemComponent == null)
            _golemComponent = _playerKaiju.AddComponent<ProceduralEarthGolem>();

        _gaitComponent = _playerKaiju.GetComponent<EarthGolemProceduralGait>();
        if (_gaitComponent == null)
            _gaitComponent = _playerKaiju.AddComponent<EarthGolemProceduralGait>();

        _golemComponent.Initialize();
        _gaitComponent.Initialize();
    }

    public void SetKaijuLevel(int level)
    {
        if (_golemComponent != null)
            _golemComponent.SetLevel(level);
        if (_gaitComponent != null)
            _gaitComponent.SetLevel(level);
    }
}