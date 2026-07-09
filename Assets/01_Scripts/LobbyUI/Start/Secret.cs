using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;

    private void OnMouseDown()
    {
        DiffiManager.instance.Reset();
        DiffiManager.instance._secret = true;
        _gameStart.begin();
    }
}
