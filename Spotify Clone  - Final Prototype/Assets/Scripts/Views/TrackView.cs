using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackView : BaseView<TrackModel>
{
    public event EventHandler<TrackSelectedEventArgs> OnTrackSelectedEvent;

    [SerializeField] private Image _trackAlbumImage;
    
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _artist;
    [SerializeField] private TextMeshProUGUI _duration;
    [SerializeField] private TextMeshProUGUI _album;

    [SerializeField] private TextMeshProUGUI _number;

    [SerializeField] public Button _trackButton;
    
    
    //app logic managerlar aracılığı ile.
    //ui logic view
    
    void Awake()
    {
        _trackButton = GetComponentInChildren<Button>();
        //controllerda view.init yapmalıyım.
    }

    public override void Init()
    {
        InitTexts();
        InitSprite();
        AddEvents();
    }

    private void OnDisable()
    {
        RemoveEvents();
    }
    

    public void SetCurrentNumber(int counter)
    {
        _number.text = counter.ToString();
        
    }

    private void InitSprite()
    {
        _trackAlbumImage.sprite =  Model.track.albumSprite;
    }

    private void InitTexts()
    {
        _title.text =  Model.track.title;
        _artist.text =  Model.track.artist;
        _duration.text = new TimeSpan( Model.track.trackHours, Model.track.trackMinutes, Model.track.trackSeconds).ToString();
        
        _album.text = Model.track.albumName;
        // _dateReleased.text = _track.dateAdded.ToString();
    }

    private void OnButtonClick()
    {
        OnTrackSelectedEvent?.Invoke(this, new TrackSelectedEventArgs()
        {
            Id = Model.track.trackID
        });


        //Selected var mı? var ise selected stateini değiştirecek
        //kendisini selected edecek.
    }

    public void ChangeColor() //Rengi yeşil yapmaya yarayan view methodu.
    {
        _trackButton.image.color = new Color(0,1,0,0.098039222f);
    }

    public void Refresh()//Rengi beyaz yapmaya yarayan view methodu.
    {
        _trackButton.image.color = new Color(1, 1, 1, 0.098f);
    }
    private void AddEvents()
    {
        _trackButton.onClick.AddListener(OnButtonClick);
    }

    private void RemoveEvents()
    {
        _trackButton.onClick.RemoveAllListeners();
    }

}
