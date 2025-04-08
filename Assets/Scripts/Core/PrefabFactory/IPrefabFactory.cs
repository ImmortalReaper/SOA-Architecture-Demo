using UnityEngine;

public interface IPrefabFactory
{
    public GameObject Create(string prefabName);
    public GameObject Create(string prefabName, Vector3 position, Transform parent = null);
}
