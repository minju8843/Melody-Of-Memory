using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Note_1105 : MonoBehaviour
{

    public Animator anim;//추가
    public int anim_count = 0;

    public float beatTempo;//노트가 얼마나 빨리 떨어지는지//Beat_Scroller에서 가져옴
    public bool hasStarted;//Beat_Scroller에서 가져옴

    public bool canBePressed = false;//
   // public KeyCode keyToPress;//각 화살표에 말할 키코드

    public GameObject Effect_0, Effect_1, Effect_2, Effect_3, Effect_4, Effect_5;//버튼 눌렀을 때 나오는 이펙트

    public GameObject Long_Effect_0, Long_Effect_1, Long_Effect_2, Long_Effect_3, Long_Effect_4, Long_Effect_5;//롱 노트 눌렀을 때 나오는 이펙트

    //public GameObject Combo_Effect;

    public static Note_1105 instance;//공개 스태택 게임 관리자 생성

    public RectTransform rect;

    //public Button[] btn;

    public Transform parentCanvasTransform;

    public bool Button_0_Pressed = false;
    public bool Button_1_Pressed = false;
    public bool Button_2_Pressed = false;
    public bool Button_3_Pressed = false;
    public bool Button_4_Pressed = false;
    public bool Button_5_Pressed = false;

    //public Long_Note long_note;

    //public bool[] Long_Note_Miss = new bool[39];//롱노트 미스인지 아닌지에 대한 bool

    /*public void YourClassName() //롱노트 미스 여부 처음엔 모두 false인 상태로
    {
        for (int i = 0; i < Long_Note_Miss.Length; i++)
        {
            Long_Note_Miss[i] = false; // 모든 값을 false로 초기화 -> 모두 미스가 아닌 상태
        }
    }*/

    void Start()
    {
        beatTempo = beatTempo/2f;
        //설정한 비트 템포를 사용해야 함
        //60으로 나눌거임
        //모두가 beatTempo은 beatTempo/60인 것과 같다고 할 거임 
        //그러면 이게 초당 얼마나 빨리 움직여야 하는지 알 수 있다.
        //120에서 초당 2단위로 움직일 것이라고 말하면 템포를 60으로 나눈 것이다.
        //그러면 초당 얼마나 빨리 움직이는지 알 수 있다.
        //->Update에서 else로 이동

        instance = this;



    }

    public void Update()
    {


        /* if (hasStarted == true)
         {

             //원래 주석 없는데, Winter_Music 및 다른 곳에서 제어중
             if (rect.anchoredPosition.y > -18.58201)//-24.9f)//0.012f)//&& gameObject.name != "롱 노트 테스트5_1" && gameObject.name != "롱 노트 테스트5_0")//0.01222
             {
                 rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);

                 //Debug.Log("아직 미스 아님");

                 //시작은 되었지만 아직 검은 줄 아래까지 오지 않은 경우
             }

             //Debug.Log(rect.anchoredPosition.y);

             //Debug.Log("Long_Note_5:"transform.position.y);

             //126.6246이 버튼 누르기 바로 직전 위치

             //126.0489가 위에서 버튼에 살짝 닿았을 때 -> 굿
             //107.7897이 아래에서 버튼에 살짝 닿았을 때 -> 굿

             //117.4809 가 완전 가운데

             //120.7801가 위에서 퍼펙트 허용 범위
             //114.1941가 아래에서 퍼펙트 허용 범위


             //106.272가 푸른색 버튼 거의 바로 밑에, 106.6422
         }*/

        if (rect.anchoredPosition.y > -18.58201)//-24.9f)//0.012f)//&& gameObject.name != "롱 노트 테스트5_1" && gameObject.name != "롱 노트 테스트5_0")//0.01222
        {
            if(Winter_Music.instance.Pause.activeSelf == true || Winter_Music.instance.keep_speed == false)
            {
                //퍼즈 창이 열려있다면
                rect.anchoredPosition -= new Vector2(0f, 0 * Time.deltaTime);
                anim_count = 0;
            }

            if(Winter_Music.instance.Pause.activeSelf == false && Winter_Music.instance.keep_speed == true)
            {
                //퍼즈 창이 닫혀있다면
                rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
                anim_count = 0;
            }

            //Debug.Log("아직 미스 아님");

            //시작은 되었지만 아직 검은 줄 아래까지 오지 않은 경우
        }


        //일반 오브젝트 투명하게
        if (rect.anchoredPosition.y <= -18.58201f && anim_count == 0 && Winter_Music.instance.keep_speed == true)//0.01222
        {

            StartCoroutine(Go_Empty());

            IEnumerator Go_Empty()
            {
                yield return new WaitForSeconds(0.07f);

                anim.SetTrigger("Empty");
                anim_count++;
                //Debug.Log("투명해지는 애니메이션 실행");

                Button_0_Pressed = false;
                Button_1_Pressed = false;
                Button_2_Pressed = false;
                Button_3_Pressed = false;
                Button_4_Pressed = false;
                Button_5_Pressed = false;

                StartCoroutine(Go_Empty1());
            }

            IEnumerator Go_Empty1()
            {
                yield return new WaitForSeconds(0.35f);//애니메이션 속도 + 0.05증가
                { 
                
                    gameObject.SetActive(false);                               // gameObject.SetActive(false);
                    anim_count = 0;

                    
                }
                
            }

            //Debug.Log("transform.position.y :" + transform.position.y);


        }



        //키를 누르면 
        if (canBePressed)
        {



            //롱 노트 0-0
            if (gameObject.name == "롱 노트 테스트0_0" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 0-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[1].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[1].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 0-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[1].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[1].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

            }

            //0-1
            if (gameObject.name == "롱 노트 테스트0_1" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 0-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[4].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[4].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 0-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[4].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[4].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;
  
                }

            }

            //0-2
            if (gameObject.name == "롱 노트 테스트0_2" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 0-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[15].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[15].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 0-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[15].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[15].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

            }

            //1-0
            if (gameObject.name == "롱 노트 테스트1_0" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 1-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }


                    Long_Note.instance.long_col[6].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[6].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 1-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[6].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[6].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-1
            if (gameObject.name == "롱 노트 테스트1_1" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 1-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[8].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[8].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 1-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[8].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[8].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-2
            if (gameObject.name == "롱 노트 테스트1_2" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 1-2히트했소이다");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[10].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[10].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 1-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[10].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[10].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-3
            if (gameObject.name == "롱 노트 테스트1_3" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("롱 노트 1-3히트했소이다");
                    gameObject.SetActive(false);


                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    Debug.Log("롱 노트 1-3히트했소이다");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-4
            if (gameObject.name == "롱 노트 테스트1_4" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 1-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[31].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[31].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 1-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[31].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[31].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //2-0
            if (gameObject.name == "롱 노트 테스트2_0" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[5].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[5].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[5].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[5].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-1
            if (gameObject.name == "롱 노트 테스트2_1" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[20].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[20].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[20].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[20].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-2
            if (gameObject.name == "롱 노트 테스트2_2" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-3
            if (gameObject.name == "롱 노트 테스트2_3" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[25].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[25].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[25].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[25].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-4
            if (gameObject.name == "롱 노트 테스트2_4" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[26].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[26].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[26].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[26].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-5
            if (gameObject.name == "롱 노트 테스트2_5" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[33].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[33].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[33].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[33].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-6
            if (gameObject.name == "롱 노트 테스트2_6" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 2-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[34].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[34].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 2-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[34].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[34].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //3-0
            if (gameObject.name == "롱 노트 테스트3_0" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-0히트했소이다");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[7].long_col[7].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[7].long_note_col[7].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[7].long_col[7].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[7].long_note_col[7].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-1
            if (gameObject.name == "롱 노트 테스트3_1" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 3-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[9].long_col[9].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[9].long_note_col[9].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[9].long_col[9].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[9].long_note_col[9].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-2
            if (gameObject.name == "롱 노트 테스트3_2" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-2히트했소이다");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[11].long_col[11].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[11].long_note_col[11].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[11].long_col[11].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[11].long_note_col[11].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-3
            if (gameObject.name == "롱 노트 테스트3_3" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 3-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[13].long_col[13].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[13].long_note_col[13].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[13].long_col[13].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[13].long_note_col[13].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-4
            if (gameObject.name == "롱 노트 테스트3_4" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 3-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[19].long_col[19].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Manager_0.instance.long_note[19].long_note_col[19].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[19].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[19].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-5
            if (gameObject.name == "롱 노트 테스트3_5" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 3-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[27].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[27].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[27].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[27].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-6
            if (gameObject.name == "롱 노트 테스트3_6" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 3-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[36].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[36].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 3-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[36].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[36].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }



            //롱 노트 4-0
            if (gameObject.name == "롱 노트 테스트4_0" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                //-2.86404f
                //-17.58401

                /*if ((transform.position.y < 49.51384f && transform.position.y > 49.51339f) ||
                      (transform.position.y > 49.51233f && transform.position.y < 49.51286f))//롱노트 한정
               */
                {
                    //49.51374 -> 49.51384
                    //Debug.Log("롱 노트 5-0히트했소이다");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;

                    // UI_GameManager.instance.Good_Hit();
                    //UI_GameManager.instance.Good_Hits++;
                    Debug.Log("롱 노트 4-0히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       // Debug.Log("4-0 굿");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-0 굿2");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[2].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[2].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;


                    //Debug.Log("이펙트4 실행 확인-롱노트 굿 히트");

                    //Long_Note.instance.long_note_5_0 = true;//롱 노트 뒤에 있는 흰색 친구 누름(히트 될거임)

                    //마스크 활성화 -> 왜나하면 성공했으니까 노트와 흰 부분이 안보여야 함
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {

                    // Debug.Log("롱 노트 치긴 했음");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;
                    // Debug.Log("롱 노트 5-0 퍼펙트 히트했소이다");
                    Debug.Log("롱 노트 4-0히트했소이다");
                    //잠시 비활성 0823
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        //Debug.Log("4-0 퍼펙트");
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        //Debug.Log("4-0 퍼펙트2");
                    }

                    Long_Note.instance.long_col[2].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[2].enabled = true; //롱노트 중간 부분의 콜라이더 활성
                    //Debug.Log("이펙트4 실행 확인-롱노트 퍼펙트 히트");
                    // Debug.Log("게임 오브젝트의 이름이 '너 퍼페그'입니다.");
                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;
                    //Debug.Log("이펙트5 실행 확인-롱노트 퍼펙트 히트");

                    //Long_Note.instance.long_note_5_0 = true;//롱 노트 뒤에 있는 흰색 친구 누름(히트 될거임)

                    //마스크 활성화 -> 왜나하면 성공했으니까 노트와 흰 부분이 안보여야 함
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;
                }
                //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);

            }

            

            //4-1
            if (gameObject.name == "롱 노트 테스트4_1" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[3].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[3].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[3].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[3].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-2
            if (gameObject.name == "롱 노트 테스트4_2" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[16].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[16].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[16].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[16].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-3
            if (gameObject.name == "롱 노트 테스트4_3" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[17].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[17].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-3히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[17].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[17].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-4
            if (gameObject.name == "롱 노트 테스트4_4" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[18].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[18].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-4히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[18].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[18].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-5
            if (gameObject.name == "롱 노트 테스트4_5" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[21].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[21].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-5히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[21].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[21].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-6
            if (gameObject.name == "롱 노트 테스트4_6" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[22].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[22].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-6히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[22].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[22].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-7
            if (gameObject.name == "롱 노트 테스트4_7" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-7히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[23].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[23].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-7히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[23].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[23].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-8
            if (gameObject.name == "롱 노트 테스트4_8" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-8히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[28].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[28].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-8히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[28].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[28].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-9
            if (gameObject.name == "롱 노트 테스트4_9" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-9히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[29].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[29].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-9히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[29].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[29].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-10
            if (gameObject.name == "롱 노트 테스트4_10" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-10히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[30].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[30].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-10히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[30].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[30].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-11
            if (gameObject.name == "롱 노트 테스트4_11" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-11히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[32].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[32].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-11히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[32].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[32].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-12
            if (gameObject.name == "롱 노트 테스트4_12" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("롱 노트 4-12히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[35].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[35].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 4-12히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[35].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[35].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-13
            if (gameObject.name == "롱 노트 테스트4_13" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("롱 노트 4-13히트했소이다");
                    gameObject.SetActive(false);


                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[38].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[38].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    Debug.Log("롱 노트 4-13히트했소이다");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[38].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[38].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }


            //롱노트 5-0
            if (gameObject.name == "롱 노트 테스트5_0" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                //-2.86404f
                //-17.58401

                /*if ((transform.position.y < 49.51384f && transform.position.y > 49.51339f) ||
                      (transform.position.y > 49.51233f && transform.position.y < 49.51286f))//롱노트 한정
               */
                {
                    //49.51374 -> 49.51384
                    Debug.Log("롱 노트 5-0히트했소이다");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;

                    // UI_GameManager.instance.Good_Hit();
                    //UI_GameManager.instance.Good_Hits++;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[0].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[0].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
                    //Debug.Log("이펙트5 실행 확인-롱노트 굿 히트");

                    //Long_Note.instance.long_note_5_0 = true;//롱 노트 뒤에 있는 흰색 친구 누름(히트 될거임)

                    //마스크 활성화 -> 왜나하면 성공했으니까 노트와 흰 부분이 안보여야 함
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {

                    // Debug.Log("롱 노트 치긴 했음");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;
                     Debug.Log("롱 노트 5-0 퍼펙트 히트했소이다");

                    //잠시 비활성 0823
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[0].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[0].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    // Debug.Log("게임 오브젝트의 이름이 '너 퍼페그'입니다.");
                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
                    //Debug.Log("이펙트5 실행 확인-롱노트 퍼펙트 히트");

                    //Long_Note.instance.long_note_5_0 = true;//롱 노트 뒤에 있는 흰색 친구 누름(히트 될거임)

                    //마스크 활성화 -> 왜나하면 성공했으니까 노트와 흰 부분이 안보여야 함
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;
                }
                //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);

            }

            //5-1
            if (gameObject.name == "롱 노트 테스트5_1" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("롱 노트 5-1히트했소이다");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[14].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[14].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
  

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 5-1히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[14].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[14].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
   
                }


            }

            //5-2
            if (gameObject.name == "롱 노트 테스트5_2" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("롱 노트 5-2히트했소이다");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[37].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[37].enabled = true; //롱노트 중간 부분의 콜라이더 활성


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;


                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("롱 노트 5-2히트했소이다");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[37].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    Long_Note.instance.long_note_col[37].enabled = true; //롱노트 중간 부분의 콜라이더 활성

                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;

                }


            }

            //여기부터 일반 노트
            if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                 (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f)
                && gameObject.name != "롱 노트 테스트5_0" && gameObject.name != "롱 노트 테스트4_0"
                && gameObject.name != "롱 노트 테스트0_0" && gameObject.name != "롱 노트 테스트4_1"
                && gameObject.name != "롱 노트 테스트0_1" && gameObject.name != "롱 노트 테스트2_0"
                && gameObject.name != "롱 노트 테스트1_0" && gameObject.name != "롱 노트 테스트3_0"
                && gameObject.name != "롱 노트 테스트1_1" && gameObject.name != "롱 노트 테스트3_1"
                && gameObject.name != "롱 노트 테스트1_2" && gameObject.name != "롱 노트 테스트3_2"
                && gameObject.name != "롱 노트 테스트2_2" && gameObject.name != "롱 노트 테스트3_3"
                && gameObject.name != "롱 노트 테스트0_2" && gameObject.name != "롱 노트 테스트5_1"
                && gameObject.name != "롱 노트 테스트4_2" && gameObject.name != "롱 노트 테스트4_3"
                && gameObject.name != "롱 노트 테스트4_4" && gameObject.name != "롱 노트 테스트3_4"
                && gameObject.name != "롱 노트 테스트2_1" && gameObject.name != "롱 노트 테스트4_5"
                && gameObject.name != "롱 노트 테스트4_6" && gameObject.name != "롱 노트 테스트4_7"

                && gameObject.name != "롱 노트 테스트1_3" && gameObject.name != "롱 노트 테스트2_3"
                && gameObject.name != "롱 노트 테스트2_4" && gameObject.name != "롱 노트 테스트3_5"
                && gameObject.name != "롱 노트 테스트4_8" && gameObject.name != "롱 노트 테스트4_9"
                && gameObject.name != "롱 노트 테스트4_10" && gameObject.name != "롱 노트 테스트1_4"
                && gameObject.name != "롱 노트 테스트4_11" && gameObject.name != "롱 노트 테스트2_5"
                && gameObject.name != "롱 노트 테스트2_6" && gameObject.name != "롱 노트 테스트4_12"
                && gameObject.name != "롱 노트 테스트3_6" && gameObject.name != "롱 노트 테스트5_2"
                && gameObject.name != "롱 노트 테스트4_13")
       
            {
                

                if (Button_0_Pressed == true
                    )

                {
                    Debug.Log("0 노트 굿 히트");

                    gameObject.SetActive(false);
                    Button_0_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Effect_0.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                if (Button_1_Pressed == true
                    )

                /*&& gameObject.name != "롱 노트 테스트5_1" && gameObject.name != "롱 노트 테스트5_0"
                && gameObject.name != "롱 노트 테스트4_1" && gameObject.name != "롱 노트 테스트4_0"*/
                {
                    Debug.Log("1 노트 굿 히트");
                    gameObject.SetActive(false);
                    Button_1_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Effect_1.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }


                if (Button_2_Pressed == true
                    )
                {
                    Debug.Log("2 노트 굿 히트");
                    gameObject.SetActive(false);
                    Button_2_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Effect_2.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                /*if (Button_3_Pressed == true)
                {

                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_3, new Vector3(11.58f, 2.784f, -0.062f), Effect_3.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[3].enabled = false;
                }*/

                if (Button_3_Pressed == true
                    )

                /*&& gameObject.name != "롱 노트 테스트5_1" && gameObject.name != "롱 노트 테스트5_0"
                && gameObject.name != "롱 노트 테스트4_1" && gameObject.name != "롱 노트 테스트4_0"*/
                {
                    Debug.Log("3 노트 굿 히트");
                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                if (Button_4_Pressed == true)
                {
                    Debug.Log("4 노트 굿 히트");
                    gameObject.SetActive(false);
                    Button_4_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_4, new Vector3(15.414f, 2.773f, -0.079f), Effect_4.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Effect_4.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    // Manager_0.instance.Long_Line_Mask[4].enabled = false;
                }

                if (Button_5_Pressed == true
                    )

                    /*&& gameObject.name != "롱 노트 테스트5_1" && gameObject.name != "롱 노트 테스트5_0"
                    && gameObject.name != "롱 노트 테스트4_1" && gameObject.name != "롱 노트 테스트4_0"*/
                {
                    Debug.Log("5 노트 굿 히트");
                    gameObject.SetActive(false);
                    Button_5_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Effect_5.transform.rotation;


                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

            }

            /*
             *((transform.position.y > 139.0783f && transform.position.y <= 146.7998f) ||
                 (transform.position.y >= 82.94745f && transform.position.y < 89.55161f))*/

            //퍼펙트 히트
            if (rect.anchoredPosition.y <= -7.446072f && rect.anchoredPosition.y >= -15.325f
               && gameObject.name != "롱 노트 테스트5_0" && gameObject.name != "롱 노트 테스트4_0"
                && gameObject.name != "롱 노트 테스트0_0" && gameObject.name != "롱 노트 테스트4_1"
                && gameObject.name != "롱 노트 테스트0_1" && gameObject.name != "롱 노트 테스트2_0"
                && gameObject.name != "롱 노트 테스트1_0" && gameObject.name != "롱 노트 테스트3_0"
                && gameObject.name != "롱 노트 테스트1_1" && gameObject.name != "롱 노트 테스트3_1"
                && gameObject.name != "롱 노트 테스트1_2" && gameObject.name != "롱 노트 테스트3_2"
                && gameObject.name != "롱 노트 테스트2_2" && gameObject.name != "롱 노트 테스트3_3"
                && gameObject.name != "롱 노트 테스트0_2" && gameObject.name != "롱 노트 테스트5_1"
                && gameObject.name != "롱 노트 테스트4_2" && gameObject.name != "롱 노트 테스트4_3"
                && gameObject.name != "롱 노트 테스트4_4" && gameObject.name != "롱 노트 테스트3_4"
                && gameObject.name != "롱 노트 테스트2_1" && gameObject.name != "롱 노트 테스트4_5"
                && gameObject.name != "롱 노트 테스트4_6" && gameObject.name != "롱 노트 테스트4_7"

                && gameObject.name != "롱 노트 테스트1_3" && gameObject.name != "롱 노트 테스트2_3"
                && gameObject.name != "롱 노트 테스트2_4" && gameObject.name != "롱 노트 테스트3_5"
                && gameObject.name != "롱 노트 테스트4_8" && gameObject.name != "롱 노트 테스트4_9"
                && gameObject.name != "롱 노트 테스트4_10" && gameObject.name != "롱 노트 테스트1_4"
                && gameObject.name != "롱 노트 테스트4_11" && gameObject.name != "롱 노트 테스트2_5"
                && gameObject.name != "롱 노트 테스트2_6" && gameObject.name != "롱 노트 테스트4_12"
                && gameObject.name != "롱 노트 테스트3_6" && gameObject.name != "롱 노트 테스트5_2"
                && gameObject.name != "롱 노트 테스트4_13") //(transform.position.y <= 29.90797f && transform.position.y <= 44.29614f)
            {

                //0821 - 수정 전 좌표rect.anchoredPosition.y < 0.01387f && rect.anchoredPosition.y > 0.01307201f
                /*((transform.position.y < -3.297036f && transform.position.y > -3.477036f) ||
                 (transform.position.y > -4.34f && transform.position.y < -4.127036f))
                 */

                //원래 좌표
                //(transform.position.y < -3.467036 && transform.position.y > -3.637036)

                //-4.24 ~ -4.18
                //-4.46 ~ -4.39

                //-4.2 ~ -4.38


                //콤보 이펙트
                //Instantiate(Combo_Effect, new Vector3(8.626f, 0.817f, 0.0f), Combo_Effect.transform.rotation);

                /* Debug.Log("완벽하게 쳤음");
                 gameObject.SetActive(false);
                 UI_GameManager.instance.Perfect_Hit();

                 UI_GameManager.instance.Perfect_Hits++;*/


                //PC버튼
                if (Button_0_Pressed == true)
                {
                    Debug.Log("0 노트 퍼펙트 히트");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }


                    // 'A' 키가 눌렸을 때 실행할 코드
                    //Instantiate(Effect_0, new Vector3(0f, -0.031f, 0.02f), Effect_0.transform.rotation);
                    //Instantiate(Effect_0, new Vector3(-508f, 63.0f, 0f), Effect_0.transform.rotation);//-0.031 //1.0
                    GameObject newEffect = Instantiate(Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Effect_0.transform.rotation;

                    Button_0_Pressed = false;

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[0].enabled = false;
                }

                //모바일


                if (Button_1_Pressed == true)
                {
                    Debug.Log("1 노트 퍼펙트 히트");
                    gameObject.SetActive(false);
                    Button_1_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_1, new Vector3(3.81f, 2.8f, -0.03f), Effect_1.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Effect_1.transform.rotation;

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[1].enabled = false;
                }

                if (Button_2_Pressed == true)
                {
                    gameObject.SetActive(false);
                    Button_2_Pressed = false;

                    Debug.Log("2 노트 퍼펙트 히트");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_2, new Vector3(7.723f, 2.801f, -0.045f), Effect_2.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Effect_2.transform.rotation;

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[2].enabled = false;
                    // Destroy(gameObject);
                }

                if (Button_3_Pressed == true)
                {
                    Debug.Log("3 노트 퍼펙트 히트");
                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_3, new Vector3(11.58f, 2.784f, -0.062f), Effect_3.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;

                    //Destroy(gameObject);

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[3].enabled = false;
                }

                if (Button_4_Pressed == true)
                {
                    Debug.Log("4 노트 퍼펙트 히트");
                    gameObject.SetActive(false);
                    Button_4_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //UI_GameManager.instance.Perfect_Hit();
                    //UI_GameManager.instance.Perfect_Hits++;

                    //Instantiate(Effect_4, new Vector3(15.414f, 2.773f, -0.079f), Effect_4.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Effect_4.transform.rotation;


                    //Destroy(gameObject);

                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[4].enabled = false;

                }

                if (Button_5_Pressed == true)
                {
                    Debug.Log("5 노트 퍼펙트 히트");
                    gameObject.SetActive(false);
                    Button_5_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //UI_GameManager.instance.Perfect_Hit();
                    //UI_GameManager.instance.Perfect_Hits++;


                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Effect_5.transform.rotation;



                    //마스크 비활성화 -> 왜나하면 다음 노트가 롱노트일 수도 있으니까
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }


            }

        }

    }


    //노트가 버튼 영역에 들어갔을 때,
    //다시 전환할 때 확인

    //트리거 영역에 들어갔는지 확인하고 그렇다면 할 수 있다고 말하는 것

    //지금 버튼을 누르면 해당 버튼이 제시간에 눌러진다.
    //화살표를 제거하고 그렇지 않으면 더 이상 누를 수 없다.

    private void OnTriggerEnter2D(Collider2D other)
    {
        //트리거 시 무효화gkrh 2d를 입력하고 여기에서 서로 충돌을 변경

        if (other.tag == "Finish")//(other.tag == "Note")
        {
            //다른 태그가 같으면 activator라는 두 번째 태그에 이 새 태그를 생성
            //이게 바로 버튼이 될 것

            canBePressed = true;
            //Activator태그인 경우 새로운 bool을 설정하여 
            //canBePressed이 true와 같다고하고
            //입력할 때 누를 수 있는지 확인
            //
            //Debug.Log("지나가유");


        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = false;
            //OnTriggerExit2D를 누르면 false와 같다

            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트0_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-0 미스 노트 추가");

                if (Manager_0.instance.long_note[1].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[1].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[1].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[1].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

            }

            //0-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트0_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-1 미스 노트 추가");

                if (Manager_0.instance.long_note[4].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[4].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //0-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트0_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-2 미스 노트 추가");

                if (Manager_0.instance.long_note[15].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-2 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[15].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //1-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트1_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-0 미스 노트 추가");

                if (Manager_0.instance.long_note[6].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[6].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //1-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트1_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-1 미스 노트 추가");

                if (Manager_0.instance.long_note[8].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[8].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //1-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트1_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-2 미스 노트 추가");

                if (Manager_0.instance.long_note[10].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-2 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[10].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //1-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트1_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-3 미스 노트 추가");


                if (Manager_0.instance.long_note[24].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-3 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[24].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-3롱노트 미스 추가");
                }

                Long_Note.instance.long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //1-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트1_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 1-4 미스 노트 추가");

                if (Manager_0.instance.long_note[31].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-4 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[31].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-4롱노트 미스 추가");
                }

                Long_Note.instance.long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-0 미스 노트 추가");

                if (Manager_0.instance.long_note[5].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[5].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 2-1 미스 노트 추가");

                if (Manager_0.instance.long_note[20].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[20].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-2 미스 노트 추가");

                if (Manager_0.instance.long_note[12].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-2 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[12].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-3 미스 노트 추가");

                if (Manager_0.instance.long_note[25].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-3 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[25].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-3롱노트 미스 추가");
                }

                Long_Note.instance.long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-4 미스 노트 추가");

                if (Manager_0.instance.long_note[26].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-4 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[26].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-4롱노트 미스 추가");
                }

                Long_Note.instance.long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-5 미스 노트 추가");

                if (Manager_0.instance.long_note[33].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-5 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[33].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-5롱노트 미스 추가");
                }

                Long_Note.instance.long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //2-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트2_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-6 미스 노트 추가");

                if (Manager_0.instance.long_note[34].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-6 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[34].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-6롱노트 미스 추가");
                }

                Long_Note.instance.long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-0 미스 노트 추가");

                if (Manager_0.instance.long_note[7].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[7].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-1 미스 노트 추가");

                if (Manager_0.instance.long_note[9].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[9].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-2 미스 노트 추가");

                if (Manager_0.instance.long_note[11].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-2 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[11].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-3 미스 노트 추가");

                if (Manager_0.instance.long_note[13].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-3 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[13].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-3롱노트 미스 추가");
                }

                Long_Note.instance.long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-4 미스 노트 추가");

                if (Manager_0.instance.long_note[19].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-4 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[19].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-4롱노트 미스 추가");
                }

                Long_Note.instance.long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-5 미스 노트 추가");

                if (Manager_0.instance.long_note[27].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-5 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[27].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-5롱노트 미스 추가");
                }

                Long_Note.instance.long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //3-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트3_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-6 미스 노트 추가");

                if (Manager_0.instance.long_note[36].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-6 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[36].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-6롱노트 미스 추가");
                }

                Long_Note.instance.long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 4-0 미스 노트 추가");

                if (Manager_0.instance.long_note[2].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[2].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 4-1 미스 노트 추가");

                if (Manager_0.instance.long_note[3].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[3].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-2 미스 노트 추가");

                if (Manager_0.instance.long_note[16].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-2이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[16].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-3 미스 노트 추가");

                if (Manager_0.instance.long_note[17].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-3 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[17].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-3롱노트 미스 추가");
                }

                Long_Note.instance.long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-4 미스 노트 추가");

                if (Manager_0.instance.long_note[18].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-4 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[18].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-4롱노트 미스 추가");
                }

                Long_Note.instance.long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-5 미스 노트 추가");

                if (Manager_0.instance.long_note[21].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-5 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[21].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-5롱노트 미스 추가");
                }

                Long_Note.instance.long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-6 미스 노트 추가");

                if (Manager_0.instance.long_note[22].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-6 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[22].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-6롱노트 미스 추가");
                }

                Long_Note.instance.long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-7
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_7")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-7 미스 노트 추가");

                if (Manager_0.instance.long_note[23].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-7 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[23].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-7롱노트 미스 추가");
                }

                Long_Note.instance.long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-8
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_8")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-8 미스 노트 추가");

                if (Manager_0.instance.long_note[28].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-8 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[28].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-8롱노트 미스 추가");
                }

                Long_Note.instance.long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-9
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_9")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-8 미스 노트 추가");

                if (Manager_0.instance.long_note[29].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-9 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[29].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-9롱노트 미스 추가");
                }

                Long_Note.instance.long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-10
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_10")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-10 미스 노트 추가");

                if (Manager_0.instance.long_note[30].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-10 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[30].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-10롱노트 미스 추가");
                }

                Long_Note.instance.long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-11
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_11")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-11 미스 노트 추가");

                if (Manager_0.instance.long_note[32].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-11 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[32].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-11롱노트 미스 추가");
                }

                Long_Note.instance.long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-12
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_12")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-12 미스 노트 추가");

                if (Manager_0.instance.long_note[35].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-12 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[35].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-12롱노트 미스 추가");
                }

                Long_Note.instance.long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }

            //4-13
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트4_13")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-13 미스 노트 추가");

                if (Manager_0.instance.long_note[38].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-13 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[38].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-13롱노트 미스 추가");
                }

                Long_Note.instance.long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
            }
            //5-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트5_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-0 미스 노트 추가");

                if (Manager_0.instance.long_note[0].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-0 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[0].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-0롱노트 미스 추가");
                }

                Long_Note.instance.long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

            }

            //5-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트5_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-1 미스 노트 추가");

                if (Manager_0.instance.long_note[14].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-1 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[14].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-1롱노트 미스 추가");
                }

                Long_Note.instance.long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                /* Manager_0.instance.Note_Missed();
                 Manager_0.instance.Miss_Hits++;

                 Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                 Long_Note.instance.no_hit_5++;

                 Long_Note.instance.long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                 Long_Note.instance.long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                */
                //Debug.Log("5-1롱노트 미스 추가");

            }

            //5-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "롱 노트 테스트5_2")//-4.431 //-4.44  
            {

                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-2 미스 노트 추가");

                if (Manager_0.instance.long_note[37].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-2 이미 롱노트 미스 됐음");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//롱 노트 흰색 부분 끝까지 못침
                    Manager_0.instance.long_note[37].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-2롱노트 미스 추가");
                }

                Long_Note.instance.long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                Long_Note.instance.long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

            }

            if (rect.anchoredPosition.y <= -18.58201f
                && gameObject.name != "롱 노트 테스트5_0" && gameObject.name != "롱 노트 테스트4_0"
                && gameObject.name != "롱 노트 테스트0_0" && gameObject.name != "롱 노트 테스트4_1"
                && gameObject.name != "롱 노트 테스트0_1" && gameObject.name != "롱 노트 테스트2_0"
                && gameObject.name != "롱 노트 테스트1_0" && gameObject.name != "롱 노트 테스트3_0"
                && gameObject.name != "롱 노트 테스트1_1" && gameObject.name != "롱 노트 테스트3_1"
                && gameObject.name != "롱 노트 테스트1_2" && gameObject.name != "롱 노트 테스트3_2"
                && gameObject.name != "롱 노트 테스트2_2" && gameObject.name != "롱 노트 테스트3_3"
                && gameObject.name != "롱 노트 테스트0_2" && gameObject.name != "롱 노트 테스트5_1"
                && gameObject.name != "롱 노트 테스트4_2" && gameObject.name != "롱 노트 테스트4_3"
                && gameObject.name != "롱 노트 테스트4_4" && gameObject.name != "롱 노트 테스트3_4"
                && gameObject.name != "롱 노트 테스트2_1" && gameObject.name != "롱 노트 테스트4_5"
                && gameObject.name != "롱 노트 테스트4_6" && gameObject.name != "롱 노트 테스트4_7"

                && gameObject.name != "롱 노트 테스트1_3" && gameObject.name != "롱 노트 테스트2_3"
                && gameObject.name != "롱 노트 테스트2_4" && gameObject.name != "롱 노트 테스트3_5"
                && gameObject.name != "롱 노트 테스트4_8" && gameObject.name != "롱 노트 테스트4_9"
                && gameObject.name != "롱 노트 테스트4_10" && gameObject.name != "롱 노트 테스트1_4"
                && gameObject.name != "롱 노트 테스트4_11" && gameObject.name != "롱 노트 테스트2_5"
                && gameObject.name != "롱 노트 테스트2_6" && gameObject.name != "롱 노트 테스트4_12"
                && gameObject.name != "롱 노트 테스트3_6" && gameObject.name != "롱 노트 테스트5_2"
                && gameObject.name != "롱 노트 테스트4_13")//-4.431 //-4.44  
            {//0821-수정 전 -4.34
                Manager_0.instance.Note_Missed();
                //게임 매니저야, 놓쳤다고 해줘
                //Debug.Log("게임 매니저야, 놓쳤다고 해줘");
                Manager_0.instance.Miss_Hits++;
                Debug.Log("*******일반 노트 미스했소이다");


            }



        }

    }

}
