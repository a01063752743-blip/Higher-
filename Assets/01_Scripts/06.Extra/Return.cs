using UnityEngine;

public class Return : MonoBehaviour
{
    [SerializeField] private PlanetSpawner _spawner;

    private void OnEnable()
    {
        _spawner = GameObject.FindWithTag("Spawner").GetComponent<PlanetSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Planet"))
        {
                Debug.Log("qwe");
                gameObject.SetActive(false);
                _spawner.pool.Push(gameObject);
        }
    }
}
