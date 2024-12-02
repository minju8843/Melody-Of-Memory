using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Long_Note : MonoBehaviour
{
    public Note_1105 note_1105;

    public Manager_0 manager;

    public static Long_Note instance;
    public Long_Col[] long_col;

   // public GameObject hit_5_1;


    public float beatTempo;//노트가 얼마나 빨리 떨어지는지//Beat_Scroller에서 가져옴
    public bool hasStarted;//시작됐는지

    public RectTransform rect; // 오브젝트의 RectTransform
    public BoxCollider2D[] long_note_col;

    public bool canBePressed;

    public bool Button_0_Pressed = false;
    public bool Button_1_Pressed = false;
    public bool Button_2_Pressed = false;
    public bool Button_3_Pressed = false;
    public bool Button_4_Pressed = false;
    public bool Button_5_Pressed = false;

    public int no_hit_0 = 0;
    public int no_hit_1 = 0;
    public int no_hit_2 = 0;
    public int no_hit_3 = 0;
    public int no_hit_4 = 0;
    public int no_hit_5 = 0;

    //0레인
    /*public int no_hit_0_0 = 0;
    public int no_hit_0_1 = 0;

    //1레인
    public int no_hit_1_0 = 0;

    //2레인
    public int no_hit_2_0 = 0;

    //3레인
    public int no_hit_3_0 = 0;

    //4레인
    //public bool long_note_4_0 = false;
    public int no_hit_4_0 = 0;
    public int no_hit_4_1 = 0;//5번째 라인의 0번째 롱 노트
    */

    //5레인
    // public bool long_note_5_0 = false;//5번째 라인의 0번째 롱 노트
    //public int no_hit_5_0 = 0;//5번째 라인의 0번째 롱 노트
    //public int no_hit_5_1 = 0;

    //private bool isInputReleased = false;

    public List<GameObject> buttons; // 버튼들을 저장하는 리스트
   // public bool[] buttonTouched = new bool[6];

    //public bool[] isButtonTouchedOnce = new bool[6]; // 터치가 한 번이라도 이루어졌는지 여부

    public void ResetTouch_Count_0()//횟수 리셋 
    {
        no_hit_0 = 0;
    }

    public void ResetTouch_Count_1()
    {
        no_hit_1 = 0;
    }

    public void ResetTouch_Count_2()
    {
        no_hit_2 = 0;
    }

    public void ResetTouch_Count_3()
    {
        no_hit_3 = 0;
    }

    public void ResetTouch_Count_4()
    {
        no_hit_4 = 0;
    }

    public void ResetTouch_Count_5()
    {
        no_hit_5 = 0;
    }

   /* public void ResetTouchStatus_0()//터치 리셋
    {
        isButtonTouchedOnce[0] = false;
    }

    public void ResetTouchStatus_1()//터치 리셋
    {
        isButtonTouchedOnce[1] = false;
    }

    public void ResetTouchStatus_2()//터치 리셋
    {
        isButtonTouchedOnce[2] = false;
    }

    public void ResetTouchStatus_3()//터치 리셋
    {
        isButtonTouchedOnce[3] = false;
    }

    public void ResetTouchStatus_4()//터치 리셋
    {
        isButtonTouchedOnce[4] = false;
    }

    public void ResetTouchStatus_5()//터치 리셋
    {
        isButtonTouchedOnce[5] = false;
    }
   */
    void Start()
    {
        ResetTouch_Count_0();
        ResetTouch_Count_1();
        ResetTouch_Count_2();
        ResetTouch_Count_3();
        ResetTouch_Count_4();
        ResetTouch_Count_5();

        /*ResetTouchStatus_0();
        ResetTouchStatus_1();
        ResetTouchStatus_2();
        ResetTouchStatus_3();
        ResetTouchStatus_4();
        ResetTouchStatus_5();
       */
        instance = this;

        rect = GetComponent<RectTransform>();
        beatTempo = beatTempo / 2f;

    }


    public void Update()
    {
        //CheckTouchInput(); // 터치 상태 먼저 업데이트
        //HandleOtherLogic(); // 다른 게임 로직 처리

        if (Winter_Music.instance.Pause.activeSelf == true || Winter_Music.instance.keep_speed == false)
        {
            rect.anchoredPosition -= new Vector2(0f, 0.0f * Time.deltaTime);
            // Debug.Log("아직 롱노트 흰색 미스 아님");
        }

        if (Winter_Music.instance.Pause.activeSelf == false && Winter_Music.instance.keep_speed == true)
        {
            rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
            
        }



        //0-0
        if (gameObject.name == "Long_Note0_0")// && Manager_0.instance.Nor_Note_Log_rect[0].anchoredPosition.y < -18.0f)
        {

            if (canBePressed == true)
            {
                //(rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y >= -18.0f )
                //-> 일반 노트가 퍼펙트나 굿 노트에 있는 사이에 
               /* if ((Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[1].activeSelf == true || Manager_0.instance.Nor_Note_Log[1].activeSelf == false ))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {
                        
                        Debug.Log("0-0 누르고 있군여");
                        no_hit_0 = 0;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[1].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[1].activeSelf == false && long_col[6].fin_col.enabled == true && long_note_col[1].enabled == true))
                {
                    //처음은 굿인데 그 다음에 뗀 경우
                    //버튼을 안 눌렀을 경우
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[1].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y < -18.0f && long_col[1].fin_col.enabled == true && long_note_col[1].enabled == true)
                {
                    //버튼을 안 눌렀을 경우
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[1].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }



            }


        }

        //0-1
        if (gameObject.name == "Long_Note0_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[4].activeSelf == true || Manager_0.instance.Nor_Note_Log[4].activeSelf == false))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {

                        Debug.Log("0-1 누르고 있군여");
                        no_hit_0 = 0;
                        long_col[4].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[4].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[4].activeSelf == false && long_col[4].fin_col.enabled == true && long_note_col[4].enabled == true))
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y < -18.0f && long_col[4].fin_col.enabled == true && long_note_col[4].enabled == true)
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //0-2
        if (gameObject.name == "Long_Note0_2")
        {
            if (canBePressed == true)
            {
               /* if((Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[15].activeSelf == true || Manager_0.instance.Nor_Note_Log[15].activeSelf == false))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {

                        Debug.Log("0-2 누르고 있군여");
                        no_hit_0 = 0;
                        long_col[15].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[15].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[15].activeSelf == false && long_col[15].fin_col.enabled == true && long_note_col[15].enabled == true))
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y < -18.0f && long_col[15].fin_col.enabled == true && long_note_col[15].enabled == true)
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }


        //1-0
        if (gameObject.name == "Long_Note1_0")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[6].activeSelf == true || Manager_0.instance.Nor_Note_Log[6].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-0 누르고 있군여");
                        no_hit_1 = 0;
                        long_col[6].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[6].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }
               */
                if ((Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[6].activeSelf == false && long_col[6].fin_col.enabled == true && long_note_col[6].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y < -18.0f && long_col[6].fin_col.enabled == true && long_note_col[6].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //1-1
        if (gameObject.name == "Long_Note1_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[8].activeSelf == true || Manager_0.instance.Nor_Note_Log[8].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-1 누르고 있군여");
                        no_hit_1 = 0;
                        long_col[8].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[8].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[8].activeSelf == false && long_col[8].fin_col.enabled == true && long_note_col[8].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y < -18.0f && long_col[8].fin_col.enabled == true && long_note_col[8].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }


        //1-2
        if (gameObject.name == "Long_Note1_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[10].activeSelf == true || Manager_0.instance.Nor_Note_Log[10].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-2 누르고 있군여");
                        no_hit_1 = 0;
                        long_col[10].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[10].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[10].activeSelf == false && long_col[10].fin_col.enabled == true && long_note_col[10].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y < -18.0f && long_col[10].fin_col.enabled == true && long_note_col[10].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //1-3
        if (gameObject.name == "Long_Note1_3")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[24].activeSelf == true || Manager_0.instance.Nor_Note_Log[24].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-3 누르고 있군여");
                        no_hit_1 = 0;
                        long_col[24].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[24].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }
                */
                if ((Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[24].activeSelf == false && long_col[24].fin_col.enabled == true && long_note_col[24].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-3을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y < -18.0f && long_col[24].fin_col.enabled == true && long_note_col[24].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-3을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //1-4
        if (gameObject.name == "Long_Note1_4")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[31].activeSelf == true || Manager_0.instance.Nor_Note_Log[31].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-4 누르고 있군여");
                        no_hit_1 = 0;
                        long_col[31].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[31].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[31].activeSelf == false && long_col[31].fin_col.enabled == true && long_note_col[31].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-4을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y < -18.0f && long_col[31].fin_col.enabled == true && long_note_col[31].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-4을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-0
        if (gameObject.name == "Long_Note2_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[5].activeSelf == true || Manager_0.instance.Nor_Note_Log[5].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-0 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[5].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[5].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[5].activeSelf == false && long_col[5].fin_col.enabled == true && long_note_col[5].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y < -18.0f && long_col[5].fin_col.enabled == true && long_note_col[5].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-1
        if (gameObject.name == "Long_Note2_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[20].activeSelf == true || Manager_0.instance.Nor_Note_Log[20].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-1 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[20].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[20].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[20].activeSelf == false && long_col[20].fin_col.enabled == true && long_note_col[20].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y < -18.0f && long_col[20].fin_col.enabled == true && long_note_col[20].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-2
        if (gameObject.name == "Long_Note2_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[12].activeSelf == true || Manager_0.instance.Nor_Note_Log[12].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-2 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[12].activeSelf == false && long_col[12].fin_col.enabled == true && long_note_col[12].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y < -18.0f && long_col[12].fin_col.enabled == true && long_note_col[12].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-3
        if (gameObject.name == "Long_Note2_3")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[25].activeSelf == true || Manager_0.instance.Nor_Note_Log[25].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-3 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[25].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[25].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[25].activeSelf == false && long_col[25].fin_col.enabled == true && long_note_col[25].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-3을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y < -18.0f && long_col[25].fin_col.enabled == true && long_note_col[25].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-3을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-4
        if(gameObject.name == "Long_Note2_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[26].activeSelf == true || Manager_0.instance.Nor_Note_Log[26].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-4 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[26].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[26].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[26].activeSelf == false && long_col[26].fin_col.enabled == true && long_note_col[26].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-4을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y < -18.0f && long_col[26].fin_col.enabled == true && long_note_col[26].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-4을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-5
        if (gameObject.name == "Long_Note2_5")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[33].activeSelf == true || Manager_0.instance.Nor_Note_Log[33].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-5 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[33].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[33].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[33].activeSelf == false && long_col[33].fin_col.enabled == true && long_note_col[33].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-5을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y < -18.0f && long_col[33].fin_col.enabled == true && long_note_col[33].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-5을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //2-6
        if (gameObject.name == "Long_Note2_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[34].activeSelf == true || Manager_0.instance.Nor_Note_Log[34].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-6 누르고 있군여");
                        no_hit_2 = 0;
                        long_col[34].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[34].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[34].activeSelf == false && long_col[34].fin_col.enabled == true && long_note_col[34].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-6을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y < -18.0f && long_col[34].fin_col.enabled == true && long_note_col[34].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-6을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-0
        if (gameObject.name == "Long_Note3_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[7].activeSelf == true || Manager_0.instance.Nor_Note_Log[7].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-0 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[7].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[7].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[7].activeSelf == false && long_col[7].fin_col.enabled == true && long_note_col[7].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y < -18.0f && long_col[7].fin_col.enabled == true && long_note_col[7].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-1
        if (gameObject.name == "Long_Note3_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[9].activeSelf == true || Manager_0.instance.Nor_Note_Log[9].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-1 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[9].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[9].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[9].activeSelf == false && long_col[9].fin_col.enabled == true && long_note_col[9].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y < -18.0f && long_col[9].fin_col.enabled == true && long_note_col[9].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-2
        if (gameObject.name == "Long_Note3_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[11].activeSelf == true || Manager_0.instance.Nor_Note_Log[11].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-2 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[11].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[11].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[11].activeSelf == false && long_col[11].fin_col.enabled == true && long_note_col[11].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y < -18.0f && long_col[11].fin_col.enabled == true && long_note_col[11].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-3
        if (gameObject.name == "Long_Note3_3")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[13].activeSelf == true || Manager_0.instance.Nor_Note_Log[13].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-3 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[13].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[13].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[13].activeSelf == false && long_col[13].fin_col.enabled == true && long_note_col[13].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-3을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y < -18.0f && long_col[13].fin_col.enabled == true && long_note_col[13].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-3을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-4
        if (gameObject.name == "Long_Note3_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[19].activeSelf == true || Manager_0.instance.Nor_Note_Log[19].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-4 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[19].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[19].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[19].activeSelf == false && long_col[19].fin_col.enabled == true && long_note_col[19].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-4을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y < -18.0f && long_col[19].fin_col.enabled == true && long_note_col[19].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-4을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-5
        if (gameObject.name == "Long_Note3_5")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[27].activeSelf == true || Manager_0.instance.Nor_Note_Log[27].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-5 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[27].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[27].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[27].activeSelf == false && long_col[27].fin_col.enabled == true && long_note_col[27].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-5을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y < -18.0f && long_col[27].fin_col.enabled == true && long_note_col[27].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-5을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //3-6
        if (gameObject.name == "Long_Note3_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[36].activeSelf == true || Manager_0.instance.Nor_Note_Log[36].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-6 누르고 있군여");
                        no_hit_3 = 0;
                        long_col[36].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[36].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[36].activeSelf == false && long_col[36].fin_col.enabled == true && long_note_col[36].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-6을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y < -18.0f && long_col[36].fin_col.enabled == true && long_note_col[36].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-6을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-0
        if (gameObject.name == "Long_Note4_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[2].activeSelf == true || Manager_0.instance.Nor_Note_Log[2].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-0 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[2].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[2].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[2].activeSelf == false && long_col[2].fin_col.enabled == true && long_note_col[2].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y < -18.0f && long_col[2].fin_col.enabled == true && long_note_col[2].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-1
        if (gameObject.name == "Long_Note4_1")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[3].activeSelf == true || Manager_0.instance.Nor_Note_Log[3].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-1 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[3].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[3].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[3].activeSelf == false && long_col[3].fin_col.enabled == true && long_note_col[3].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y < -18.0f && long_col[3].fin_col.enabled == true && long_note_col[3].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-2
        if (gameObject.name == "Long_Note4_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[16].activeSelf == true || Manager_0.instance.Nor_Note_Log[16].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-2 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[16].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[16].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[16].activeSelf == false && long_col[16].fin_col.enabled == true && long_note_col[16].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y < -18.0f && long_col[16].fin_col.enabled == true && long_note_col[16].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-3
        if (gameObject.name == "Long_Note4_3")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[17].activeSelf == true || Manager_0.instance.Nor_Note_Log[17].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-3 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[17].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[17].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[17].activeSelf == false && long_col[17].fin_col.enabled == true && long_note_col[17].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-3을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y < -18.0f && long_col[17].fin_col.enabled == true && long_note_col[17].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-3을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-4
        if (gameObject.name == "Long_Note4_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[18].activeSelf == true || Manager_0.instance.Nor_Note_Log[18].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-4 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[18].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[18].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[18].activeSelf == false && long_col[18].fin_col.enabled == true && long_note_col[18].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-4을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y < -18.0f && long_col[18].fin_col.enabled == true && long_note_col[18].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-4을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-5
        if (gameObject.name == "Long_Note4_5")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[21].activeSelf == true || Manager_0.instance.Nor_Note_Log[21].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-5 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[21].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[21].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[21].activeSelf == false && long_col[21].fin_col.enabled == true && long_note_col[21].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-5을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y < -18.0f && long_col[21].fin_col.enabled == true && long_note_col[21].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-5을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-6
        if (gameObject.name == "Long_Note4_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[22].activeSelf == true || Manager_0.instance.Nor_Note_Log[22].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-6 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[22].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[22].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[22].activeSelf == false && long_col[22].fin_col.enabled == true && long_note_col[22].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-6을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y < -18.0f && long_col[22].fin_col.enabled == true && long_note_col[22].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-6을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-7
        if (gameObject.name == "Long_Note4_7")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[23].activeSelf == true || Manager_0.instance.Nor_Note_Log[23].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-7 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[23].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[23].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[23].activeSelf == false && long_col[23].fin_col.enabled == true && long_note_col[23].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-7을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y < -18.0f && long_col[23].fin_col.enabled == true && long_note_col[23].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-7을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-8
        if (gameObject.name == "Long_Note4_8")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[28].activeSelf == true || Manager_0.instance.Nor_Note_Log[28].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-8 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[28].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[28].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[28].activeSelf == false && long_col[28].fin_col.enabled == true && long_note_col[28].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-8을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y < -18.0f && long_col[28].fin_col.enabled == true && long_note_col[28].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-8을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-9
        if (gameObject.name == "Long_Note4_9")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[29].activeSelf == true || Manager_0.instance.Nor_Note_Log[29].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-9 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[29].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[29].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[29].activeSelf == false && long_col[29].fin_col.enabled == true && long_note_col[29].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-9을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y < -18.0f && long_col[29].fin_col.enabled == true && long_note_col[29].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-9을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-10
        if (gameObject.name == "Long_Note4_10")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[30].activeSelf == true || Manager_0.instance.Nor_Note_Log[30].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-10 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[30].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[30].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[30].activeSelf == false && long_col[30].fin_col.enabled == true && long_note_col[30].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-10을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y < -18.0f && long_col[30].fin_col.enabled == true && long_note_col[30].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-10을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-11
        if (gameObject.name == "Long_Note4_11")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[32].activeSelf == true || Manager_0.instance.Nor_Note_Log[32].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-11 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[32].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[32].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[32].activeSelf == false && long_col[32].fin_col.enabled == true && long_note_col[32].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-11을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y < -18.0f && long_col[32].fin_col.enabled == true && long_note_col[32].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-11을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-12
        if(gameObject.name == "Long_Note4_12")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[35].activeSelf == true || Manager_0.instance.Nor_Note_Log[35].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-12 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[35].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[35].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[35].activeSelf == false && long_col[35].fin_col.enabled == true && long_note_col[35].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-12을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y < -18.0f && long_col[35].fin_col.enabled == true && long_note_col[35].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-12을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //4-13
        if (gameObject.name == "Long_Note4_13")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[38].activeSelf == true || Manager_0.instance.Nor_Note_Log[38].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-13 누르고 있군여");
                        no_hit_4 = 0;
                        long_col[38].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[38].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[38].activeSelf == false && long_col[38].fin_col.enabled == true && long_note_col[38].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-13을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y < -18.0f && long_col[38].fin_col.enabled == true && long_note_col[38].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-13을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //5-0
        if (gameObject.name == "Long_Note5_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[0].activeSelf == true || Manager_0.instance.Nor_Note_Log[0].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-0 누르고 있군여");
                        no_hit_5 = 0;
                        long_col[0].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[0].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[0].activeSelf == false && long_col[0].fin_col.enabled == true && long_note_col[0].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-0을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y < -18.0f && long_col[0].fin_col.enabled == true && long_note_col[0].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-0을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //5-1
        if (gameObject.name == "Long_Note5_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[14].activeSelf == true || Manager_0.instance.Nor_Note_Log[14].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-1 누르고 있군여");
                        no_hit_5 = 0;
                        long_col[14].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[14].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[14].activeSelf == false && long_col[14].fin_col.enabled == true && long_note_col[14].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-1을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y < -18.0f && long_col[14].fin_col.enabled == true && long_note_col[14].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-1을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }

        //5-2
        if (gameObject.name == "Long_Note5_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[37].activeSelf == true || Manager_0.instance.Nor_Note_Log[37].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-2 누르고 있군여");
                        no_hit_5 = 0;
                        long_col[37].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[37].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[37].activeSelf == false && long_col[37].fin_col.enabled == true && long_note_col[37].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-2을 굿이었는데 중간에 뗐음 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

                if (Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y < -18.0f && long_col[37].fin_col.enabled == true && long_note_col[37].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-2을 처음부터 안 누름 + 롱 노트 미스 1 추가");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                        long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    }
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //트리거 시 무효화gkrh 2d를 입력하고 여기에서 서로 충돌을 변경

        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = true;
            // Debug.Log("롱 노트 흰색 지나가유");







            //0-1
            /*if (gameObject.name == "Long_Note0_1" && Button_0_Pressed == true)
            {
                if (no_hit_0 == 0 && buttonTouched[0] == true)
                {
                    no_hit_0 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[4].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[4].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_0 == 0 && buttonTouched[0] == false)
                {
                    no_hit_0 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_0 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_0 = 1;
                    long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("0-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note0_1" && Button_0_Pressed == false && no_hit_0 > 0)
            {
                no_hit_0 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note0_1" && buttonTouched[0] == false)
            {
                no_hit_0 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[4].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[4].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //0-2
            if (gameObject.name == "Long_Note0_2" && Button_0_Pressed == true)
            {
                if (no_hit_0 == 0 && buttonTouched[0] == true)
                {
                    no_hit_0 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[15].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[15].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");



                }

                if (no_hit_0 == 0 && buttonTouched[0] == false)
                {
                    no_hit_0 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_0 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_0 = 1;
                    long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("0-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note0_2" && Button_0_Pressed == false && no_hit_0 > 0)
            {
                no_hit_0 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note0_2" && buttonTouched[0] == false)
            {
                no_hit_0 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[15].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[15].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-0
            if (gameObject.name == "Long_Note1_0" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[6].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[6].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");



                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("1-0롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_0" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_0" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[6].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[6].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-1
            if (gameObject.name == "Long_Note1_1" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[8].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[8].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("1-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_1" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_1" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[8].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[8].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-2
            if (gameObject.name == "Long_Note1_2" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[10].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[10].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("1-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_2" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_2" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[10].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[10].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-3
            if (gameObject.name == "Long_Note1_3" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[24].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[24].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("1-3롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_3" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;




            }

            if (gameObject.name == "Long_Note1_3" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[24].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[24].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-4
            if (gameObject.name == "Long_Note1_4" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[31].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[31].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

       

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("1-4롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_4" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_4" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[31].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[31].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-0
            if (gameObject.name == "Long_Note2_0" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[5].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[5].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-0롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_0" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_0" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[5].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[5].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-1
            if (gameObject.name == "Long_Note2_1" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[20].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[20].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_1" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_1" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[20].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[20].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-2
            if (gameObject.name == "Long_Note2_2" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[12].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[12].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_2" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_2" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[12].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[12].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-3
            if (gameObject.name == "Long_Note2_3" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[25].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[25].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-3롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_3" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_3" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[25].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[25].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-4
            if (gameObject.name == "Long_Note2_4" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[26].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[26].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");



                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-4롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_4" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_4" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[26].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[26].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-5
            if (gameObject.name == "Long_Note2_5" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[33].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[33].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");



                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-5롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_5" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_5" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[33].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[33].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-6
            if (gameObject.name == "Long_Note2_6" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[34].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[34].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("2-6롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_6" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;

            }

            if (gameObject.name == "Long_Note2_6" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[34].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[34].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-0
            if (gameObject.name == "Long_Note3_0" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[7].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[7].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-0롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_0" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_0" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[7].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[7].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-1
            if (gameObject.name == "Long_Note3_1" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[9].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[9].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");



                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_1" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }


                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_1" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[9].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[9].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-2
            if (gameObject.name == "Long_Note3_2" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[11].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[11].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_2" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_2" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[11].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[11].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-3
            if (gameObject.name == "Long_Note3_3" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[13].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[13].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-3롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_3" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;

            }

            if (gameObject.name == "Long_Note3_3" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[13].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[13].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-4
            if (gameObject.name == "Long_Note3_4" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[19].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[19].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-4롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_4" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_4" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[19].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[19].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-5
            if (gameObject.name == "Long_Note3_5" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[27].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[27].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-5롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_5" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_5" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[27].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[27].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-6
            if (gameObject.name == "Long_Note3_6" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[36].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[36].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("3-6롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_6" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_6" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[36].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[36].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //4-0
            if (gameObject.name == "Long_Note4_0" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[2].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[2].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-0롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_0" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;


            }

            if (gameObject.name == "Long_Note4_0" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("0-0롱노트 미스");
                long_col[2].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[2].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //4-1
            if (gameObject.name == "Long_Note4_1" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[3].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[3].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                     // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_1" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_1" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[3].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[3].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            

            //4-2
            if (gameObject.name == "Long_Note4_2" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[16].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[16].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                     // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_2" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_2" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[16].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[16].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-3
            if (gameObject.name == "Long_Note4_3" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[17].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[17].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-3롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_3" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_3" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[17].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[17].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-4
            if (gameObject.name == "Long_Note4_4" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[18].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[18].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-4롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_4" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_4" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[18].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[18].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-5
            if (gameObject.name == "Long_Note4_5" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[21].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[21].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-5롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_5" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_2" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[21].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[21].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-6
            if (gameObject.name == "Long_Note4_6" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[22].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[22].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-6롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_6" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_6" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[22].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[22].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-7
            if (gameObject.name == "Long_Note4_7" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[23].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[23].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-7롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_7" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_7" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[23].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[23].enabled = false; //롱노트 중간 부분의 콜라이더 비활성

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-8
            if (gameObject.name == "Long_Note4_8" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[28].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[28].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-8롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_8" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_8" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[28].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[28].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-9
            if (gameObject.name == "Long_Note4_9" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[29].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[29].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-9롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_9" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_9" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[29].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[29].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-10
            if (gameObject.name == "Long_Note4_10" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[30].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[30].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-10롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_10" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_10" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[30].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[30].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-11
            if (gameObject.name == "Long_Note4_11" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[32].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[32].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-11롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_11" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_11" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[32].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[32].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-12
            if (gameObject.name == "Long_Note4_12" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[35].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[35].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-12롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_12" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_12" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[35].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[35].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-13
            if (gameObject.name == "Long_Note4_13" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[38].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[38].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                                                      // Debug.Log("5-0롱노트 유지");
       

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("4-13롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_13" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_13" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[38].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[38].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //5-0
            if (gameObject.name == "Long_Note5_0" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[0].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[0].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                   // Debug.Log("5-0롱노트 유지");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                   // Long_Col.instance.fin_col.enabled = false;
                    long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-0롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("5-0롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_0" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
               // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_0" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                //Debug.Log("5-0롱노트 미스");
                long_col[0].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[0].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }


            //5-1
            if (gameObject.name == "Long_Note5_1" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[14].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[14].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("5-1롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_1" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_1" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                Debug.Log("5-1롱노트 미스");
                long_col[14].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[14].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }


            //5-2
            if (gameObject.name == "Long_Note5_2" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[37].fin_col.enabled = true;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[37].enabled = true; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 유지");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    //Debug.Log("5-1롱노트 미스요");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                    long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                    Debug.Log("5-2롱노트 미스 Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_2" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0롱노트 미스 용용용");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_2" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                Debug.Log("5-2롱노트 미스");
                long_col[37].fin_col.enabled = false;//롱 노트 마지막 부분의 콜라이더와
                long_note_col[37].enabled = false; //롱노트 중간 부분의 콜라이더 비활성
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//터치 여부를 true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }
        }

        else
        {
            canBePressed = false; // 다른 태그와 충돌 시 초기화
        }*/
        }
    }

   
}
        
