using UnityEngine;

public class SquaresPool : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private Square _square;
    
    private ObjectPoolingBehaviour<Square> _pool;

    private void Start()
    {
        _pool = new ObjectPoolingBehaviour<Square>(_square,_poolCount,transform);
        RandomizeSquares();
    }

    private void RandomizeSquares()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var square = transform.GetChild(i).GetComponent<Square>();
            square.transform.position = VectorUtils.RandomPosition();
            square.StartAfterPool();
        }
    }
}