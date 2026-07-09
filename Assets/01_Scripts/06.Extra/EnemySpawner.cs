using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    private void OnEnable()
    {
        StartCoroutine(WaitStart());
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(35f);
        Enemy.transform.position = transform.position;
        Enemy.SetActive(true);
    }
}
