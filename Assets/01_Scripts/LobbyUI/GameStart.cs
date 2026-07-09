using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private bool _esc = false;
    [SerializeField] private bool _st = false;
    [SerializeField] private bool _first = true;

    [SerializeField] private Light2D _light;

    [SerializeField] private GameObject _offCanvas;
    [SerializeField] private GameObject _black;
    [SerializeField] private GameObject _sky;
    [SerializeField] private GameObject _story;
    [SerializeField] private GameObject _audioSound;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _startCanvas;
    [SerializeField] private GameObject _escMessage;
    [SerializeField] private TextMeshProUGUI _text;


    private void Start()
    {
        _audioSound.SetActive(false);
        _black.SetActive(true);
        _escMessage.SetActive(true);
        _offCanvas.SetActive(false);
        LobbyEmblem.instance.AllOff();
    }

    private void Update()
    {
        if(_esc && Keyboard.current.escapeKey.wasPressedThisFrame && _st)
        {
            SceneManager.LoadScene(1);
        }

        if(_first && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _audioSound.SetActive(true);
            _black.SetActive(false);
            _escMessage.SetActive(false);
            _offCanvas.SetActive(true);
            _first = false;
            LobbyEmblem.instance.AllOn();
        }
    }

    public void begin()
    {
        _offCanvas.SetActive(false);
        _black.SetActive(true);

        _canvas.SetActive(false);
        _startCanvas.SetActive(false);

        StartCoroutine(GameBegin());
    }
    
    IEnumerator GameBegin()
    {
        _light.intensity = 1;
        _st = true;
        _esc = true;
        _audioSound.SetActive(false);
        _black.SetActive(true);
        yield return new WaitForSeconds(3f);
        _canvas.SetActive(true);
        _text.SetText("엄마 : 아들! 이제 자야지!");
        yield return new WaitForSeconds(4f);
        _text.SetText("주인공 : 아 자기 시룬데..");
        yield return new WaitForSeconds(4f);
        _text.SetText("엄마 : 일찍 자야지! 7살밖에 안됐는데!");
        yield return new WaitForSeconds(4f);
        _text.SetText("주인공 : 에잇.. 그치만..");
        yield return new WaitForSeconds(4f);
        _text.SetText("엄마 : 일찍 자면 치킨");
        yield return new WaitForSeconds(2f);
        _text.SetText("주인공 : 잘자요 엄마! zzzZZ");
        yield return new WaitForSeconds(4f);
        _text.SetText("엄마 : 어릴 때 부터 치킨을 주면 안됐는데..");
        yield return new WaitForSeconds(4f);
        _text.SetText("엄마 : 에휴.. 잘자라 우리 아들~");
        yield return new WaitForSeconds(4f);
        _text.SetText("주인공 : zzzzzzZZZZ");
        yield return new WaitForSeconds(4f);
        _text.SetText("주인공 : ...");
        yield return new WaitForSeconds(4f);
        _text.SetText("흠냐..");
        yield return new WaitForSeconds(4f);
        _text.SetText("흠... 어.. 음.. 음?");
        yield return new WaitForSeconds(4f);
        _black.SetActive(false);
        _sky.SetActive(true);
        _story.SetActive(true);
        _text.SetText("여기 어디야..?");
        yield return new WaitForSeconds(4f);
        _text.SetText("내가 왜 이런 곳에 있는거지..?");
        yield return new WaitForSeconds(4f);
        _text.SetText("난 분명 집에..");
        yield return new WaitForSeconds(4f);
        _text.SetText("어.... 어....");
        yield return new WaitForSeconds(4f);
        _text.SetText("이거 꿈인가..?");
        yield return new WaitForSeconds(4f);
        _text.SetText("흠....");
        yield return new WaitForSeconds(4f);
        _text.SetText("에이 뭐 꿈이겠지? 헤헤");
        yield return new WaitForSeconds(4f);
        _text.SetText("근데 꿈이라서 그런가?");
        yield return new WaitForSeconds(4f);
        _text.SetText("다리에 힘이 왜 더 좋아진 것 같지?");
        yield return new WaitForSeconds(4f);
        _text.SetText("어라? 저기 발판이 있네?");
        yield return new WaitForSeconds(4f);
        _text.SetText("한번 올라가볼까?");
        yield return new WaitForSeconds(4f);
        _text.SetText("무서울 것 같기는 한데..");
        yield return new WaitForSeconds(4f);
        _text.SetText("우주로 한번 가보고 싶었는데 가봐야지~");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
