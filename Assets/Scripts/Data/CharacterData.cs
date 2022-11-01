using UnityEngine;


/// <summary>
/// Class describes common character properties.
/// </summary>
[CreateAssetMenu(fileName = "CharacterData", menuName = "Footkin/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public float Speed;
    public float GravityMultiplayer;
    public float jumpForce;
    public int Health;
}
