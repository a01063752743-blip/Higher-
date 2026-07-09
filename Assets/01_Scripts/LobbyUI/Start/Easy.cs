using UnityEngine;

public class Easy : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;

    private void OnMouseDown()
    {
        DiffiManager.instance.Reset();
        DiffiManager.instance._easy = true;
        _gameStart.begin();
    }
}
