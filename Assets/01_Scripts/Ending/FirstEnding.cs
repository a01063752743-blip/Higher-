using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstEnding : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private PlayerMovement playerMove;
    [SerializeField] private GameObject _anotherWorld;
    [SerializeField] private GameObject player;
    [SerializeField] private Timer _time;
    public bool _clear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_time._timeOver)
        {
            _time.inSpace = false;
            _clear = true;
            UI.SetActive(false);
            StartCoroutine(Ending1());
        }
    }

    private void Update()
    {
        if(_clear)
        {
            playerMove._rigid.gravityScale = 0;
            player.transform.position += new Vector3(0, 0.01f, 0);
        }
    }

    IEnumerator Ending1()
    {
        if (!DiffiManager.instance._secret)
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("EndingFirst");
        }
        else if(DiffiManager.instance._secret)
        {
            yield return new WaitForSeconds(10f);
            player.transform.position = new Vector3(120.5f, 0.6f, 0);
            _clear = false;
            playerMove._rigid.gravityScale = 1.5f;
            _anotherWorld.SetActive(true);
        }
    }
}
