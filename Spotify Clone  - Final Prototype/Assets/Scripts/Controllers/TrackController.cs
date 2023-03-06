using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : BaseController<TrackModel,TrackView>
{
    public event EventHandler<TrackSelectedEventArgs> OnTrackSelectedEvent;
    protected override void OnInit()
    {
       AddEvents();
    }
    

    internal void SetSelected(bool isSelected)
    {
        if (isSelected)
        {
            _view.ChangeColor();
            
        }
        else
        {
            Refresh();
        }
    }

    public void Refresh()
    {
        _view.Refresh();
        // _model.track.isSelected = false;
    }
    private void OnTrackSelected(object sender, TrackSelectedEventArgs e) //bize veiwdan gelmiş eventi iletiyoruz.
    {
        OnTrackSelectedEvent?.Invoke(sender, e);
        
       
    }
    private void AddEvents()
    {
        //publisher                     subscriber
        _view.OnTrackSelectedEvent += OnTrackSelected;
    }

    private void RemoveEvents() 
    {
        _view.OnTrackSelectedEvent -= OnTrackSelected;
    }
    
}
