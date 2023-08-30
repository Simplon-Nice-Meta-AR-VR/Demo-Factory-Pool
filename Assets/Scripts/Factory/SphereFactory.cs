using UnityEngine;

public class SphereFactory : Factory
{
    [SerializeField] private GameObject _spherePrefab;

    public override Transform Generate(Vector3 position)
    {
        GameObject go = Instantiate(_spherePrefab);
        go.transform.position = position;
        return go.transform;
    }
}
