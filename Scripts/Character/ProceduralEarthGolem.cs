using UnityEngine;
using System.Collections.Generic;
using Kaiju.Managers;

public class ProceduralEarthGolem : MonoBehaviour, IKaijuSubsystem
{
    [Header("Golem Settings")]
    [SerializeField] private int golemLevel = 3;
    [SerializeField] private bool autoGenerateOnAwake = true;
    
    [Header("Visual Settings")]
    [SerializeField] private Material baseRockMaterial;
    [SerializeField] private Color baseRockColor = new Color(0.4f, 0.4f, 0.38f);

    private int _currentLevel;
    private float _currentScale;
    private Transform _rootTransform;
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;
    
    public bool IsInitialized { get; private set; }
    public string SubsystemName => "ProceduralEarthGolem";

    private void OnEnable()
    {
        if (autoGenerateOnAwake && !IsInitialized)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        if (IsInitialized) return;
        
        _rootTransform = transform;
        _currentLevel = golemLevel;
        _currentScale = EarthGolemScaling.GetScaleFactor(_currentLevel);
        
        SetupMeshComponents();
        GenerateGolemGeometry();
        ApplyGolemMaterials();
        
        IsInitialized = true;
    }

    public void Shutdown()
    {
        IsInitialized = false;
    }

    public void SetLevel(int newLevel)
    {
        if (!EarthGolemScaling.IsValidLevel(newLevel))
            return;
        
        _currentLevel = newLevel;
        _currentScale = EarthGolemScaling.GetScaleFactor(_currentLevel);
        _rootTransform.localScale = Vector3.one * _currentScale;
    }

    private void SetupMeshComponents()
    {
        _meshFilter = _rootTransform.GetComponent<MeshFilter>();
        if (_meshFilter == null)
            _meshFilter = _rootTransform.gameObject.AddComponent<MeshFilter>();
        
        _meshRenderer = _rootTransform.GetComponent<MeshRenderer>();
        if (_meshRenderer == null)
            _meshRenderer = _rootTransform.gameObject.AddComponent<MeshRenderer>();
    }

    private void GenerateGolemGeometry()
    {
        Mesh mesh = GenerateRockyHumanoidMesh(_currentScale);
        _meshFilter.mesh = mesh;
    }

    private Mesh GenerateRockyHumanoidMesh(float scale)
    {
        Mesh mesh = new Mesh();
        mesh.name = "EarthGolemBody";
        
        List<Vector3> vertices = new List<Vector3>(256);
        List<int> triangles = new List<int>(512);
        List<Vector2> uvs = new List<Vector2>(256);
        
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
        
        return mesh;
    }

    private void ApplyGolemMaterials()
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = baseRockColor;
        _meshRenderer.material = mat;
    }
}