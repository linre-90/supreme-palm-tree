using UnityEngine;


/// <summary>
/// Class describes common character properties.
/// </summary>
[CreateAssetMenu(fileName = "CharacterData", menuName = "Footkin/AnimationDAta", order = 1)]
public class AnimationData : ScriptableObject
{
    public string walk;
    public string jump;
    public string collect;
    public string ranged;
    public string melee;
}
