using System.Collections;
using UnityEngine;

public class IceEvent : MonoBehaviour
{
    private float _iceBreak = 0;
    private BoxCollider2D collision;
    private SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        collision = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DiffiManager.instance._easy != true)
        {
            _iceBreak = Random.Range(1f, 3f);
            StartCoroutine(BreakTime());
        }
    }

    private IEnumerator BreakTime()
    {
            yield return new WaitForSeconds(_iceBreak);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(5f);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
