using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D _rigid;

    [SerializeField] private Extra _extra;

    private void OnEnable()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerTarget = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector2 md = (_playerTarget.position - transform.position).normalized;
        _rigid.linearVelocity = md * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _extra.Fail();
        }
    }
}
