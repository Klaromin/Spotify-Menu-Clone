using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlaylistView : BaseView<PlaylistModel>
{
    #region MVC Region
    [Header("Model - Controller - Data Settings")]
    // private PlaylistModel _model;
    //
    // public PlaylistModel Model { get; set; }
      
    #endregion

    #region Component Region
    [Header("Component Settings")]
    [SerializeField] private Image _playlistSprite;
    [SerializeField] private TextMeshProUGUI _playlistName;
    [SerializeField] private TextMeshProUGUI _playlistCreator;
    [SerializeField] private TextMeshProUGUI _playlistType;
    [SerializeField] private TextMeshProUGUI _playlisLikes;
    [SerializeField] private TextMeshProUGUI _numberOfSongs;
    [SerializeField] private TextMeshProUGUI _duration;
    [SerializeField] private PlayListData currentPlaylistData;
    [SerializeField] private Transform _context;
    [SerializeField] private TrackView _trackPrefab;
    #endregion
    
    
    void Start()
    {
         
        Init();
    }

    public override void Init()
    {
         InitText();
         InitSprite();
        
    }



    private void InitSprite()
    {
        _playlistSprite.sprite = Model.playlistData._image;
    }

    private void InitText()
    {
        _playlistName.text = Model.playlistData.name;
        _playlistCreator.text = Model.playlistData._user + " -";
        _playlistType.text = Model.playlistData._isPrivate ? "Private" : "Public";
        _playlisLikes.text = Model.playlistData._likes + " -";
        _numberOfSongs.text = Model.playlistData._numberOfSongs +" -";
    }


    //sprite için init text için genel initte çağır.
    
    //initplaylistitems.

    

}
