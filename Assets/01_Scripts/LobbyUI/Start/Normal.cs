using UnityEngine;

public class Normal : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;

    private void OnMouseDown()
    {
        DiffiManager.instance.Reset();
        DiffiManager.instance._normal = true;
        _gameStart.begin();
    }
}
