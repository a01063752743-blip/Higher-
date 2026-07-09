using UnityEngine;

public class AllManager : MonoBehaviour
{
    [SerializeField] private GameObject _event1;
    [SerializeField] private GameObject _event2;
    [SerializeField] private GameObject _event3;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _noobMode;

    private void OnEnable()
    {
        if (DiffiManager.instance._easy == true)
        {
            _event1.SetActive(false);
            _event2.SetActive(false);
            _event3.SetActive(false);
            _backGround.SetActive(false);
            _noobMode.SetActive(true);
        }
        else if (DiffiManager.instance._easy == false)
        {
            _event1.SetActive(true);
            _event2.SetActive(true);
            _event3.SetActive(true);
            _backGround.SetActive(true);
            _noobMode.SetActive(false);
        }
    }
}
