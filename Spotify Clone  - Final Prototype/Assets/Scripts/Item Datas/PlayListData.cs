using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlaylist", menuName = "Spotify Data/Playlist Data")]
public class PlayListData : ScriptableObject
{ 
 //public çekmeli miyim?
 public new string name;
 public Sprite _image;
 public bool _isPrivate;
 public string _title;
 public string _description;
 public string _user; //userlardan alınır ileride.
 public int _likes;
 public int _numberOfSongs;
 public string _duration;

 public List<string> trackIDList;
 //track için id listesi oluştur. çağırırken id'ye sahip olan trackleri çağırmaya yaracak.
 private void Awake()
 {
  
 }
}
