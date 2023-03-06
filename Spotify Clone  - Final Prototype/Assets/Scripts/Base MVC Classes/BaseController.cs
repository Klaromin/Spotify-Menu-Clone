using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController<M,V>
where M:BaseModel
where V:BaseView<M>

{
    internal V _view;
    internal M _model; //private'a cekip gir getter ile al
   
   
    public void Init(M model, V view) // 23.08 Constructor içine alsın init yerine
    {
        _model = model;
        _view = view;
        _view.Model = model;
        _view.Init();
         OnInit();
    }

    protected virtual void OnInit()
    {
        
    }
}
