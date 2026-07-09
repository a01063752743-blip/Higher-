using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (player._moveDir.x != 0 && !ani.GetBool("isJump"))
        {
            ani.SetBool("isRun", true);
        }
        else
        {
            ani.SetBool("isRun", false);
        }

        if (player._moveDir.x > 0.1)
        {
            sp.flipX = false;
        }
        
        if (player._moveDir.x < -0.1)
        {
            sp.flipX = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                ani.SetBool("isJump", false);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        ani.SetBool("isJump", true);
    }
}
