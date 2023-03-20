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
    [SerializeField] private ParticleSystem _cuteDeath;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _trigger.OnTriggerEnterAsObservable()
            .Where(t => t.gameObject.layer == LayerMask.NameToLayer("Box"))
            .Subscribe(collider =>
            {
                var square = collider.GetComponent<Square>();
                Instantiate(_cuteDeath, square.transform.position, square.transform.rotation);
                square.Deactivate(false);
            })
            .AddTo(_disposable);
    }

    public void SetPosition(Vector3 endPostion)
    {
        transform.position = Vector3.MoveTowards(transform.position, endPostion,_speed * Time.deltaTime);
    }
    
    
}
