using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class CircleView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Collider _trigger;
    [SerializeField] private ParticleSystem _cuteDeath;
    private InterfaceEncounters _uiInterfaceEncounters;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private float totalDistance;
    private Vector3 lastPosition;
    
    [Inject]
    public void Construct(InterfaceEncounters interfaceEncounters)
    {
        _uiInterfaceEncounters = interfaceEncounters;
    }

    private void Start()
    {
        Construct(_uiInterfaceEncounters);
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
        totalDistance  += Vector3.Distance(transform.position, lastPosition);
        int distanceValue = (int)Math.Ceiling(totalDistance / Constants.CeilingDivideValue);
        _uiInterfaceEncounters.AddValue(distanceValue,ref _uiInterfaceEncounters.TotalDistacne,
            _uiInterfaceEncounters.Distance,Constants.HighDistanceDefinition);
        lastPosition = transform.position;
    }
    
    
}
