using UnityEngine;

public class WindEvent : MonoBehaviour
{
    public float _windPower;
    [SerializeField] private bool _left = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (_left)
            {
                collision.gameObject.transform.position += Vector3.left * _windPower * Time.deltaTime;
            }
            else if (!_left)
            {
                collision.gameObject.transform.position += Vector3.right * _windPower * Time.deltaTime;
            }
        }
    }
}
