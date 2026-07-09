using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LobbySetting : MonoBehaviour
{

    [SerializeField] private bool _OnUI = false;
    [SerializeField] private GameObject _settingUI;

    [SerializeField] private Light2D _light;

    private void OnMouseDown()
    {
        Dark();
        LobbyEmblem.instance.AllOff();
        LobbyEmblem.instance._canvas.SetActive(false);
        _settingUI.SetActive(true);
        _OnUI = true;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _OnUI)
        {
            Esc();
        }
    }

    void Dark()
    {
        _light.intensity = 0.3f;
    }

    public void Esc()
    {
        _OnUI = false;
        _light.intensity = 1f;
        LobbyEmblem.instance._canvas.SetActive(true);
        LobbyEmblem.instance.AllOn();
        _settingUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
