using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Long_Col : MonoBehaviour
{
   // public Note_1105 note_1105;

    public static Long_Col instance;
    public Long_Note long_note;

    public RectTransform rect; // 오브젝트의 RectTransform
    public BoxCollider2D fin_col;

    public float beatTempo;//노트가 얼마나 빨리 떨어지는지//Beat_Scroller에서 가져옴
    public bool hasStarted;//시작됐는지

    public bool canBePressed = false;

    public bool Button_0_Pressed = false;
    public bool Button_1_Pressed = false;
    public bool Button_2_Pressed = false;
    public bool Button_3_Pressed = false;
    public bool Button_4_Pressed = false;
    public bool Button_5_Pressed = false;


    void Start()
    {
        instance = this;
        beatTempo = beatTempo / 2f;

        //col.enabled = true;
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

        }



    }

    void Update()
    {

        if (Winter_Music.instance.Pause.activeSelf == true || Winter_Music.instance.keep_speed == false)
        {
            /*for (int i = 0; i < rect.Length; i++)
            {
                rect[i].anchoredPosition -= new Vector2(0f, 0 * Time.deltaTime);
            }*/
            rect.anchoredPosition -= new Vector2(0f, 0 * Time.deltaTime);
        }

        if (Winter_Music.instance.Pause.activeSelf == false && Winter_Music.instance.keep_speed == true)
        {
            /*for (int i = 0; i < rect.Length; i++)
            {
                rect[i].anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
                Debug.Log("속도 확인" + beatTempo);
            }*/

            rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
        }

       
        

        /*if (canBePressed)//롱노트 끝까지 터치되었을 경우에 히트 추가 //롱 노트 성공했을 경우
        {
            //끝부분 위치 기준으로 작성하기
            if (Button_5_Pressed == true && fin_col[0].enabled == true && Long_Note.instance.long_note_col[0].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)



            {//(Long_Note.instance.long_col[j].enabled == true && Button_5_Pressed == true) -> 원래 코드

                if (Manager_0.instance.Combo_Count >= 1)
                {
                    Debug.Log("퍼펙트요");
                    Manager_0.instance.Perfect_Hit();
                    Manager_0.instance.Perfect_Hits++;

                    Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                    Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                }

                if (Manager_0.instance.Combo_Count == 0)
                {
                    Debug.Log("굿이오");
                    Manager_0.instance.Good_Hit();
                    Manager_0.instance.Good_Hits++;
                    Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                    Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                }

                // Long_Eff_obj.instance.Success_Destroy_obj();
                Note_1105.instance.canBePressed = false;//0822추가

                //해당 태그 있는 이펙트 삭제
                GameObject objectToDelete = GameObject.FindWithTag("Long_Note_Effect5");
                // 오브젝트가 존재하면 삭제
                if (objectToDelete != null)
                {
                    Destroy(objectToDelete);
                }

            }



        }*/
        //원래 주석 없는데, Winter_Music 및 다른 곳에서 제어중
        /*if (hasStarted == true)
        {
            for(int i = 0; i<rect.Length; i++)
            {
                rect[i].anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
            }

            //rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
           // Debug.Log("롱노트 끝부분이 어디냐"+ rect[0].anchoredPosition.y);
        }*/

    

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            //isCollidingWithFinish = true; // "finish" 태그와 충돌 상태

            canBePressed = true;
            Debug.Log("충돌 중");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            canBePressed = false; // "finish" 태그와의 충돌이 끝남
            Debug.Log("충돌 종료");
        }
    }*/
    
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //트리거 시 무효화gkrh 2d를 입력하고 여기에서 서로 충돌을 변경

    //if (other.tag == "Finish")//(other.tag == "Note" )
    //{
    //  canBePressed = true;
    

        //Debug.Log("롱 노트 흰색 끝부분 지나가유");

        if (canBePressed)//롱노트 끝까지 터치되었을 경우에 히트 추가 //롱 노트 성공했을 경우
            {
                //끝부분 위치 기준으로 작성하기
                

                //0-0
                if(Manager_0.instance.Nor_Note_Log[1].activeSelf == false &&
                    Button_0_Pressed == true && Long_Note.instance.long_col[1].fin_col.enabled == true && Long_Note.instance.long_note_col[1].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)



                {//(Long_Note.instance.long_col[j].enabled == true && Button_5_Pressed == true) -> 원래 코드

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("0-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[1].enabled = false;
                        fin_col.enabled = false;


                    //추가1130
                    Long_Note.instance.long_col[1].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[1].enabled = false;
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("0-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[1].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[1].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[1].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 0-0이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_0();
                   // Long_Note.instance.ResetTouchStatus_0();

                }

                //0-1
                if (Manager_0.instance.Nor_Note_Log[4].activeSelf == false &&
                Button_0_Pressed == true && Long_Note.instance.long_col[4].fin_col.enabled == true && Long_Note.instance.long_note_col[4].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("0-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[4].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[4].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[4].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("0-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[4].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[4].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[4].enabled = false;
                }

                    // Long_Eff_obj.instance.Success_Destroy_obj();
                    //Note_1105.instance.canBePressed = false;//0822추가
                    //canBePressed = false;

                    //해당 태그 있는 이펙트 삭제
                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 0-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_0();
                   // Long_Note.instance.ResetTouchStatus_0();
                }

                //0-2
                if (Manager_0.instance.Nor_Note_Log[15].activeSelf == false &&
                Button_0_Pressed == true && Long_Note.instance.long_col[15].fin_col.enabled == true && Long_Note.instance.long_note_col[15].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("0-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[15].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[15].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[15].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("0-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[15].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[15].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[15].enabled = false;
                }


                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 0-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_0();
                    //Long_Note.instance.ResetTouchStatus_0();
                }


                //1-0
                if (Manager_0.instance.Nor_Note_Log[6].activeSelf == false &&
                Button_1_Pressed == true && Long_Note.instance.long_col[6].fin_col.enabled == true && long_note.long_note_col[6].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("1-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[6].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[6].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[6].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("1-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[6].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[6].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[6].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 1-0이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_1();
                    //Long_Note.instance.ResetTouchStatus_1();

                }

                //1-1
                if (Manager_0.instance.Nor_Note_Log[8].activeSelf == false &&
                Button_1_Pressed == true && Long_Note.instance.long_col[8].fin_col.enabled == true && Long_Note.instance.long_note_col[8].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("1-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[8].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[8].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[8].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("1-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[8].enabled = false;
                        fin_col.enabled = false;
                    //추가1130
                    Long_Note.instance.long_col[8].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[8].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 1-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_1();
                    //Long_Note.instance.ResetTouchStatus_1();

                }

                //1-2
                if (Manager_0.instance.Nor_Note_Log[10].activeSelf == false &&
                Button_1_Pressed == true && Long_Note.instance.long_col[10].fin_col.enabled == true && Long_Note.instance.long_note_col[10].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("1-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[10].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[10].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[10].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("1-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[10].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[10].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[10].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 1-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_1();
                    //Long_Note.instance.ResetTouchStatus_1();

                }

                //1-3
                if (Manager_0.instance.Nor_Note_Log[24].activeSelf == false &&
                Button_1_Pressed == true && Long_Note.instance.long_col[24].fin_col.enabled == true && Long_Note.instance.long_note_col[24].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("1-3 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[24].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[24].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[24].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("1-3 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[24].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[24].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[24].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 1-3이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_1();
                    //Long_Note.instance.ResetTouchStatus_1();

                }

                //1-4
                if (Manager_0.instance.Nor_Note_Log[31].activeSelf == false &&
                Button_1_Pressed == true && Long_Note.instance.long_col[31].fin_col.enabled == true && Long_Note.instance.long_note_col[31].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("1-4 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[31].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[31].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[31].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("1-4 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[31].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[31].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[31].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 1-4이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_1();
                    //Long_Note.instance.ResetTouchStatus_1();

                }


                //2-0
                if (Manager_0.instance.Nor_Note_Log[5].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[5].fin_col.enabled == true && Long_Note.instance.long_note_col[5].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[5].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[5].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[5].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[5].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[5].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[5].enabled = false;
                }

                    // Long_Eff_obj.instance.Success_Destroy_obj();
                    //Note_1105.instance.canBePressed = false;//0822추가
                    //canBePressed = false;

                    //해당 태그 있는 이펙트 삭제
                    //GameObject objectToDelete = GameObject.FindWithTag("Long_Note_Effect2");
                    // 오브젝트가 존재하면 삭제
                    /*if (objectToDelete != null)
                    {
                        Destroy(objectToDelete);
                    }*/
                    //Destroy(objectToDelete);
                    //Debug.Log("2-0이펙트 없어지샘");

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-0이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                    //Long_Note.instance.ResetTouchStatus_2();

                }

                //2-1
                if (Manager_0.instance.Nor_Note_Log[20].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[20].fin_col.enabled == true && Long_Note.instance.long_note_col[20].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[20].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[20].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[20].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[20].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[20].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[20].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                    //Long_Note.instance.ResetTouchStatus_2();

                }

                //2-2
                if (Manager_0.instance.Nor_Note_Log[12].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[12].fin_col.enabled == true && Long_Note.instance.long_note_col[12].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[12].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[12].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[12].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[12].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[12].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[12].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                   // Long_Note.instance.ResetTouchStatus_2();

                }

                //2-3
                if (Manager_0.instance.Nor_Note_Log[25].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[25].fin_col.enabled == true && Long_Note.instance.long_note_col[25].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-3 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[25].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[25].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[25].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-3 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[25].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[25].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[25].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-3이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                    //Long_Note.instance.ResetTouchStatus_2();

                }

                //2-4
                if (Manager_0.instance.Nor_Note_Log[26].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[26].fin_col.enabled == true && Long_Note.instance.long_note_col[26].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-4 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[26].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[26].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[26].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-4 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[26].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[26].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[26].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-4이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                   // Long_Note.instance.ResetTouchStatus_2();

                }

                //2-5
                if (Manager_0.instance.Nor_Note_Log[33].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[33].fin_col.enabled == true && Long_Note.instance.long_note_col[33].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       Debug.Log("2-5 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[33].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[33].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[33].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-5 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[33].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[33].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[33].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-5이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                   // Long_Note.instance.ResetTouchStatus_2();

                }

                //2-6
                if (Manager_0.instance.Nor_Note_Log[34].activeSelf == false &&
                Button_2_Pressed == true && Long_Note.instance.long_col[34].fin_col.enabled == true && Long_Note.instance.long_note_col[34].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("2-6 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[34].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[34].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[34].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("2-6 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[34].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[34].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[34].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 2-6이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_2();
                    //Long_Note.instance.ResetTouchStatus_2();

                }

                //3-0
                if (Manager_0.instance.Nor_Note_Log[7].activeSelf == false &&
                Button_3_Pressed == true && Long_Note.instance.long_col[7].fin_col.enabled == true && Long_Note.instance.long_note_col[7].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("3-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[7].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[7].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[7].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       Debug.Log("3-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[7].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[7].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[7].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-0이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                   // Long_Note.instance.ResetTouchStatus_3();

                }

                //3-1
                if (Manager_0.instance.Nor_Note_Log[9].activeSelf == false &&
                Button_3_Pressed == true && Long_Note.instance.long_col[9].fin_col.enabled == true && Long_Note.instance.long_note_col[9].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       Debug.Log("3-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[9].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[9].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[9].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("3-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[9].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[9].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[9].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                    //Long_Note.instance.ResetTouchStatus_3();

                }

                //3-2
                if (Manager_0.instance.Nor_Note_Log[11].activeSelf == false &&
                Button_3_Pressed == true && Long_Note.instance.long_col[11].fin_col.enabled == true && Long_Note.instance.long_note_col[11].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       Debug.Log("3-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[11].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[11].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[11].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("3-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[11].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[11].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[11].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                    //Long_Note.instance.ResetTouchStatus_3();

                }

                //3-3
                if (Manager_0.instance.Nor_Note_Log[13].activeSelf == false &&
                Button_3_Pressed == true && Long_Note.instance.long_col[13].fin_col.enabled == true && Long_Note.instance.long_note_col[13].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("3-3 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[13].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[13].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[13].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("3-3 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[13].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[13].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[13].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-3이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                    //Long_Note.instance.ResetTouchStatus_3();

                }

                //3-4
                if (Manager_0.instance.Nor_Note_Log[19].activeSelf == false &&
                Button_3_Pressed == true && fin_col.enabled == true && long_note.long_note_col[19].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("3-4 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[19].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[19].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[19].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Debug.Log("3-4 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[19].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[19].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[19].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                   // Debug.Log(objectsToDelete.Length + " 3-4이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                    //Long_Note.instance.ResetTouchStatus_3();

                }

                //3-5
                if (Manager_0.instance.Nor_Note_Log[27].activeSelf == false &&
                Button_3_Pressed == true && fin_col.enabled == true && long_note.long_note_col[27].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("3-5 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[27].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[27].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[27].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("3-5 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[27].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[27].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[27].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-5이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                    //Long_Note.instance.ResetTouchStatus_3();

                }

                //3-6
                if (Manager_0.instance.Nor_Note_Log[36].activeSelf == false &&
                Button_3_Pressed == true && fin_col.enabled == true && long_note.long_note_col[36].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("3-6 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[36].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[36].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[36].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("3-6 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        canBePressed = false;
                        long_note.long_note_col[36].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[36].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[36].enabled = false;
                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 3-6이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_3();
                   // Long_Note.instance.ResetTouchStatus_3();

                }


                //4-0
                if (Manager_0.instance.Nor_Note_Log[2].activeSelf == false &&
                Button_4_Pressed == true && Long_Note.instance.long_col[2].fin_col == true && Long_Note.instance.long_note_col[2].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[2].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[2].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[2].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[2].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[2].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[2].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-1
                if (Manager_0.instance.Nor_Note_Log[3].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[3].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[3].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[3].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[3].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("4-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[3].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[3].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[3].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-2
                if (Manager_0.instance.Nor_Note_Log[16].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[16].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       // Debug.Log("4-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[16].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[16].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[16].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("4-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[16].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[16].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[16].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-3
                if (Manager_0.instance.Nor_Note_Log[17].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[17].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                      //  Debug.Log("4-3 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[17].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[17].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[17].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                      // Debug.Log("4-3 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[17].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[17].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[17].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-3이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }


                //4-4
                if (Manager_0.instance.Nor_Note_Log[18].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[18].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-4 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[18].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[18].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[18].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-4 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[18].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[18].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[18].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                   // Debug.Log(objectsToDelete.Length + " 4-4이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-5
                if (Manager_0.instance.Nor_Note_Log[21].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[21].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-5 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[21].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[21].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[21].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("4-5 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[21].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[21].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[21].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-5이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-6
                if (Manager_0.instance.Nor_Note_Log[22].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[22].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Debug.Log("4-6 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[22].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[22].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[22].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       //Debug.Log("4-6 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[22].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[22].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[22].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-6이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-7
                if (Manager_0.instance.Nor_Note_Log[23].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[23].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-7 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[23].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[23].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[23].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-7 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[23].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[23].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[23].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                   // Debug.Log(objectsToDelete.Length + " 4-7이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-8
                if (Manager_0.instance.Nor_Note_Log[28].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[28].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       // Debug.Log("4-8 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[28].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[28].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[28].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-8 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[28].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[28].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[28].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-8이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                   // Long_Note.instance.ResetTouchStatus_4();

                }

                //4-9
                if (Manager_0.instance.Nor_Note_Log[29].activeSelf == false &&
                Button_4_Pressed == true && Long_Note.instance.long_col[29].fin_col.enabled == true && Long_Note.instance.long_note_col[29].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-9 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[29].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[29].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[29].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("4-9 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[29].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[29].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[29].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-9이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                   // Long_Note.instance.ResetTouchStatus_4();

                }

                //4-10
                if (Manager_0.instance.Nor_Note_Log[30].activeSelf == false &&
                Button_4_Pressed == true && Long_Note.instance.long_col[30].fin_col.enabled == true && Long_Note.instance.long_note_col[30].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                      //  Debug.Log("4-10 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[30].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[30].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[30].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                       // Debug.Log("4-10 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[30].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[30].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[30].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-10이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-11
                if (Manager_0.instance.Nor_Note_Log[32].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[32].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-11 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[32].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[32].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[32].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-11 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[32].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[32].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[32].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                   // Debug.Log(objectsToDelete.Length + " 4-11이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //4-12
                if (Manager_0.instance.Nor_Note_Log[35].activeSelf == false &&
                Button_4_Pressed == true && Long_Note.instance.long_col[35].fin_col.enabled == true && Long_Note.instance.long_note_col[35].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                      // Debug.Log("4-12 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[35].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[35].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[35].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                      // Debug.Log("4-12 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[35].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[35].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[35].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-12이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                   // Long_Note.instance.ResetTouchStatus_4();

                }

                //4-13
                if (Manager_0.instance.Nor_Note_Log[38].activeSelf == false &&
                Button_4_Pressed == true && fin_col.enabled == true && long_note.long_note_col[38].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("4-13 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[38].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[38].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[38].enabled = false;
                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-13 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[38].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[38].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[38].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 4-13이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_4();
                    //Long_Note.instance.ResetTouchStatus_4();

                }

                //5-0
                if (Manager_0.instance.Nor_Note_Log[0].activeSelf == false &&
                Button_5_Pressed == true && fin_col.enabled == true && long_note.long_note_col[0].enabled == true)//&& Long_Note.instance.long_note_5_0 == true)



                {//(Long_Note.instance.long_col[j].enabled == true && Button_5_Pressed == true) -> 원래 코드

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("5-0 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[0].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[0].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[0].enabled = false;

                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("5-0 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[0].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[0].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[0].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 5-0이펙트 없어지샘'");

                    //리셋
                   // Long_Note.instance.ResetTouch_Count_5();
                   //Long_Note.instance.ResetTouchStatus_5();

                }

                //5-1
                if (Manager_0.instance.Nor_Note_Log[14].activeSelf == false &&
                Button_5_Pressed == true && fin_col.enabled == true && long_note.long_note_col[14].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("5-1 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[14].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[14].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[14].enabled = false;

                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("5-1 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[14].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[14].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[14].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 5-1이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_5();
                    //Long_Note.instance.ResetTouchStatus_5();

                }

                //5-2
                if (Manager_0.instance.Nor_Note_Log[37].activeSelf == false &&
                Button_5_Pressed == true && fin_col.enabled == true && long_note.long_note_col[37].enabled == true)
                {

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        //Debug.Log("5-2 퍼펙트요");
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);//true
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[37].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[37].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[37].enabled = false;

                }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("5-2 굿이오");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        canBePressed = false;
                        long_note.long_note_col[37].enabled = false;
                        fin_col.enabled = false;

                    //추가1130
                    Long_Note.instance.long_col[37].fin_col.enabled = false;
                    Long_Note.instance.long_note_col[37].enabled = false;

                }

                    GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");
                    foreach (GameObject obj in objectsToDelete)
                    {
                        Destroy(obj);
                    }
                    //Debug.Log(objectsToDelete.Length + " 5-2이펙트 없어지샘'");

                    //리셋
                    Long_Note.instance.ResetTouch_Count_5();
                    //Long_Note.instance.ResetTouchStatus_5();

                }

            }

            

        }

        //else
        //{
          //  canBePressed = false; // 다른 태그와 충돌 시 초기화
        //}

    }

//}
