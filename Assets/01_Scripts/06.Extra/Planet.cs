using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Extra _extra;
    [SerializeField] private PlanetSpawner _spawner;

    private void OnEnable()
    {
        _extra = GameObject.FindWithTag("Extra").GetComponent<Extra>();
        _spawner = GameObject.FindWithTag("Spawner").GetComponent<PlanetSpawner>();

        _speed = Random.Range(3f, 5);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -_speed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _extra.Fail();
        }

        if (collision.gameObject.CompareTag("Back"))
        {
            gameObject.SetActive(false);
            _spawner.pool.Push(gameObject);
        }
    }
}
