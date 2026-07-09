using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider _bgm;
    public Slider _effect;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioSource _jumpEffect;
    [SerializeField] private CinemachineCamera _cameraSize;
    [SerializeField] private CinemachineCamera _cameraSizeSecret;

    [SerializeField] GameObject main;
    [SerializeField] GameObject teduri;

    [SerializeField] private TextMeshProUGUI _OnOff;

    [SerializeField] private bool _fullCamera = false;

    public static Setting instance;

    private void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        _audio.volume = _bgm.value;
        _jumpEffect.volume = _effect.value;
    }

    public void CameraSize()
    {
        if (!_fullCamera)
        {
            _cameraSize.Lens.OrthographicSize = 13.5f;
            _cameraSizeSecret.Lens.OrthographicSize = 13.5f;
            _OnOff.SetText("On");
            main.transform.localScale = new Vector3(5, 3.6f, 1);
            teduri.transform.localScale = new Vector3(5, 3.6f, 1);
            _fullCamera = true;
        }
        else if(_fullCamera)
        {
            _cameraSize.Lens.OrthographicSize = 7f;
            _cameraSizeSecret.Lens.OrthographicSize = 7f;
            _OnOff.SetText("Off");
            main.transform.localScale = new Vector3(2.7f, 1.8f, 1);
            teduri.transform.localScale = new Vector3(2.7f, 1.8f, 1);
            _fullCamera = false;
        }
    }

}
