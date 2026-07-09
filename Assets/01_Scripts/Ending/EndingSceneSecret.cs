using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndingSceneSecret : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _pannel;
    [SerializeField] private GameObject _camera;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Light2D _light;

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

    [SerializeField] int _rank = 0;


    private void Start()
    {
        StartCoroutine(Text());
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Text()
    {
        _text.SetText("나는 달에 다가갈려고 계속 뛰었다");
        yield return new WaitForSeconds(4f);
        _text.SetText("달에는 분명 멋진 것이 있다고 생각하였다");
        yield return new WaitForSeconds(4f);
        _text.SetText("그래서 더 뛰고 더 뛰고.. 계속 뛰고.. 끊임없이 뛰었다");
        yield return new WaitForSeconds(4f);
        _text.SetText("그저 달 한번을 보기위해..");
        yield return new WaitForSeconds(4f);
        _text.SetText("아무리 지쳐도.. 나는 계속 뛰었다");
        yield return new WaitForSeconds(4f);
        _text.SetText("나의 노력 끝에 볼 수 있던것은..");
        yield return new WaitForSeconds(4f);
        _light.intensity = 1;
        _text.SetText("달에 있는 마을과 그 마을에 살고있는 토끼들이였다");
        yield return new WaitForSeconds(5f);
        _text.SetText("토끼들은 각자 웃는 모습으로 일을 했다");
        yield return new WaitForSeconds(5f);
        _text.SetText("토끼들의 모습은 거의 똑같았지만");
        yield return new WaitForSeconds(5f);
        _text.SetText("전혀 다른 느낌이였다");
        yield return new WaitForSeconds(5f);
        _text.SetText("예를 들면..");
        yield return new WaitForSeconds(5f);
        _text.SetText("각자 하는 일을 다 다르달까?");
        yield return new WaitForSeconds(5f);
        _text.SetText("한번 다가갈려고 해보았다");
        yield return new WaitForSeconds(5f);
        _text.SetText("하지만 시간이 너무 오래 지난 탓일까?");
        yield return new WaitForSeconds(5f);
        _text.SetText("슬슬 시야가 흐려진다");
        yield return new WaitForSeconds(5f);
        _text.SetText("이제 잠에서 깨어난다는 것을 직감적으로 알았다");
        yield return new WaitForSeconds(5f);
        _text.SetText("그달에 사는 토끼는 진짜였을까?");
        yield return new WaitForSeconds(5f);
        _text.SetText("달에 있는 마을도 진짜였을까?");
        yield return new WaitForSeconds(5f);
        _text.SetText("...");
        yield return new WaitForSeconds(5f);
        _text.SetText("내가 꿈에서 본것은.. 현실일까..?");
        yield return new WaitForSeconds(5f);
        _pannel.SetActive(false);
        _UI.SetActive(false);
        yield return new WaitForSeconds(10f);
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
            if (DiffiManager.instance._secret)
            {
                _themeResult = "시크릿";
            }

            if (PlayerMovement.instance._jumpCount <= 300)
            {
                _rank += 5;
            }
            else if (PlayerMovement.instance._jumpCount <= 400)
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
            else if (_rankResult == "A" && DiffiManager.instance._secret)
            {
                _resultMessage = "아니 이거 어캐 깼어요";
            }
            else if (_rankResult == "B" && DiffiManager.instance._secret)
            {
                _resultMessage = "겁내 지리시는군요!";
            }
            else if (_rankResult == "C" && DiffiManager.instance._secret)
            {
                _resultMessage = "요이!!!!!!!!";
            }
            else if (_rankResult == "D" && DiffiManager.instance._secret)
            {
                _resultMessage = "등급이 낮아도 시크릿을 깬거는 대단한거죠!";
            }
            else if (_rankResult == "F" && DiffiManager.instance._secret)
            {
                _resultMessage = "시간이 오래 걸리신것 같군요.. 걱정마세요 저도 입니다";
            }
            else if (_rankResult == "간고등어" && DiffiManager.instance._secret)
            {
                _resultMessage = "고생하셨습니다";
            }
        }
}
