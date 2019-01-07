using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 노래 정보 집합
/// </summary>

[CreateAssetMenu(fileName = "New SongInfo", menuName = "Song Info")]
public class SongScript : ScriptableObject
{
    public int BPM;
    public new string name;
    public Sprite backgroundUp, backgroundDown, playerSprite;
    public Color barOnColor = Color.black;
    public Color barOffColor = Color.black;
    public Color barTextColor = Color.black;
    public Color backTextColor = Color.black;
    public Color playerCoreColor = Color.black;
    public AudioClip clip;
}
