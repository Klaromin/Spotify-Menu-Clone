using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendActivityPanel : MonoBehaviour
{
    // public event EventHandler<TrackSelectedEventArgs> OnTrackSelectedEvent;
        
    private List<FriendController> friendControllers;

    [SerializeField] private Transform _spawnParent;

    [SerializeField] private GameObject _friendPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InitializeInnerMVCs();
    }

    private void InitializeInnerMVCs() //bu yapıyı trackleri instantiate ederken de kullan.
    {
        var friendDatas =
            Resources.LoadAll<FriendData>("Scriptable Objects/Users"); //friendData çek resource üzerinden.
        
        // OnTrackSelectedEvent?.Invoke(this,new TrackSelectedEventArgs(){}); //firlatma
        // OnTrackSelectedEvent += OnTrackSelected;
        
        foreach (var friendData in friendDatas) //foreach ile listeyi gez. 
        {

            GameObject go = Instantiate(_friendPrefab, _spawnParent);
            
            FriendModel friendModel = new FriendModel();
            friendModel.friend = friendData;
            friendModel._currentTrack = friendData.currentTrack; //modele setdata koy.
            
            var friendView = go.GetComponent<FriendView>(); 
            
            FriendController friendController = new FriendController();
            friendController.Init(friendModel, friendView);
            
            
           






            // friendControllers.Add(friendController);
        } 
        //içinde 1 model 1 view yarat, 1 controller yarat. Instaniate kullan. Controllerı init et
        //controller initinde bu yarattığım model ve viewi ver.
        //controllerların listesini tut.

    }

    // private void OnTrackSelected(object sender, TrackSelectedEventArgs e) //event sil
    // {
    //     OnTrackSelectedEvent?.Invoke(sender, e);
    // }
}




//görev 1: playlist ile tracki bağla.

// model controller view 3 class yarat.
//view içeriye model alsın.
//controller hem model hem view alsın.
//frien


//2.AŞMAA
//track item'a tek click rengi değiştirsin.
//Event ile haberleşme. Eventhandler
