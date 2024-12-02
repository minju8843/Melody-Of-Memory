using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Manager_0 : MonoBehaviour
{
    public GameObject[] Nor_Note_Log;//Note_1105인데 롱노트 인
    public Note_1105[] Note_1105_Log;//Note_1105인데 롱노트와 관련 있는 스크립트


    public GameObject Result_Panel;//결과 창 오브젝트

    public GameObject Perfect_Combo_Effect;//콤보 이펙트

    public GameObject Normal_Combo_Effect;//노멀 콤보 이펙트

    public Animator Charming_anim;//차밍 애니메이션
    public GameObject Charming_obj;//차밍 글씨

    public TextMeshProUGUI Total_Charming_Text; //총 차밍 텍스트
    public int Total_Charming_Count; //차밍이 총 몇 번째 나왔는지

    public TextMeshProUGUI Total_ScoreText;//총 점수

    public TextMeshProUGUI ScoreText;
    // public TextMeshProUGUI multiText;//몇 번째 시도인지

    public Animator Combo_anim;//콤보 애니메이션
    public GameObject Combo_obj;
    public TextMeshProUGUI Combo_Text; //몇 번째 콤보인지 텍스트
    public int Combo_Count;//몇 번째 콤보인지



    public AudioSource Music_0;//음악
    public bool StartPlaying;//음악 재생 호출

    public Note_1105[] theBS;//비트 스크롤러 제어(Note_Object)
    public Long_Note[] long_note;//Long Lote오브젝트 
    public Long_Col[] long_note_fin;//Long Lote 끝부분 오브젝트

    public static Manager_0 instance;//공개 스태택 게임 관리자 생성
    //인스턴스 호출


    //public int currentMultipiler;//승수 관련. 
    //public int multiplierTracker;//승수 추적기. 승수 추적기는 0에서 시작함
    //public int[] multiplierThresholds;//승수 임계값 호출


    public float currentScore;//현재 점수
    //public float scorePerNote=0.10f;//노트당 점수

    public float scorePerGoodNote = 2.67208f;//굿 노트당 점수
    public float scorePerPerfectNote = 5f;//퍼펙트 노드당 점수




    public float Total_Notes;//좋은 일과 나쁜 일 등을 한 히트의 비율을 계산
    public int Good_Hits;//잘 쳤음
    public int Perfect_Hits;//완벽하게 쳤음
    public int Miss_Hits;//잘 못쳤음
    public int Long_Note_Miss;//롱노트 흰색 부분 끝까지 못침


    public Note_1105[] Line_0;
    public Note_1105[] Line_1;
    public Note_1105[] Line_2;
    public Note_1105[] Line_3;
    public Note_1105[] Line_4;
    public Note_1105[] Line_5;

    private bool hasShownResult = false;

    /*public Button button_0;//버튼 눌림 확인
    public Button button_1;//버튼 눌림 확인
    public Button button_2;//버튼 눌림 확인
    public Button button_3;//버튼 눌림 확인
    public Button button_4;//버튼 눌림 확인
    public Button button_5;//버튼 눌림 확인
    */
    //public TextMeshProUGUI Charming_Total_Text; //Charming이 총 몇 번인지 보여주는 텍스트
    //public int Charming_Total;//Charming이 총 몇 번 나왔는지

    //public Mask[] Long_Line_Mask;//롱 노트가 현재 잘 눌리고 있을 때 실행될 마스크

    private void Start()
    {
        //Application.targetFrameRate = 300;//버벅거리는 문제 해결하기 위한 코드

       // Winter_Music.instance.Keep_Speed();
        //StartCoroutine(Music_Go());
    

    /*IEnumerator Music_Go()
    {
        yield return new WaitForSeconds(11f);//5초보다는 크고
            Winter_Music.instance.Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Music.instance.Winter_Music_Obj[0].SetActive(true);//윈터 0번째 음악 리듬게임 비활성
            Winter_Music.instance.Winter_Music_Audio[0].Play();
    }*/

    /*for (int i = 0; i < Long_Line_Mask.Length; i++)
    {
        //마스크 비활성화
        Long_Line_Mask[i].enabled = false;
    }*/


    //Total_Notes = FindObjectsOfType<UI_Note_Object>().Length;//Total_Note가 만들어야 하는 유형의 객체를 찾는 것과 같다.
    //모든 개체를 찾고 싶기 때문에 objects
    Result_Panel.SetActive(false);//아직 결과창 비활성


        Total_Charming_Count = 0;//차밍 아직 없는 상태

        instance = this;
        Combo_obj.SetActive(false);
        Charming_obj.SetActive(false);

        //이렇게 하면 이걸 private(정적)으로 만들 때 게임 관리자는
        //하나만 갖게 됨

        //즉 모든 변수가 하나만 있을 수 있다는 뜻

        ScoreText.text = "0.00%";//처음은 0%로 시작
        // currentMultipiler = 1;//현재 승수가 실제로 1로 설정되어 있는지 확인

        currentScore = 0;

        //Note_Object스크립트를 연결하고 그 중 몇 개가 있는지 계산하면
        //총 노트가 만들어야 하는 유형의 객체를 찾는 것과 같다고 할 수 있다.

        //모든 개체를 찾을 거임
        //우리가 찾고 싶은 사이트에서 유형의 개체를 찾아야 함
        //내 페이지에 있는길이를 구해본다.
        //그 길이를 구하면 길이는 장면에 있는 객체의 수에 비례한다.
        //total_Notes = FindObjectOfType<Note_Object>().Length;

    }


    private void Update()
    {
        //여기부터는 절대 지우지 말어
        Total_Charming_Count = Good_Hits + Perfect_Hits;//총 몇 번 쳤는지


    
        //실행 편리하게 하기 위해 임시로 만든 코드
        /*if (Input.anyKeyDown)
        {
            Winter_Music.instance.Keep_Speed();
            Winter_Music.instance.Winter_Music_Audio[0].Play();
        }*/

       // Winter_Music.instance.Keep_Speed();

        //음악 재생 등을 시작할 때 제어
        //재생을 시작하면 기본적으로 false여야 함.
        /* if (StartPlaying == false)
         {
             //재생을 시작하지 않았다면,
             //사용자가 아무 버튼이나 누르는지 확인하기를 기다리고 있으므로 
             //입력이 부적절하게 키를 누르는 경우 

             //이거 문제가 아님
             if (Input.anyKeyDown)
             {


                 StartCoroutine(Go_Empty());

                 IEnumerator Go_Empty()
                 {
                     yield return new WaitForSeconds(2.0f);

                     //원래 주석 없는데, Winter_Music 및 다른 곳에서 제어중
                     for (int i = 0; i < theBS.Length; i++)
                     {
                         theBS[i].hasStarted = true;
                     }

                     for (int i = 0; i < long_note.Length; i++)
                     {
                         long_note[i].hasStarted = true;
                     }

                     for (int i = 0; i < long_note_fin.Length; i++)
                     {
                         long_note_fin[i].hasStarted = true;
                     }

                     StartPlaying = true;
                     //재생 시작을 true로 

                     Music_0.Play();
                     //버튼을 누를 때 재생 중인 음악을 쌓아


                 }


             }
         }*/

        //if (StartPlaying == true)
        //{
            //여기부터 콤보 이펙트 관련
            // 특정 이름을 가진 오브젝트들을 모두 찾기
            //GameObject[] objects = GameObject.FindGameObjectsWithTag("Combo_Effect");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제

            //0번 레인 롱 노트
            GameObject[] objects0 = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");

            if (objects0.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList0 = new List<GameObject>(objects0);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList0.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList0.Count - 1; i++)
                {
                    Destroy(objectList0[i]);
                }
            }

            //1번 레인 롱 노트
            GameObject[] objects1 = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");

            if (objects1.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList1 = new List<GameObject>(objects1);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList1.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList1.Count - 1; i++)
                {
                    Destroy(objectList1[i]);
                }
            }

            //2번 레인 롱 노트
            GameObject[] objects2 = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");

            if (objects2.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList2 = new List<GameObject>(objects2);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList2.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList2.Count - 1; i++)
                {
                    Destroy(objectList2[i]);
                }
            }

            //3번 레인 롱 노트
            GameObject[] objects3 = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");

            if (objects3.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList3 = new List<GameObject>(objects3);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList3.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList3.Count - 1; i++)
                {
                    Destroy(objectList3[i]);
                }
            }


            //4번 레인 롱 노트
            GameObject[] objects4 = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");

            if (objects4.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList4 = new List<GameObject>(objects4);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList4.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList4.Count - 1; i++)
                {
                    Destroy(objectList4[i]);
                }
            }

            //5번 레인 롱 노트
            GameObject[] objects5 = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");

            if (objects5.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList5 = new List<GameObject>(objects5);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList5.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList5.Count - 1; i++)
                {
                    Destroy(objectList5[i]);
                }
                // Debug.Log("콤보 이펙트 하나빼고 다 지웠다.");
            }



            //여기 아래엔 지우지 마
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Combo_Effect");

            if (objects.Length >= 2)
            {
                // 배열을 리스트로 변환
                List<GameObject> objectList = new List<GameObject>(objects);

                // 오브젝트들을 생성된 순서대로 정렬
                objectList.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // 마지막 오브젝트(가장 나중에 생성된)를 제외하고 나머지 삭제
                for (int i = 0; i < objectList.Count - 1; i++)
                {
                    Destroy(objectList[i]);
                }
                // Debug.Log("콤보 이펙트 하나빼고 다 지웠다.");
            }

            if (objects.Length == 1)
            {
                // Debug.Log("이펙트0 하나만.");
            }


            //여기부터 노트 눌렀을 때 나오는 이펙트 관련
            // 특정 이름을 가진 오브젝트들을 모두 찾기
            GameObject[] Note_Effect_0 = GameObject.FindGameObjectsWithTag("Note_Effect0");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_0.Length >= 2)
            {
                // 첫 번째 오브젝트를 삭제
                for (int i = 1; i < Note_Effect_0.Length; i++)
                {
                    Destroy(Note_Effect_0[i]);
                }
                // Debug.Log("후 하나빼고 다 지웠다.");
            }

            if (Note_Effect_0.Length == 1)
            {
                // Debug.Log("이펙트0 하나만.");
            }

            GameObject[] Note_Effect_1 = GameObject.FindGameObjectsWithTag("Note_Effect1");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_1.Length == 2)
            {
                // 첫 번째 오브젝트를 삭제
                Destroy(Note_Effect_1[0]);
                // Debug.Log("이펙트1 2개였던 거 하나 지웠음.");
            }

            if (Note_Effect_1.Length == 1)
            {
                // Debug.Log("이펙트1 하나만.");
            }

            GameObject[] Note_Effect_2 = GameObject.FindGameObjectsWithTag("Note_Effect2");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_2.Length == 2)
            {
                // 첫 번째 오브젝트를 삭제
                Destroy(Note_Effect_2[0]);
                // Debug.Log("이펙트2 2개였던 거 하나 지웠음.");
            }

            if (objects.Length == 1)
            {
                // Debug.Log("이펙트2 하나만.");
            }

            GameObject[] Note_Effect_3 = GameObject.FindGameObjectsWithTag("Note_Effect3");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_3.Length == 2)
            {
                // 첫 번째 오브젝트를 삭제
                Destroy(Note_Effect_3[0]);
                //Debug.Log("이펙트3 2개였던 거 하나 지웠음.");
            }

            if (Note_Effect_3.Length == 1)
            {
                // Debug.Log("이펙트3 하나만.");
            }

            GameObject[] Note_Effect_4 = GameObject.FindGameObjectsWithTag("Note_Effect4");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_4.Length == 2)
            {
                // 첫 번째 오브젝트를 삭제
                Destroy(Note_Effect_4[0]);
                //Debug.Log("이펙트4 2개였던 거 하나 지웠음.");
            }

            if (Note_Effect_4.Length == 1)
            {
                //Debug.Log("이펙트4 하나만.");
            }

            GameObject[] Note_Effect_5 = GameObject.FindGameObjectsWithTag("Note_Effect5");

            // 해당 오브젝트가 2개 이상 있을 때, 하나만 삭제
            if (Note_Effect_5.Length == 2)
            {
                // 첫 번째 오브젝트를 삭제
                Destroy(Note_Effect_5[0]);
                // Debug.Log("이펙트5 2개였던 거 하나 지웠음.");
            }

            if (Note_Effect_5.Length == 1)
            {
                // Debug.Log("이펙트5 하나만.");
            }


        //}



        //음악이 재생되기 시작했기 때문에 재생 중인 음악이 아닌지 확인할 수 있고
        //음악이 더 이상 재생되지 않는다면, 이는 노래가 끝났음에 틀림없다는 의미
        //화면을 활성화한다.
        //음악이 재생되지 않고 방금 생성한 결과 화면이 계층 구조에서 활성화된 경우, 이를 추가할 것
        //계층구조에서 결과 화면이 활성화되어있는지 말하고 싶다.
        //if (!Music_0.isPlaying && Good_Hits + Miss_Hits + Long_Note_Miss == 373)
        //{
        //  StartPlaying = false;//노래도 끝나고 모든 노트가 다 나오면 StartPlaying을 false로
        //이거 때문에 결과창이 안 떴음
        //}

        //음악이 재생되기 시작했기 때문에 재생 중인 음악이 아닌지 확인할 수 있고
        //음악이 더 이상 재생되지 않는다면, 이는 노래가 끝났음에 틀림없다는 의미
        //화면을 활성화한다.
        //음악이 재생되지 않고 방금 생성한 결과 화면이 계층 구조에서 활성화된 경우, 이를 추가할 것
        //계층구조에서 결과 화면이 활성화되어있는지 말하고 싶다.
        /*if (!Music_0.isPlaying && Result_Panel.activeSelf == false && Good_Hits + Perfect_Hits + Miss_Hits + Long_Note_Miss == 373)
        {
            Show_Result();
        }*/
        if (!Music_0.isPlaying && Result_Panel.activeSelf == false && Good_Hits + Perfect_Hits + Miss_Hits + Long_Note_Miss == 373 &&!hasShownResult)
        {
            Show_Result();
            hasShownResult = true; // 조건이 실행되었음을 기록
        }


        //-> 마지막 노트가 콜라이더를 지나가고 몇 초 후에 결과 화면이 괜찮아보임 
    }

    public void Show_Result()
    {
        // 결과 보여줘
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Show_Re());
    }

    IEnumerator Show_Re()
    {
        yield return new WaitForSeconds(1.4f);
        Result_Panel.SetActive(true);

        // 점수 출력
        Total_ScoreText.text = currentScore.ToString("F2") + "%";

        StartCoroutine(Show_Re1());
    }

    IEnumerator Show_Re1()
    {
        yield return new WaitForSeconds(0.0f);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        BGM_Manager.instance.BGM_Audio[28].Play();
    }

    /*public void Show_Result()
    {
        //결과 보여줘
        //결과 창을 보여주자

        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Show_Re());
        

        IEnumerator Show_Re()
        {
            yield return new WaitForSeconds(1.4f);
            Result_Panel.SetActive(true);

            //지금까지의 점수를 보여주고
            Total_ScoreText.text = currentScore.ToString("F2") + "%";

            //총 몇 번 차밍이 되었는지 보여주자
            //Total_Charming_Text.text = "Charming: " + Total_Charming_Count.ToString();
            StartCoroutine(Show_Re1());
        }

        IEnumerator Show_Re1()
        {
            yield return new WaitForSeconds(1.4f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            BGM_Manager.instance.BGM_Audio[28].Play();
        }

    }*/

    public void Note_Hit()
    {


        Combo_Count++;//multiplierTracker


        //이해했음!
        // multiplierThresholds의 [0]에 있는 숫자만큼 히트하면 
        //점수가 2배로 올라감
        //그 다음3배, 4배... 이렇게 되는 듯?


        /* if (currentMultipiler -1 < multiplierThresholds.Length)
         {
             //현재 승수 -1이 승수 임계값 길이보다 작은지 


             multiplierTracker++;
             //Basie가 승수 추적기에 1을 추가
             //즉 multiplierTracker++
             //다음, 승수 추적기가 임계값 중 하나를 통과했는지 확인

             /*if (multiplierThresholds[currentMultipiler - 1] <= multiplierTracker)
             {
                 //승수 임계값 배열에서 선택한 임계값인지 확인하고 싶은 위치가
                 //현재 승수에서 1을 뺀 값인지 확인하는 것
                 //따라서 위치 0부터 살펴보고 이를 확인하고 체크함.
                 //이것이 현재 승수 추적기가 무엇이든 그보다 작거나 같으면
                 //승수 추적기가 4라는 것을 안다면 다중 추적기가 트리에 잘 있으면
                 //이 중 아무 일도 일어나지 않을 것

                 multiplierTracker = 0;
                 //그 이상이지만 추적기가 4에 도달하면
                 //그 시점에서 괜찮을 것.
                 //먼저 추적기를 다시 0으로 설정하여 0이 되고
                 currentMultipiler++;
                 //현재 승수에 1을 추가하므로
                 //현재 승수++하나가 추가된다.
                 //이상한 일이 발생하지 않도록 여기서 확인이 필요
                 //
             }

             //내가 승수할 수 없다면 안녕이라고 말하는 것
             //즉 우리가 얻을 수 있는 최대값은 트리이므로 승수는 1을 빼서 트리다.
             //long이 임계값 길이보다 작으면 보물?? 길이는 트리이므로 
             //이 시점에서 우리는 승수 트리가 확실히 이 트리보다 작지 않다고 말할 것
             //따라서 이 경우에는 이 작업
             /* multiplierTracker++;
              * if (multiplierThresholds[currentMultipiler - 1] <= multiplierTracker)
             {
                  multiplierTracker = 0;
             }*/
        //을 수행하지 않는다.
        //더 이상 승수를 보고 있지 않으며 이상한 일은 일어나지 않을 것
        //배열 인덱스 오류가 발생하지 않을 것이므로 
        //이를 염두에 두고 승수를 업데이트하고 있으며 모든 것이 완벽하게 작동함
        //}


        // multiText.text = currentMultipiler.ToString(); //일단 콤보 점수 추가는 하지 않는 걸로 
        //승수를 얻을 때 이미 설정한 다중 텍스트를 말할 것이다.




        //음표를 쳤을 때 승수가 1을 더하기 시작해야 한다고 말하고 그 방법은 승수 추적기를 사용

        //점수에 승수를 곱함(??)
        //currentScore += scorePerNote * currentMultipiler;


        //점수
        // currentScore += scorePerNote;

        //만약 콤보 카운트가 2보다 크다면
        //콤보 텍스크가 활성화되고, 동시에 애니메이션도 활성화하는 걸로
        if (Combo_Count > 1)//1
        {
            Combo_obj.SetActive(true);
            Charming_obj.SetActive(true);

            Charming_anim.SetTrigger("Empty");
            Combo_anim.SetTrigger("Up");

            //Perfect_Combo_Effect.SetActive(true);


        }

        if (Combo_Count < 1)//2
        {
            Combo_obj.SetActive(false);
            Charming_obj.SetActive(false);

            Perfect_Combo_Effect.SetActive(false);
            Normal_Combo_Effect.SetActive(false);
        }
        ScoreText.text = currentScore.ToString("F2") + "%";//소수점 두 자릿 수까지 출력


        //Debug.Log(currentMultipiler);
    }


    /*public void Normal_Hit()
    {
        Debug.Log("Good note:" + good_Hits);

        currentScore += scorePerNote * currentMultipiler;//음표당 점수를 추가하여 하나가 정확히 같도록
        Note_Hit();
        //현재 점수에 더하기

        //히트 중 하나를 얻을 때마다 히트 추가
        //good_Hits++;
    }*/

    public void Good_Hit()
    {

        //Debug.Log("Good note:" + good_Hits);

        currentScore += scorePerGoodNote; //* currentMultipiler;

        //전체 스코어 계산

        Note_Hit();
        Combo_Text.text = Combo_Count.ToString();//콤보 텍스트 출력 //multiplierTracker

        for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            //Debug.Log("리셋0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            // Debug.Log("리셋1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            // Debug.Log("리셋2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            // Debug.Log("리셋3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            //Debug.Log("리셋4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("리셋5");
        }

        //히트 중 하나를 얻을 때마다 히트 추가
        //good_Hits++;

    }

    public void Perfect_Hit()
    {
        //Debug.Log("Perfect note:" + perfect_Hits);

        currentScore += scorePerPerfectNote; //* currentMultipiler;
                                             //전체 스코어 계산

        Note_Hit();
        Combo_Text.text = Combo_Count.ToString();//콤보 텍스트 출력

        for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            // Debug.Log("리셋0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            //Debug.Log("리셋1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            //Debug.Log("리셋2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            //Debug.Log("리셋3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            //Debug.Log("리셋4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("리셋5");
        }

        //히트 중 하나를 얻을 때마다 히트 추가
        //perfect_Hits++;
    }

    public void Note_Missed()
    {
        //Debug.Log("놓쳤어?");


        //currentMultipiler = 1;
        Combo_Count = 0;//승수 추적기는 0  //multiplierTracker
        //놓친 경우 승수를 재설정
        //즉, 콤보 나오다가 미스 나오면 다시 콤보를 원상태로 돌린다는 거임

        // multiText.text = currentMultipiler.ToString();//연속 보너스는 없애도록
        //승수 테스트 업데이트(콤보 수 업데이트라고 생각하기)

        //미스 얻을 때마다 미스 추가
        //miss_Hits++;

        Combo_Text.text = Combo_Count.ToString();//콤보 텍스트 출력  //multiplierTracker

        Combo_obj.SetActive(false);//콤보 오브젝트 비활성
        Charming_obj.SetActive(false);//차밍 오브젝트 비활성

        //Effect_Object.instance.Destroy_obj();


        /*for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            //Debug.Log("리셋0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            //Debug.Log("리셋1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            // Debug.Log("리셋2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            // Debug.Log("리셋3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            // Debug.Log("리셋4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("리셋5");
        }*/
    }


    
}
