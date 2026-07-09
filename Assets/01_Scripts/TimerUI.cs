using TMPro;
using UnityEngine;

public class TImerUI : MonoBehaviour
{
    public double Timer = 0;
    public int TimeMinute = 0;
    [SerializeField]private TextMeshProUGUI _timeText;
    public bool _timeOver = false;

    private void Awake()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (100001 >= TimeMinute && TimeMinute >= 100000)
        {
            _timeOver = true;
            _timeText.SetText($"시간\n------");
        }

        if (!_timeOver)
        {
            Timer += Time.deltaTime;
            _timeText.SetText($"시간\n{TimeMinute}:{Mathf.Clamp(((int)Timer), 0f, 999999f)}");
        }

        if (Timer >= 60)
        {
            TimeMinute++;
            Timer = 0;
        }
    }
}
