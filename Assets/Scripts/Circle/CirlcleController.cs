using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlcleController
{
   private CircleModel _model;
   private CircleView _view;
   
   public CirlcleController(CircleModel model, CircleView view)
   {
      _model = model;
      _view = view;
      _model.OnPositionChanged += _view.SetPosition;
   }

   public void ChangePosition(Vector3 changePosition)
   {
      _model.ChangeModelPosition(changePosition);
   }
}