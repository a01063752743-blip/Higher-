using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource _jumpSound;

    [SerializeField] private AudioClip _secretStage;
    public CinemachineCamera _cameraSize;
    [SerializeField] private CinemachineCamera _cameraSizeSecret;

    [SerializeField] private GameObject _esc;

    [SerializeField] private bool _OnUI = false;

    [SerializeField] private Timer _space;
    [SerializeField] private FirstEnding _theClear;

    public static SoundManager instance;

    private void Start()
    {
        instance = this;

        audio.Play();
        PlayerMovement.instance._jumpSound.volume = Setting.instance._effect.value;
    }

    private void Update()
    {
        if (_space.inSpace || _theClear._clear)
        {
            audio.volume -= 0.15f * Time.deltaTime;
        }
        else
        {
            audio.volume = Setting.instance._bgm.value;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame && !_OnUI)
        {
            _OnUI = true;
            _esc.SetActive(true);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame && _OnUI)
        {
            _OnUI = false;
            _esc.SetActive(false);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
