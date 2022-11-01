using UnityEngine;

/// <summary>
/// Class describes common character properties.
/// </summary>
[CreateAssetMenu(fileName = "DamageData", menuName = "Footkin/ItemData", order = 1)]
public class DamageData : ScriptableObject
{
    public int HitPoints;
    public float cooldown;

}
