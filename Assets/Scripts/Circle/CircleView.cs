using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CircleView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Collider _trigger;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _trigger.OnTriggerEnterAsObservable()
            .Subscribe(collider =>
            {
                collider.gameObject.SetActive(false);
            }).AddTo(_disposable);
    }

    public void SetPosition(Vector3 endPostion)
    {
        transform.position = Vector3.MoveTowards(transform.position, endPostion,_speed * Time.deltaTime);
    }
    
    
}
