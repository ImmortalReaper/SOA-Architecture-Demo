using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configurations/Player/" + nameof(PlayerConfig))]
public class PlayerConfig : ScriptableObject
{
    public float PlayerSpeed = 2f;
    public float PlayerTargetPointStopDistance = 0.05f;
}
