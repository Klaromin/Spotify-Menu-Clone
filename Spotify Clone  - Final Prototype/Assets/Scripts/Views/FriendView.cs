using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendView : BaseView<FriendModel>
{

    // private FriendModel _model;
    // public FriendModel Model { get; set; }
    [SerializeField] private Image _userImage;
    [SerializeField] private TextMeshProUGUI _userName;
    [SerializeField] private TextMeshProUGUI _currentTrackName;
    [SerializeField] private TextMeshProUGUI _currentTrackAlbum;
    [SerializeField] private TextMeshProUGUI _currentTrackArtist;
    void Start()
    {
        
    }

    public override void Init()
    {
        InitTexts();
        InitSprite();
    }
    public void InitTexts()
    {
        
        _userName.text = Model.friend.userName;
        _currentTrackName.text = Model._currentTrack.title;
        _currentTrackAlbum.text = Model._currentTrack.albumName;
        _currentTrackArtist.text = Model._currentTrack.artist;
        

    }

    public void InitSprite()
    {
        _userImage.sprite =Model.friend.userImage;
    }


    

}
