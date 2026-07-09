using UnityEngine;

public class Hard : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;

    private void OnMouseDown()
    {
        DiffiManager.instance.Reset();
        DiffiManager.instance._hard = true;
        _gameStart.begin();
    }
}
