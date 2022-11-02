using UnityEngine;

/// <summary>
/// Class describes common character properties.
/// </summary>
[CreateAssetMenu(fileName = "DamageData", menuName = "Footkin/ItemData", order = 1)]
public class DamageData : ScriptableObject
{

    public int HitPoints;

    [Tooltip("Milliseconds!")]
    public float cooldown;
    public string targetTag;

    [Tooltip("RANGED or MELEE")]
    public string type;
}
