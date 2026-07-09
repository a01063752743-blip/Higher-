using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class LobbyStart : MonoBehaviour
{
    [SerializeField] private bool _OnUI = false;
    [SerializeField] private GameObject _startUI;

    [SerializeField] private Light2D _light;

    private void OnMouseDown()
    {
        Dark();
        LobbyEmblem.instance.AllOff();
        LobbyEmblem.instance._canvas.SetActive(false);
        _startUI.SetActive(true);
        _OnUI = true;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _OnUI)
        {
            _OnUI = false;
            _light.intensity = 1f;
            LobbyEmblem.instance._canvas.SetActive(true);
            LobbyEmblem.instance.AllOn();
            _startUI.SetActive(false);
        }
    }

    void Dark()
    {
        _light.intensity = 0.3f;
    }
}
