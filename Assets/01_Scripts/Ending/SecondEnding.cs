using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondEnding : MonoBehaviour
{
    [SerializeField] private bool _clear = false;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(end());
    }

    private void Update()
    {
        if(_clear)
        {
            PlayerMovement.instance._rigid.gravityScale = 0f;
            _player.transform.position += new Vector3(0, 0.2f, 0) * Time.deltaTime;
        }
    }

    IEnumerator end()
    {
        _clear = true;
        _canvas.SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(3);
    }
}
