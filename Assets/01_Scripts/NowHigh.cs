using TMPro;
using UnityEngine;

public class NowHigh : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float height = 0;

    [SerializeField] private TextMeshProUGUI high;

    private void FixedUpdate()
    {
        height = Mathf.Floor(target.position.y);
        high.SetText($"현재 높이 : {height}"); 
    }
}
