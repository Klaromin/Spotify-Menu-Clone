using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUser", menuName = "Spotify Data/User Data")]
public class FriendData : ScriptableObject
{
    public int userID;
    public string userName;
    public Sprite userImage;
    public TrackData currentTrack;
}
