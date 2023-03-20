using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlcleController
{
   public CircleModel model;
   private CircleView _view;
   public CirlcleController(CircleModel model, CircleView view)
   {
      this.model = model;
      _view = view;
      model.OnPositionChanged += _view.SetPosition;
   }
}

 
