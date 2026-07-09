using System.Collections.Generic;
using UnityEngine;

public class DustManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _dust;
    [SerializeField] private float _timer = 0;
    public int _count = 0;

    public Stack<GameObject> pool = new Stack<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Dust = _dust[i];
            pool.Push(Dust);
        }
    }

    private void Update()
    {
        if(_count <= 4)
        _timer += Time.deltaTime;

        if (_timer >= 20)
        {
            _timer = 0;
            GameObject Dust = pool.Pop();
            Dust.SetActive(true);
            _count++;
        }
    }
}
