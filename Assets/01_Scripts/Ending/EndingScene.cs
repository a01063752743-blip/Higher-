using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSp;
    [SerializeField] private GameObject _Message;
    [SerializeField] private TextMeshProUGUI _playerText;
    [SerializeField] GameObject[] _camera;
    [SerializeField] private Light2D _light;
    [SerializeField] private AudioSource _audio;

    [SerializeField] bool _exit = false;
    [SerializeField] float _speed = 2f;
    [SerializeField] int _rank = 0;

    [SerializeField] private GameObject _ending;
    [SerializeField] private GameObject _endingTheme;
    [SerializeField] private TextMeshProUGUI _Theme;
    [SerializeField] private GameObject _endingRank;
    [SerializeField] private TextMeshProUGUI _Rank;
    [SerializeField] private GameObject _ESC;
    [SerializeField] private TextMeshProUGUI _reMesaage;
    [SerializeField] private GameObject _reMe;

    [SerializeField] private string _rankResult;
    [SerializeField] private string _resultMessage;
    [SerializeField] private string _themeResult;

    private void Start()
    {
        StartCoroutine(Message());
    }

    private void Update()
    {
        transform.position += new Vector3(0, -_speed, 0) * Time.deltaTime;

        if (_exit)
        {
            _light.intensity -= 0.1f * Time.deltaTime;
            if (_light.intensity <= 0)
            {
                _exit = false;
            }
        }

        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Message()
    {
        _playerText.SetText("어디까지 올라가는거지..?");
        yield return new WaitForSeconds(4f);
        _playerText.SetText("끝이 안보이네..");
        yield return new WaitForSeconds(4f);
        _playerText.SetText("음?");
        _playerSp.flipX = true;
        _speed = 0.5f;
        yield return new WaitForSeconds(4f);
        _playerText.SetText("우와..");
        yield return new WaitForSeconds(4f);
        _Message.SetActive(false);
        _camera[0].SetActive(false);
        _camera[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        _audio.Play();
        yield return new WaitForSeconds(4f);
        _Message.SetActive(true);
        _playerText.SetText("이게.. 지구인가..?");
        yield return new WaitForSeconds(4f);
        _playerText.SetText("너무 아름답다...");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("무척 이쁘고..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("그리고.. 정말 멋져..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("내가 이렇게 멋진 곳에 살고있었단 말이야..?");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("꼭.. 꿈을 꾸는것 같다..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("비록.. 이게 진짜 꿈이긴해도..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("나는 지금.. 정말 멋진 별을 보고 있고..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("또.. 꿈이 새로 생겼고...");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("또..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("...");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("나의 노력으로 이룬 것이니.. 뿌듯하고..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("나중에 이렇게 멋진 별을.. 다시 볼 수 있으면 좋겠다..");
        yield return new WaitForSeconds(8f);
        _playerText.SetText("아니.. 분명 올거야..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("그렇게 믿어..");
        yield return new WaitForSeconds(5f);
        _playerText.SetText("분명...");
        yield return new WaitForSeconds(5f);
        _Message.SetActive(false);
        _exit = true;
        yield return new WaitForSeconds(13f);
        StartCoroutine(Ending());
    }

    IEnumerator Ending()
    {
        Result();
        _ending.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _Theme.SetText($"< [{_themeResult}] 모드 클리어> ");
        _endingTheme.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _Rank.SetText($"등급\n[  {_rankResult}  ]");
        _reMesaage.SetText($"---------\n{_resultMessage}");
        _endingRank.SetActive(true);
        _reMe.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _ESC.SetActive(true);
    }

    void Result()
    {
        if(DiffiManager.instance._easy)
        {
            _themeResult = "쉬움";
        }
        else if (DiffiManager.instance._normal)
        {
            _themeResult = "노말";
        }
        else if (DiffiManager.instance._hard)
        {
            _themeResult = "어려움";
        }
        else if (DiffiManager.instance._secret)
        {
            _themeResult = "시크릿";
        }

        if (PlayerMovement.instance._jumpCount <= 300)
        {
            _rank += 5;
        }
        else if(PlayerMovement.instance._jumpCount <= 400)
        {
            _rank += 4;
        }
        else if (PlayerMovement.instance._jumpCount <= 600)
        {
            _rank += 3;
        }
        else if (PlayerMovement.instance._jumpCount <= 700)
        {
            _rank += 2;
        }
        else if (PlayerMovement.instance._jumpCount <= 900)
        {
            _rank += 1;
        }
        else if (PlayerMovement.instance._jumpCount <= 1000)
        {
            _rank += 0;
        }

        if (PlayerMovement.instance._countRank <= 9)
        {
            _rank += 5;
        }
        else if (PlayerMovement.instance._countRank <= 14)
        {
            _rank += 4;
        }
        else if (PlayerMovement.instance._countRank <= 29)
        {
            _rank += 3;
        }
        else if (PlayerMovement.instance._countRank <= 39)
        {
            _rank += 2;
        }
        else if (PlayerMovement.instance._countRank <= 49)
        {
            _rank += 1;
        }
        else if (PlayerMovement.instance._countRank <= 59)
        {
            _rank += 0;
        }

        if (_rank == 10)
        {
            _rankResult = "S";
        }
        else if (_rank >= 8)
        {
            _rankResult = "A";
        }
        else if (_rank >= 6)
        {
            _rankResult = "B";
        }
        else if (_rank >= 5)
        {
            _rankResult = "C";
        }
        else if (_rank >= 3)
        {
            _rankResult = "D";
        }
        else if (_rank >= 1)
        {
            _rankResult = "F";
        }
        else if (_rank == 0)
        {
            _rankResult = "간고등어";
        }

        if (_rankResult == "S" && DiffiManager.instance._secret)
        {
            _resultMessage = "아니 치트쓰지 마시라구요";
        }
        else if (_rankResult == "S" && DiffiManager.instance._hard)
        {
            _resultMessage = "제작자보다 잘하시는데요..?";
        }
        else if (_rankResult == "S" && DiffiManager.instance._normal)
        {
            _resultMessage = "S인데 보통은 더 애매하긴해";
        }
        else if (_rankResult == "S" && DiffiManager.instance._easy)
        {
            _resultMessage = "이지로 S찍었으면 보통도 S찍어야겠지?";
        }
        else if (_rankResult == "A" && DiffiManager.instance._secret)
        {
            _resultMessage = "아니 이거 어캐 깼어요";
        }
        else if (_rankResult == "A" && DiffiManager.instance._hard)
        {
            _resultMessage = "이정도면 상위권 거뜬하죠!";
        }
        else if (_rankResult == "A" && DiffiManager.instance._normal)
        {
            _resultMessage = "A인데 보통은 애매하긴해";
        }
        else if (_rankResult == "A" && DiffiManager.instance._easy)
        {
            _resultMessage = "보통도 한번 도전해보시죠!";
        }
        else if (_rankResult == "B" && DiffiManager.instance._secret)
        {
            _resultMessage = "겁내 지리시는군요!";
        }
        else if (_rankResult == "B" && DiffiManager.instance._hard)
        {
            _resultMessage = "그래도 이정도면 잘하는거 인정합니다!";
        }
        else if (_rankResult == "B" && DiffiManager.instance._normal)
        {
            _resultMessage = "그래도 잘하셨는데 어려움도 한번 도전해보시죠?";
        }
        else if (_rankResult == "B" && DiffiManager.instance._easy)
        {
            _resultMessage = "파쿠르는 꽤 하셨나봐요?";
        }
        else if (_rankResult == "C" && DiffiManager.instance._secret)
        {
            _resultMessage = "요이!!!!!!!!";
        }
        else if (_rankResult == "C" && DiffiManager.instance._hard)
        {
            _resultMessage = "다음에는 B가야죠?";
        }
        else if (_rankResult == "C" && DiffiManager.instance._normal)
        {
            _resultMessage = "실력이 조금 애매하긴 한데.. 그래도 고생하셨습니다";
        }
        else if (_rankResult == "C" && DiffiManager.instance._easy)
        {
            _resultMessage = "보통도 해보셔야 실력이 늘어날 것 같습니다!";
        }
        else if (_rankResult == "D" && DiffiManager.instance._secret)
        {
            _resultMessage = "등급이 낮아도 시크릿을 깬거는 대단한거죠!";
        }
        else if (_rankResult == "D" && DiffiManager.instance._hard)
        {
            _resultMessage = "어려움은 괜찮았나요?";
        }
        else if (_rankResult == "D" && DiffiManager.instance._normal)
        {
            _resultMessage = "애매한데";
        }
        else if (_rankResult == "D" && DiffiManager.instance._easy)
        {
            _resultMessage = "점프맵 처음이신가요?";
        }
        else if (_rankResult == "F" && DiffiManager.instance._secret)
        {
            _resultMessage = "등급이 조금 낮기는 한데 그래도 시크릿이니 봐드리겠습니다";
        }
        else if (_rankResult == "F" && DiffiManager.instance._hard)
        {
            _resultMessage = "등급이 낮기는 한데 어려움이면 아주 조금 봐드리겠습니다";
        }
        else if (_rankResult == "F" && DiffiManager.instance._normal)
        {
            _resultMessage = "어디서 많이 막히셨나요?";
        }
        else if (_rankResult == "F" && DiffiManager.instance._easy)
        {
            _resultMessage = "간고등어 아닌게 어디에요~";
        }
        else if (_rankResult == "간고등어" && DiffiManager.instance._secret)
        {
            _resultMessage = "시크릿이여도 다음에는 최소 F는 찍으십시요";
        }
        else if (_rankResult == "간고등어" && DiffiManager.instance._hard)
        {
            _resultMessage = "아무리 어려움이여도 간고등어는 조금..";
        }
        else if (_rankResult == "간고등어" && DiffiManager.instance._normal)
        {
            _resultMessage = "이정도면 쉬움도 힘들겠는데요?";
        }
        else if (_rankResult == "간고등어" && DiffiManager.instance._easy)
        {
            _resultMessage = "접으세요";
        }
    }
}