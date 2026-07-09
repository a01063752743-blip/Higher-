using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Extra : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject UI;

    [SerializeField] private GameObject _Maincamera;
    [SerializeField] private GameObject _secretCamera;

    [SerializeField] private Light2D _light;


    private void OnEnable()
    {
        _Maincamera.SetActive(false);
        _secretCamera.SetActive(true);

        _light.intensity = 0;
        StartCoroutine(WaitStart());
    }

    IEnumerator WaitStart()
    {
        _light.intensity = 0;
        yield return new WaitForSeconds(5f);

        while (_light.intensity < 1)
        {
            _light.intensity += 0.1f * Time.deltaTime;
        }

        UI.SetActive(true);
    }

    public void Fail()
    {
        _player.transform.position = new Vector3(120.5f,0.6f, 0);
    }
}
