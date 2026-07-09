using UnityEngine;

public class WIndEffect : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool left = true;

    private void FixedUpdate()
    {
        if (left)
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
        else if (!left)
        {
            transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
    }
}
