using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rigid;
    public AudioSource _jumpSound;

    public Vector2 _moveDir; // 백터 움직임
    [SerializeField]private Transform _retp;

    public float _speed; // 이동 속도
    [SerializeField] private float _jumpPower;// 점프 힘
    public int _jumpCount = 0; // 점프 횟수

    public bool _jumpEn = false; // 점프 가능 여부

    public TImerUI _ui;
    public int _countRank;
    [SerializeField] private GameObject _rKeyOff;
    [SerializeField] private bool _rKeyMessage = true;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
        _rigid = GetComponent<Rigidbody2D>();
        _retp.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && _jumpEn)
        {
            _rigid.AddForceY(_jumpPower, ForceMode2D.Impulse);
            _jumpEn = false;
            _jumpSound.Play();
            JumpCount();
        }

        if (DiffiManager.instance._easy || DiffiManager.instance._normal)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                gameObject.transform.position = _retp.transform.position;
            }
        }
        else if(Keyboard.current.rKey.wasPressedThisFrame &&_rKeyMessage && (!DiffiManager.instance._easy || !DiffiManager.instance._normal))
        {
            _rKeyOff.SetActive(true);
            StartCoroutine(RKeyOff());
            _rKeyMessage = false;
        }

        _jumpSound.volume = Setting.instance._effect.value;
        _countRank = _ui.TimeMinute;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(contact.normal.y > 0.5f)
            {
                _jumpEn = true;
            }
        }

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                if (Keyboard.current.fKey.isPressed)
                {
                    _retp.transform.position = gameObject.transform.position;
                    _moveDir.x = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            _rigid.AddForce(Vector2.down * 40, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _rigid.linearVelocity = new Vector2(_moveDir.x * _speed, _rigid.linearVelocityY);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _jumpEn = false;
    }

    void OnPlatformMove(InputValue value)
    {
        _moveDir.x = value.Get<Vector2>().x;
    }

    public void JumpCount()
    {
        _jumpCount++;
    }

    IEnumerator RKeyOff()
    {
        yield return new WaitForSeconds(3f);
        _rKeyOff.SetActive(false);
        _rKeyMessage = true;
    }
}
