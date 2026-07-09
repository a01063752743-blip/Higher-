using UnityEngine;

public class WindTP : MonoBehaviour
{
    [SerializeField] private bool left = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (left)
        {
            if (collision.gameObject.CompareTag("Wind"))
            {
                collision.gameObject.transform.position += new Vector3(65, 0,0);
            }
        }
        else if(!left)
        {
            if (collision.gameObject.CompareTag("Wind"))
            {
                collision.gameObject.transform.position += new Vector3(-65, 0, 0);
            }
        }
    }
}
