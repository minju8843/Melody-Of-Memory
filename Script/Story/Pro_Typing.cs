using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]//JsonUtility를 사용하여 JSON형식으로 변환하려면
//객체가 Serializable해야 함.

public class Pro_Typing_Data
{
    //저장을 위해 만든 클래스
    public int Sentences_0_Index;//몇 번째 문장인지
    public int Bg_0_Index;//몇 번째 배경인지
}

public class Pro_Typing : MonoBehaviour
{
    public Animator Open_Eye;//윈터 눈뜸 애니메이션
    public Animator Disappera_Rev;//레브리 사라짐 애니메이션

    public GameObject Pro_Win;//프롤로그에 사용되는 윈터
    public GameObject Rev;//레브리 도트

    public static Pro_Typing instance;

   // public Button btn;//말풍선 버튼 활성/비활성을 위해

    public GameObject Dia;//말풍선 있는 곳
    public GameObject Inside_Dia;//대화창에 표시될 TMP(활성, 비활성을 위해)

    public TextMeshProUGUI dialogueText;//대화창에 표시될 TMP
    public string[] sentences_str_0;//표시될 문장들

    public GameObject[] Name;//캐릭터 이름
    public GameObject[] Ch;//캐릭터 전신 및 화면에 보여질 이미지

   // public GameObject Arrow;//검은 창 밑에 화살표

    //문장 어디까지 진행되었는지
    public int Default_Sentences_0 = 0;//리셋할 때 쓸거
    public int Sentences_0;//현재 문장이 몇 번째인지

    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조
    public bool isTyping = false; // 타이핑 중인지 여부

    //윈터 카메라
    public GameObject Winter_Camera;

    //윈터 카메라 아닌 프롤로그 카메라 + 움직일 윈터
    public GameObject Pro_Camera;

    //컨트롤러 및 탐색 버튼
    public GameObject Controller;
    public GameObject Serch_Btn;

    public GameObject OutSide_Map;//밖에 겨울 풍경 지도(플레이어 돌아다니는 곳)

    public void OnEnable()
    {
        //활성화될 때, 불러오기
        //Load_Sentences_0();
    }

    public void Start()
    {
        instance = this;

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        //불러오기
       

        Load_Sentences_0();
        Debug.Log("불러와");

    }

    public void FixedUpdate()
    {
        if (Typing.instance.Sentences_0 >= 142)//무조건 프롤로그 대사가 다 나온 뒤에 나와야 함
        {
            //21 -> 윈터 얼굴
            if (Sentences_0 == 0)//프롤로그 대사가 다 끝났으면서 0인 경우
            {
               Controller.SetActive(false);//컨트롤러 비활성
                Serch_Btn.SetActive(false);//탐색 버튼 비활성
                OutSide_Map.SetActive(true);//밖 지도 활성

                Pro_Camera.SetActive(true);//챕터1 프롤로그 카메라 활성
                Winter_Camera.SetActive(false);//챕터1 윈터 카메라 비활성

                Pro_Win.SetActive(true);
                Rev.SetActive(true);

                Open_Eye.SetTrigger("Close_Eye");
                Disappera_Rev.SetTrigger("Normal");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[0].SetActive(true);

            }

            if (Sentences_0 == 8 || Sentences_0 == 24 || Sentences_0 == 41)//프롤로그 대사가 다 끝났으면서 0인 경우
            {

                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[0].SetActive(true);

            }

            //3-1
            if (Sentences_0 == 1 || Sentences_0 == 33)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[1].SetActive(true);

            }

            //2-1
            if (Sentences_0 == 2)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[2].SetActive(true);

            }

            //4-1
            if (Sentences_0 == 3 || Sentences_0 == 39)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[3].SetActive(true);

            }

            //레브리
            if (Sentences_0 == 4 || Sentences_0 == 5
                || Sentences_0 == 9 || Sentences_0 == 10
                || Sentences_0 == 12
                || Sentences_0 == 16 || Sentences_0 == 17
                || (Sentences_0 >= 19 && Sentences_0 <= 23)
                 || (Sentences_0 >= 27 && Sentences_0 <= 31)
                  || (Sentences_0 >= 34 && Sentences_0 <= 38))
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[1].SetActive(true);//레브리

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[15].SetActive(true);

            }

            //5-1
            if (Sentences_0 == 6 || Sentences_0 == 32)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[4].SetActive(true);

            }

            //6
            if (Sentences_0 == 7)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[6].SetActive(true);

            }

            //18
            if (Sentences_0 == 11)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[6].SetActive(true);

            }

            //26
            if (Sentences_0 == 13)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[7].SetActive(true);

            }

            //12
            if (Sentences_0 == 14)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[8].SetActive(true);

            }

            //13
            if (Sentences_0 == 15)
            {

                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.
                Open_Eye.SetTrigger("Open_Eye");

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[9].SetActive(true);

            }

            //5
            if (Sentences_0 == 18)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[10].SetActive(true);

            }

            //19
            if (Sentences_0 == 25 || Sentences_0 == 42)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[11].SetActive(true);

            }

            //29
            if (Sentences_0 == 26)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                // btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[12].SetActive(true);

            }

            //22
            if (Sentences_0 == 40)
            {
                Rev.SetActive(false);
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//현재 꿈세계이지 프롤로그입니다.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//주인공

                //Arrow.SetActive(true);//화살표 활성화
                //btn.enabled = true;//버튼 누를 수 있도록


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//캐릭터 비활성화
                }

                Ch[13].SetActive(true);

            }

            

        }

        

    }

    public void Update()
    {
        Save_Sentences_BG();
        //Debug.Log(Application.persistentDataPath);
        //C:/Users/minju/AppData/LocalLow/Yabnosem_Company/Melody of Memory
        //->저장되는 위치 여기임

      //  Save_Text.text = Application.persistentDataPath.ToString();
    }


    public void Save_Sentences_BG()//몇 번째 문장이 나왔는지 저장
    {
        Pro_Typing_Data data = new Pro_Typing_Data();
        data.Sentences_0_Index = Sentences_0;//현재의 Sentens_0값을 할당
        string json = JsonUtility.ToJson(data);//JsonUtility.ToJson을 사용해
        //GameData_Typing객체를 JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Pro_Typing.json", json);
        //WriteAllText를 사용해 변환된 JSON문자열을 Application.persistentDataPath경로에 있는
        //Typing.json파일로 저장.

        //  Debug.Log("타이핑 저장");

        //배경 저장 -> 굳이 할 필요가 안 보이긴 함
    }

    public void Load_Sentences_0()
    {
        //문장 불러오기
        string path = Application.persistentDataPath + "/Pro_Typing.json";
        //Typing.json라는 파일이 존재하는지 확인

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Pro_Typing_Data data = JsonUtility.FromJson<Pro_Typing_Data>(json);

            //변환된 객체에서 Sentences_0_Index값을 불러와서 현재 Sentences_0에 저장
            Sentences_0 = data.Sentences_0_Index;




            if (Sentences_0 > 0 && (Typing.instance.Sentences_0 >= 142) && Sentences_0 != 43 && Sentences_0 != 44 && Sentences_0 != 45) 
            {

                Pro_Camera.SetActive(true);//챕터1 프롤로그 카메라 활성
                Winter_Camera.SetActive(false);//챕터1 윈터 카메라 비활성

                Controller.SetActive(false);//컨트롤러 비활성
                Serch_Btn.SetActive(false);//탐색 버튼 비활성
                OutSide_Map.SetActive(true);//밖 지도 활성

                //현실 지도와 헤드폰 아이콘 비활성
                UI_Button.instance.Map.SetActive(false);
                UI_Button.instance.HeadPhone.SetActive(false);

                StartCoroutine(Wait_First_Sentence());
                IEnumerator Wait_First_Sentence()
                {
                    yield return new WaitForSeconds(2.5f);
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);

                    StartTyping();

                }

                if (Sentences_0 == 38)
                {
                    Disappera_Rev.SetTrigger("Empty");
                }

                if (Sentences_0 >= 39)
                {
                    Disappera_Rev.SetTrigger("None");
                    Rev.SetActive(false);
                }

                if (Sentences_0 >= 40)
                {
                    Disappera_Rev.SetTrigger("None");
                    Rev.SetActive(false);
                }

            }


            if (Sentences_0 >= 30 && Typing.instance.Sentences_0 >= 142)
            {
                UI_Button.instance.Old_Map.SetActive(true);
                UI_Button.instance.Memo.SetActive(true);

                UI_Button.instance.Map.SetActive(false);
                UI_Button.instance.HeadPhone.SetActive(false);
            }

            if (Sentences_0 >= 43 && (Typing.instance.Sentences_0 >= 142))
            {
                Open_Eye.SetTrigger("Open_Eye");
                Disappera_Rev.SetTrigger("None");

                Pro_Win.SetActive(false);//프롤로그 윈터 비활성
                Rev.SetActive(false);//프롤로그 레브리 비활성

                Serch_Btn.SetActive(true);
                Controller.SetActive(true);
                Winter_Camera.SetActive(true);//챕터1 카메라이자 윈터
                //프롤로그 스토리 카메라 비활성
                Pro_Camera.SetActive(false);

                Dia.SetActive(false);//스토리 대화창 비활성
            }

            

           if (Sentences_0 == 0 && (Typing.instance.Sentences_0 >=142))
            {
                Pro_Camera.SetActive(true);//챕터1 프롤로그 카메라 활성
                Winter_Camera.SetActive(false);//챕터1 윈터 카메라 비활성

                //현실 지도와 헤드폰 아이콘 비활성
                UI_Button.instance.Map.SetActive(false);
                UI_Button.instance.HeadPhone.SetActive(false);

                StartCoroutine(Wait_First_Sentence());
                IEnumerator Wait_First_Sentence()
                {
                    yield return new WaitForSeconds(1.8f);//2.5
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);

                    StartTyping();
                }

                /* Dia.SetActive(true);
                     Inside_Dia.SetActive(true);

                     StartTyping();
                */
                //메모장과 오래된 지도 활성화
              
            }

           
        }

        else
        {
            //파일이 존재하지 않는 경우
            //Debug.Log("저장된 문장 데이터가 없습니다.");

            if (Sentences_0 == 0 && (Typing.instance.Sentences_0 >= 142))
            {
                //현실 지도와 헤드폰 아이콘 비활성
                UI_Button.instance.Map.SetActive(false);
                UI_Button.instance.HeadPhone.SetActive(false);

                StartCoroutine(Wait_First_Sentence());
                IEnumerator Wait_First_Sentence()
                {
                    yield return new WaitForSeconds(1.3f);
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    Debug.Log("파일이 존재하지 않아서 지우기");
                    StartTyping();
                }

               Controller.SetActive(false);//컨트롤러 비활성
                Serch_Btn.SetActive(false);//탐색 버튼 비활성
                OutSide_Map.SetActive(true);//밖 지도 활성
            }
        }
    }

   

    //저장한 파일을 삭제하는 코드
    public void Delete_Typing_Data()
    {
        string path = Application.persistentDataPath + "/Pro_Typing.json";

        if (File.Exists(path))
        {//파일이 존재하는 경우

            File.Delete(path);

            //초기화 내용 적기
            Sentences_0 = Default_Sentences_0;

            Dia.SetActive(false);
            Inside_Dia.SetActive(false);
            Save_Sentences_BG();//0105추가

            Load_Sentences_0();

            Winter_Camera.SetActive(false);
            Pro_Camera.SetActive(true);

            Rev.SetActive(true);
            Pro_Win.SetActive(true);//프롤로그 윈터 활성

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);//캐릭터 이미지 비활성화
            }

        }
        else
        {
            //return;
            Debug.Log("삭제할 타이핑 데이터 없음");
        }
    }


    //타이핑 관련 코드 시작
    public void Next_Text()
    {

        Controller.SetActive(false);//컨트롤러 비활성
        Serch_Btn.SetActive(false);//탐색 버튼 비활성
        OutSide_Map.SetActive(true);//밖 지도 활성

        //Load_Sentences_0();

        if (isTyping)
        {
            //타이핑 중일 때, 타이핑을 완성시킨다.
            CompleteTyping();
        }
        else
        {

           

            // else
            //{
            NextSentence();
            //}



        }

            Save_Sentences_BG();
    }

    public void StartTyping()
    {
        typingCoroutine = StartCoroutine(TypeSentence(sentences_str_0[Sentences_0]));
        //sentences_str_0배열에서 Sentences_0에 있는 문장을 선택
        //그 문장을 TypSentence()에 전달하여 코루틴 시작


    }

    public void NextSentence()
    {
        //다음 문장이 나오도록 하는 거
        Sentences_0++;
        //Save_Sentences_BG();

        if (Sentences_0 < sentences_str_0.Length)
        {

            //Load_Sentences_1();


            if (Typing.instance.Sentences_0 >= 141)
            {

                if (Sentences_0 == 1)
                {
                    Open_Eye.SetTrigger("Open_Eye");
                    //StartTyping();
                }

                if (Sentences_0 == 30)
                {
                    //메모장과 오래된 지도 활성화
                    UI_Button.instance.Old_Map.SetActive(true);
                    UI_Button.instance.Memo.SetActive(true);
                    // StartTyping();
                }

                if (Sentences_0 == 38)
                {
                    Disappera_Rev.SetTrigger("Empty");
                    // StartTyping();
                }

                if (Sentences_0 >= 40 && Sentences_0 <= 42)
                {
                    Disappera_Rev.SetTrigger("None");
                    Rev.SetActive(false);

                    //StartTyping();


                }


                StartTyping();
            
                
             }


           /* if (Sentences_0 >= 43)
            {
                Rhythm_Fade.instance.Fade.SetActive(true);

                Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");
                //Music_Go();

                StartCoroutine(Go_Game());

                IEnumerator Go_Game()
                {
                    yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                                  //다시 시작 버튼
                    Serch_Btn.SetActive(true);
                    Controller.SetActive(true);
                    Winter_Camera.SetActive(true);
                    //프롤로그 스토리 카메라 비활성
                    Pro_Camera.SetActive(false);

                    Dia.SetActive(false);//스토리 대화창 비활성
                    StartCoroutine(Go_Empty());

                }


                IEnumerator Go_Empty()
                {
                    yield return new WaitForSecondsRealtime(0.7f);
                    Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

                    Debug.Log("페이드 아웃 되라고5");
                    StartCoroutine(SetActive_False());
                }



                IEnumerator SetActive_False()
                {
                    yield return new WaitForSecondsRealtime(1.4f);

                    Rhythm_Fade.instance.Fade.SetActive(false);
                    Debug.Log("페이드 아웃 되라고");

                }
            }*/


            else
            {
                StartTyping();
            }

            
            
        }

        else if (Sentences_0 >= sentences_str_0.Length && Typing.instance.Sentences_0 >= 142)
        {
            //return;
            // Debug.Log("대화 종료");

            if (Sentences_0 == 43)
            {
                Open_Eye.SetTrigger("Open_Eye");
                Rhythm_Fade.instance.Fade.SetActive(true);

                Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");
                //Music_Go();

                StartCoroutine(Go_Game());

                IEnumerator Go_Game()
                {
                    yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                                  //다시 시작 버튼
                    Pro_Win.SetActive(false);//프롤로그 윈터 비활성
                    Rev.SetActive(false);

                    Serch_Btn.SetActive(true);
                    Controller.SetActive(true);
                    Winter_Camera.SetActive(true);//움직일 윈터 + 카메라 활성
                    //프롤로그 스토리 카메라 비활성
                    Pro_Camera.SetActive(false);
                    Dia.SetActive(false);//스토리 대화창 비활성

                    StartCoroutine(Go_Empty());

                }


                IEnumerator Go_Empty()
                {
                    yield return new WaitForSecondsRealtime(0.7f);
                    Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

                    Debug.Log("페이드 아웃 되라고5");
                    StartCoroutine(SetActive_False());
                }



                IEnumerator SetActive_False()
                {
                    yield return new WaitForSecondsRealtime(1.4f);

                    Rhythm_Fade.instance.Fade.SetActive(false);
                    Debug.Log("페이드 아웃 되라고");

                }
            }

            else
            {
                return;
            }
        }
    }

    public void CompleteTyping()
    {
        //타이핑 중인 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        // 현재 문장을 가져와 줄바꿈 처리
        string completedSentence = sentences_str_0[Sentences_0].Replace("\\\\", "\n");

        dialogueText.text = completedSentence;//sentences_str_0[Sentences_0];
        isTyping = false;

    }


    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = ""; // 대화창 텍스트 초기화

        // 문자열에서 '\\\\'를 줄바꿈 문자('\n')로 변환
        //인스펙터에서 작성할 때는 \\만 넣어주면 줄바꿈 됨
        //\\를 써도 실제로 \로 인식

        //줄바꿈 하고 싶을 때 예시: Hello World! \\Welcome to Unity.

        sentence = sentence.Replace("\\\\", "\n");
        
        
        //Replace()는 문자열 내에서 특정 문자나 문자열을 다른 문자나 문자열로 교체


        // 문장을 줄바꿈 문자('\n')를 기준으로 나누어 처리
        string[] lines = sentence.Split('\n');

        foreach (string line in lines)
        {
            // 각 줄을 공백을 기준으로 나누어 처리
            string[] words = line.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // 모든 단어 및 문자를 동일한 속도로 출력
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter; // 한 글자씩 텍스트에 추가
                    yield return new WaitForSeconds(0.05f); // 0.05초 기다리고 다음 글자를 출력
                }

                // 마지막 단어가 아닐 경우, 현재 단어 뒤에 공백을 추가
                if (i < words.Length - 1)
                {
                    dialogueText.text += ' ';
                }
            }

            // 줄바꿈 후에는 추가적인 줄바꿈 문자를 추가
            dialogueText.text += '\n';

            // 줄바꿈 간의 시간 지연 (선택 사항, 줄바꿈 후에 약간의 지연을 주고 싶을 때)
            //yield return new WaitForSeconds(0.1f);
        }

        isTyping = false; // 타이핑 끝남

        

    }
}
