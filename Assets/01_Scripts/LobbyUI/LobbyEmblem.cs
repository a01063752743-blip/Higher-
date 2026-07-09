using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class LobbyEmblem : MonoBehaviour
{
    public GameObject _canvas;

    public static LobbyEmblem instance;

    public Light2D _light;
    public CapsuleCollider2D _start;
    public CapsuleCollider2D _setting;
    public CapsuleCollider2D _emblem;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject _emblemUI;
    [SerializeField] private bool _OnUI = false;

    private void OnMouseDown()
    {
        DarkLight();
        _emblemUI.SetActive(true);
        _OnUI = true;
        _canvas.SetActive(false);
        AllOff();
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame && _OnUI)
        {
            _OnUI = false;
            _canvas.SetActive(true);
            _emblemUI.SetActive(false);
            _light.intensity = 1f;
            AllOn();
        }
    }

    private void DarkLight()
    {
        _light.intensity = 0.3f;
    }

    public void AllOff()
    {
        _start.enabled = false;
        _setting.enabled = false;
        _emblem.enabled = false;
    }

    public void AllOn()
    {
        _start.enabled = true;
        _setting.enabled = true;
        _emblem.enabled = true;
    }
}
