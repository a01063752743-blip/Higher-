using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timer = 90;
    [SerializeField] private float _showTimer = 0;
    public bool inSpace = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Light2D _light;
    public bool _timeOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inSpace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inSpace = false;
        if (_timeOver == false)
        {
            _timer = 90;
            _light.intensity = 1;
        }
    }

    private void Update()
    {
        _showTimer = Mathf.Floor(_timer);

        if (inSpace)
        {
            _timer -= Time.deltaTime;
            _light.intensity = _timer / 90;
        }

        if (0 >= _timer && inSpace)
        {
            inSpace = false;
            _timeOver = true;
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        _timeOver = false;
        _timer = 90;
        _light.intensity = 1;
        player.transform.position = new Vector3(0, 15, 0);
    }
}
