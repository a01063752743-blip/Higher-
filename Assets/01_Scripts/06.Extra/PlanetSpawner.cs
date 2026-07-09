using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _planetspawner;
    [SerializeField] private GameObject _planet;

    [SerializeField] private float _time = 0;
    [SerializeField] private int _random = 0;

    public Stack<GameObject> pool = new Stack<GameObject>();

    private void OnEnable()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject Planet = Instantiate(_planet);
            Planet.SetActive(false);
            pool.Push(Planet);
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= 5)
        {
            if (pool.Count > 0)
            {
                _time = 0;
                GameObject Planet = pool.Pop();
                _random = Random.Range(0, 8);
                Planet.transform.position = _planetspawner[_random].transform.position;
                Planet.SetActive(true);
            }
            else
            {
                _time = 0;
                _random = Random.Range(0, 8);
                Instantiate(_planet,_planetspawner[_random].transform.position,Quaternion.Euler(0,0,-90));
            }
        }
    }
}
