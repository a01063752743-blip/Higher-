using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dust : MonoBehaviour
{
    [SerializeField] private int _count = 0;
    [SerializeField] private DustManager _manager;
    [SerializeField] private Light2D _light;

    private void OnEnable()
    {
        _light.intensity -= 0.2f;
        _count = 0;
    }

    public void ClickEvent()
    {
        _count++;

        if (_count >= 10)
        {
            _manager._count--;
            _light.intensity += 0.2f;
            _manager.pool.Push(gameObject);
            gameObject.SetActive(false);
        }
    }
}
