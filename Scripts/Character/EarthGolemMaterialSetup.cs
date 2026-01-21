using UnityEngine;

public class EarthGolemMaterialSetup : MonoBehaviour
{
    [Header("Material Properties")]
    [SerializeField] private Color rockColor = new Color(0.4f, 0.4f, 0.38f);
    [SerializeField] private float roughness = 0.7f;
    [SerializeField] private float metallic = 0f;
    
    private MeshRenderer _meshRenderer;

    private void OnEnable()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_meshRenderer == null)
            return;

        UpdateMaterialProperties();
    }

    private void UpdateMaterialProperties()
    {
        if (_meshRenderer == null)
            return;

        Material mat = _meshRenderer.material;
        mat.color = rockColor;
        mat.SetFloat("_Roughness", roughness);
        mat.SetFloat("_Metallic", metallic);
    }
}