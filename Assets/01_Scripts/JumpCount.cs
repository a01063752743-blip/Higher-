using TMPro;
using UnityEngine;

public class JumpCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _showCn;
    [SerializeField] private PlayerMovement player;

    private void Awake()
    {
        _showCn = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
       _showCn.SetText($"점프 횟수 : {player._jumpCount}");
    }
}
