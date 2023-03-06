using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistPanel : MonoBehaviour
{
    
    
    [SerializeField] private TrackView _trackPrefab; //view clasını tut
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private PlaylistView _playlistView;
    private Button someButton;
    private List<TrackController> _currentTrackControllerList = new List<TrackController>();
    private void Start()
    {
        
        InitializeInnerMVCs();
        AddEvents();
        
    }
    private void InitializeInnerMVCs() //bu yapıyı trackleri instantiate ederken de kullan.
    {
        var trackDatas = Resources.LoadAll<TrackData>("Scriptable Objects/Tracks"); 
        var currentPlaylistData = Resources.Load<PlayListData>("Scriptable Objects/Playlists/Country Music");
        
        PlaylistController playlistController = new PlaylistController();
        PlaylistModel playlistModel = new PlaylistModel();
        
        
        playlistModel.playlistData = currentPlaylistData;
        playlistController.Init (playlistModel,_playlistView);
        // _playlistView.Init();  
        int counter = 0;
        foreach (var trackData in trackDatas) //foreach ile listeyi gez. 
        {

            if (currentPlaylistData.trackIDList.Contains(trackData.trackID))
            {
                counter++;
                var go = Instantiate(_trackPrefab, _spawnParent);
                // OnTrackSelectedEvent?.Invoke(this,new TrackSelectedEventArgs(){Id = trackData.trackID}); //firlatma
                // OnTrackSelectedEvent += OnTrackSelected;
                TrackModel trackModel = new TrackModel();
                trackModel.track = trackData;
                TrackController trackController = new TrackController();
                trackController.Init(trackModel, go);
                go.SetCurrentNumber(counter);
                // go.Init(); CONTROLLERLARIN BASEINE TASINDI
                _currentTrackControllerList.Add(trackController);
            }

            
            
            

        } 

        
    }

    
    private void OnTrackSelected(object sender, TrackSelectedEventArgs e)
    {
        var currentTrackController = _currentTrackControllerList.Find(c=> c._model.track.trackID == e.Id);
        
        foreach (var controller in _currentTrackControllerList)
        {
            var selected = currentTrackController == controller;
            controller.SetSelected(selected);
            
            // if (currentTrackController != controller)
            // {
            //     controller._model.track.isSelected = false;
            //     //controller.setselected false
            // }
            // else
            // {
            //     controller._model.track.isSelected = true;
            //     //controller.setselected true.
            // }
            // controller.SetSelected(controller._model.track.isSelected);
        }
        
        


    }


    private void AddEvents()
    {
        foreach (var controller in _currentTrackControllerList)
        {
            controller.OnTrackSelectedEvent += OnTrackSelected;
            
        }
    }

    private void RemoveEvents()
    {
        foreach (var controller in _currentTrackControllerList)
        {
            controller.OnTrackSelectedEvent -= OnTrackSelected;
        }
    }
    



}
public class TrackSelectedEventArgs : EventArgs
{
    public string Id { get; set; }
}

/*Event taskı:

Olması gereken: Bir parçaya tıkladığımızda o parçanın butonunun renk değiştirmesi, başka bir parçaya tıklamadıkça o renk kalması,
eğer başka bir parçaya tıklanırsa renginin eski haline dönmesi, yeni tıklanan parçanın renginin değişmesi.

Hiyerarşik yapıyı kullanmam lazım.

foreach içinde her parçaya bu eventi controller üzerinden(?) eklememiz gerekli.

*/