using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseCheck : MonoBehaviour
{
    [SerializeField] private FriendData[] friendDatas;
    void Start()
    {
        friendDatas = Resources.LoadAll<FriendData>("Scriptable Objects/Users");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
