using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPlaylist", menuName = "Spotify Data/Track Data")]
public class TrackData : ScriptableObject
{
    public string trackID;
    public string title;
    public string artist;
    public bool isExplicit;
    public string albumName;
    public DateTime dateAdded;
    [Header("Duration")]
    public int trackMinutes;
    public int trackSeconds;
    public int trackHours;
    public TimeSpan duration;
    public Sprite albumSprite;
    public bool isSelected;
}
