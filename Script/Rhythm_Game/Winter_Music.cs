using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Winter_Music : MonoBehaviour
{
    public int song_select, story;

    public GameObject[] Winter_Songs;

   // public GameObject[] Main_False;//비활성해야 할 것

    public GameObject[] Pause_Black;//퍼즈 검정 창
    public GameObject Pause;//퍼즈 내용물만 모아놓은 거

    public GameObject[] Winter_Music_Obj;//음악만-오브젝트
    public AudioSource[] Winter_Music_Audio;//음악만-AudioSource

    //현재 곡으로 들어갈 수 있는 상태인지 확인
    //이거는 타이핑에 따라 바뀌기 때문에 굳이 저장/로드 필요없음
    public bool Music_Open_1 = false;
    public bool Music_Open_2 = false;
    public bool Music_Open_3 = false;
    public bool Music_Open_4 = false;

    public float Pause_Time_0 = 0;//일시 정지때 쓸거
    public float Pause_Time_1 = 0;//일시 정지때 쓸거
    public float Pause_Time_2 = 0;//일시 정지때 쓸거
    public float Pause_Time_3 = 0;//일시 정지때 쓸거
    public float Pause_Time_4 = 0;//일시 정지때 쓸거

    public Button[] Winter_Pause_5;//퍼즈 버튼 5개(계속 할 때, 버튼이 눌리지 않도록)

    public GameObject[] Winter_0_Note;//윈터 0번째 노트 버튼(퍼즈할 때 눌리지 않도록)
    public GameObject[] Winter_1_Note;//윈터 1번째 노트 버튼(퍼즈할 때 눌리지 않도록)
    public GameObject[] Winter_2_Note;//윈터 2번째 노트 버튼(퍼즈할 때 눌리지 않도록)
    public GameObject[] Winter_3_Note;//윈터 3번째 노트 버튼(퍼즈할 때 눌리지 않도록)
    public GameObject[] Winter_4_Note;//윈터 4번째 노트 버튼(퍼즈할 때 눌리지 않도록)

    //시작 및 퍼즈할 때 사용할 스크립트(Long_Note, Long_Col, Note_1105)
    //0
    public Long_Note[] Win_0_Long;//롱 노트
    public Long_Col[] Win_0_Long_Fin;//롱 노트 끝부분
    public Note_1105[] Win_0_Note;//그냥 노트

    //1
    public Long_Note[] Win_1_Long;//롱 노트
    public Long_Col[] Win_1_Long_Fin;//롱 노트 끝부분
    public Note_1105[] Win_1_Note;//그냥 노트

    //2
    public Long_Note[] Win_2_Long;//롱 노트
    public Long_Col[] Win_2_Long_Fin;//롱 노트 끝부분
    public Note_1105[] Win_2_Note;//그냥 노트

    //3
    public Long_Note[] Win_3_Long;//롱 노트
    public Long_Col[] Win_3_Long_Fin;//롱 노트 끝부분
    public Note_1105[] Win_3_Note;//그냥 노트

    //4
    public Long_Note[] Win_4_Long;//롱 노트
    public Long_Col[] Win_4_Long_Fin;//롱 노트 끝부분
    public Note_1105[] Win_4_Note;//그냥 노트


    public TextMeshProUGUI Pause_Text;//퍼즈 텍스트 (0~5까지 있을 예정)


    //버튼 5개에 대한 bool
    public bool Continue = false;
    public bool Reset = false;
    public bool Story = false;
    public bool Songs = false;
    public bool Tempo = false;

    public static Winter_Music instance;


    public int Restart_Count = 0;

    public bool keep_speed = false;

    //public GameObject winter_song;//윈터 음악 선택창

    public GameObject song_select_btn;//음악 선택창 버튼 모음
    public GameObject select_Album;//앨범 선택란
    public Select_Album select_album;

    public GameObject Piano, Piano_Btn, Setting, HeadPhone, album_bgm, Title;//

    //public Swipe_Rev rev;
    //public Swipe_Win win;
    //public Swipe_1_fin swipe_1;

    //public Select_Album select_album;//앨범 선택란 관련 스크립트

    public Manager_0[] manager;


    public void Start()
    {
        Input.multiTouchEnabled = true;  // 멀티터치 활성화
        Rhythm_Fade.instance.Fade.SetActive(false);//리듬게임 페이드 관련 비활성
        Application.targetFrameRate = 60;

        Pause_Text.text = "PAUSE";
        instance = this;

        //씬 이동할 때 혹시 유용할까봐
        song_select = 0;
        story = 0;
    }

    private void Awake()
    {
        Input.multiTouchEnabled = true;  // 멀티터치 활성화

        Pause_Text.text = "PAUSE";
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있다면 현재 객체를 제거
        }
    }


    public void Update()
    {


        for (int i = 0; i < Pause_Black.Length; i++)
        {

            //퍼즈 창이 열려있는 경우
            if (Pause.activeSelf == true  && Pause_Text.text == "PAUSE")
            {//Pause.activeSelf == true && UI_Button.instance.Main_False[3].activeSelf == false && Pause_Text.text == "PAUSE"
                if (Input.GetButtonDown("Cancel"))
                {
                    //뒤로가기 버튼을 눌렀다면

                    //아래 계속하기 버튼 눌렀을 때와 결과가 같아야 한다.
                    //몇 초후에 계속 진행
                    Continue_true();

                }

                else if (!Input.GetButtonDown("Cancel"))
                {
                    //퍼즈 창이 열려있을 때


                    //계속하기 버튼을 눌렀을 경우
                    //-> Ready로 바꾸고 원래 속도대로
                    if (Continue == true)
                    {
                        //계속 버튼
                        //퍼즈 5개 버튼 모두 눌리지 않도록
                        Continue_true();
                        //Touch_Count = 0;

                    }

                    //다시하기 버튼을 눌렀을 경우
                    //->페이드 인 & 아웃 하고 리셋
                    else if (Reset == true)
                    {
                        ReStart_True();//아직 내용물 안 만듦
                                       // Touch_Count = 0;
                    }

                    //스토리 버튼을 눌렀을 경우
                    //-> 페이드 인 & 아웃 하고 리셋 + 스토리로 이동
                    else if (Story == true)
                    {
                        Story_True();
                        //Touch_Count = 0;
                    }

                    //음악선택 버튼을 눌렀을 경우
                    // -> 페이드 인 & 아웃하고 리셋 + 음악 선택으로 이동
                    else if (Songs == true)
                    {
                        Select_Song_True();
                        //Touch_Count = 0;
                    }

                    //박자 교정 버튼을 눌렀을 경우
                    //-> 속도 정지된 채로 창 이동
                    else if (Tempo == true)
                    {
                        Tempo_True();
                    }

                    else
                    {
                        //Debug.Log("퍼즈 창에서 버튼 눌린 거 없수다.");
                        Stop_Speed();
                        Pause_Time_0 = Winter_Music_Audio[0].time;
                        Winter_Music_Audio[0].Pause();
                    }
                }
            }

            //퍼즈 창이 닫혀있는 경우
            if (Pause.activeSelf == false && Pause_Text.text == "PAUSE")
            {//Pause.activeSelf == false && UI_Button.instance.Main_False[3].activeSelf == false && Pause_Text.text == "PAUSE"
                //Pause_Text.text = "PAUSE";

                if (Input.GetButtonDown("Cancel"))
                {
                    //퍼즈창 열림, 속도 0
                    for (int k = 0; k < Pause_Black.Length; k++)
                    {
                        Pause_Black[k].SetActive(true);//퍼즈 검정이 보이도록
                    }

                    //퍼즈 버튼 기능 활성화
                    for (int j = 0; j < Winter_Pause_5.Length; j++)
                    {
                        Winter_Pause_5[j].enabled = true;
                    }

                    //노트 버튼 오브젝트 비활성
                    for (int k = 0; k < Winter_0_Note.Length; k++)
                    {
                        Winter_0_Note[k].SetActive(false);//버튼 눌리도록
                                                          //Winter_1_Note[k].SetActive(false);//버튼 눌리도록
                                                          //Winter_2_Note[k].SetActive(false);//버튼 눌리도록
                                                          //Winter_3_Note[k].SetActive(false);//버튼 눌리도록
                                                          //Winter_4_Note[k].SetActive(false);//버튼 눌리도록
                    }

                    Pause.SetActive(true);//퍼즈 내용물이 보이도록
                    Stop_Speed();
                    Pause_Time_0 = Winter_Music_Audio[0].time;
                    Winter_Music_Audio[0].Pause();

                }

                else if (!Input.GetButtonDown("Cancel") && Pause_Text.text == "PAUSE")
                {
                    //퍼즈 창이 닫혀있는데, 뒤로가기 버튼을 누르지 않았을 경우
                    //계속 재생, 속도 원래대로
                    Keep_Speed();

                }
            }


        }
    }

    public void Keep_Speed()
    {
        keep_speed = true;

    }

    public void Stop_Speed()
    {
        keep_speed = false;

    }


    public void Go_Continue()
    {
        Continue = true;
        
    }

    public void Continue_true()
    {
        Continue = false;
        SFX_Manager.instance.SFX_Button();

        //퍼즈 버튼들 비활성
        for (int j = 0; j < Winter_Pause_5.Length; j++)
        {
            Winter_Pause_5[j].enabled = false;
        }

        Pause_Text.text = "READY";


        StartCoroutine(No_Pause());
        IEnumerator No_Pause()
        {
            //퍼즈 창 없애기
            yield return new WaitForSecondsRealtime(1.0f);
            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록


            StartCoroutine(Go_Game());
        }



        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.0f);

            for (int i = 0; i < Winter_Music_Obj.Length; i++)
            {
                if (Winter_Music_Obj[i].activeSelf == true)//현재 활성화된(재생중이던)오브젝트만 음악 재생
                {
                    //Pause_Text.text = "PAUSE";
                    //노트 버튼 눌리도록
                    for (int k = 0; k < Winter_0_Note.Length; k++)
                    {
                        Winter_0_Note[k].SetActive(true);//버튼 눌리도록
                                                         //Winter_1_Note[k].SetActive(true);//버튼 눌리도록
                                                         //Winter_2_Note[k].SetActive(true);//버튼 눌리도록
                                                         //Winter_3_Note[k].SetActive(true);//버튼 눌리도록
                                                         //Winter_4_Note[k].SetActive(true);//버튼 눌리도록
                    }

                    //Winter_Music_Audio[i].time = Pause_Time_0;
                    //Winter_Music_Audio[i].Play();
                    Winter_Music_Audio[0].time = Pause_Time_0;
                    Winter_Music_Audio[0].UnPause();


                    Debug.Log("퍼즈된 거 다시 재생");

                    //그냥 노트, 롱 노트, 롱 노트 끝부분 재생
                    Keep_Speed();


                    //Continue = false;




                }
            }

           StartCoroutine(Go_Game2());

        }

        IEnumerator Go_Game2()
        {
            yield return new WaitForSeconds(0.2f);
            Pause_Text.text = "PAUSE";
        }

    }

    public void Go_ReStart()
    {
        //다시 시작 버튼
        Reset = true;
        //저장된 노트들의 위치를 불러와야 함.
        //일단 나중에.



    }

    public void ReStart_True()
    {

        //음악 퍼즈 시간 초기화
        SFX_Manager.instance.SFX_Button();

        //음악 선택란이 있는 곳으로 이동
        Rhythm_Fade.instance.Fade.SetActive(true);

        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                          //다시 시작 버튼

            //SceneManager.LoadScene("Go_Rhythm");//씬 이동
            Win_Note_Pos.instance.Load_AllPositions();

            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Songs[0].SetActive(true);//윈터 0번째 음악 리듬게임 활성

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록

            // Select_Album.instance.winter_song.SetActive(false);//윈터 음악 선택 비활성
            //Select_Album.instance.song_select_btn.SetActive(false);//음악 선택 버튼들 비활성

            //여기 추가
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(false);
            }*/

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록

            //UI_Button.instance.Piano_Btn.SetActive(false);

            /* manager[0].currentScore = 0.0f;
             manager[0].Good_Hits = 0;
             manager[0].Perfect_Hits = 0;
             manager[0].Miss_Hits = 0;
             manager[0].Long_Note_Miss = 0;
            */


            foreach (var m in manager)
            {
                m.currentScore = 0.0f;
                m.Good_Hits = 0;
                m.Perfect_Hits = 0;
                m.Miss_Hits = 0;
                m.Long_Note_Miss = 0;

                m.ScoreText.text = "0.00%";//점수 리셋
                m.currentScore = 0;
            }



            //롱 노트와 롱 노트 끝부분에 있는 콜라이더 활성화
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;

                //리셋
                //Win_0_Long[j].ResetTouchStatus_0();
                Win_0_Long[j].ResetTouch_Count_0();

                //Win_0_Long[j].ResetTouchStatus_1();
                Win_0_Long[j].ResetTouch_Count_1();

                //Win_0_Long[j].ResetTouchStatus_2();
                Win_0_Long[j].ResetTouch_Count_2();

               // Win_0_Long[j].ResetTouchStatus_3();
                Win_0_Long[j].ResetTouch_Count_3();

               // Win_0_Long[j].ResetTouchStatus_4();
                Win_0_Long[j].ResetTouch_Count_4();

              //  Win_0_Long[j].ResetTouchStatus_5();
                Win_0_Long[j].ResetTouch_Count_5();
                //Win_0_Long[j].ResetTouchStatus();

                Debug.Log("페이드 아웃 되라고2");
            }


            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);//버튼 눌리도록
                                                 //Winter_1_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_2_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_3_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_4_Note[k].SetActive(true);//버튼 눌리도록
            }


            var NoteArrays = new List<Note_1105[]>()
                        {
    Win_0_Note,
    //Win_1_Note,
    //Win_2_Note,
    //Win_3_Note,
    //Win_4_Note
};
            // 모든 배열의 rect.anchoredPosition을 조작
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }

            StartCoroutine(Go_Empty());

            //내려오는 중일 경우에 
            StartCoroutine(Music_Go());

        }



        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5초보다는 크고
            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Music_Obj[0].SetActive(true);//윈터 0번째 음악 리듬게임 비활성
            Winter_Music_Audio[0].Play();
        }

        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            Debug.Log("페이드 아웃 되라고5");

            //Keep_Speed();

            StartCoroutine(SetActive_False());
        }



        IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);

            Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("페이드 아웃 되라고");

            //StartCoroutine(Note_Reset());




        }
    }



    public void Go_Select_Song()
    {
        Songs = true;
    }

    public void Select_Song_True()
    {
        song_select = 1;
        SFX_Manager.instance.SFX_Button();

        //음악 선택 버튼
        Songs = false;

        //음악 관련 오브젝트 비활성
        Pause_Text.text = "PAUSE";

        //음악 퍼즈 시간 초기화


        //음악 선택란이 있는 곳으로 이동
        //Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Go_Game());
        StartCoroutine(Go_Game2());

        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(1.0f);//2.25
            //SceneManager.LoadScene("Title_0930");//씬 이동
            //SceneManager.LoadScene("Title_0930");//씬 이동
            PlayerPrefs.SetString("NextScene", "Title_0930"); // 이동할 씬을 PlayerPrefs에 저장
            PlayerPrefs.Save();

            Winter_Music_Obj[0].SetActive(false);

            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Songs[0].SetActive(false);//윈터 0번째 음악 리듬게임 비활성

            for (int k = 0; k < Pause_Black.Length; k++)
            {
               Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록

            /*select_album.select_Album.SetActive(false);
            select_album.Album[0].SetActive(true);
            Winter_Music.instance.select_album.Select_Song_Btn.SetActive(true);

            //Select_Album.instance.swipe_1.hor.enabled = false;//앨범으로 들어갈 때

            //스와이프 다 리셋
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();

            // 현재 버튼 번호에 따라 Album 활성화 및 비활성화
            for (int i = 0; i < Select_Album.instance.Album.Length; i++)
            {
                Select_Album.instance.Album[i].SetActive(i == Swipe_1_fin.instance.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화

            }*/
            //SceneManager.LoadScene("Loading_Scene"); // 로딩 씬으로 이동

            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(true);//기존 비활성한거 다 활성화
            }*/

        }

        IEnumerator Go_Game2()
        {
            yield return new WaitForSeconds(1.4f);//2.25
            SceneManager.LoadScene("Loading_Scene");
        }
            /*Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Songs[0].SetActive(false);//윈터 0번째 음악 리듬게임 비활성

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록




            select_album.select_Album.SetActive(false);
            select_album.Album[0].SetActive(true);

            //Select_Album.instance.swipe_1.hor.enabled = false;//앨범으로 들어갈 때

            //스와이프 다 리셋
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();

            // 현재 버튼 번호에 따라 Album 활성화 및 비활성화
            for (int i = 0; i < Select_Album.instance.Album.Length; i++)
            {
                Select_Album.instance.Album[i].SetActive(i == Swipe_1_fin.instance.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화

            }

            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            StartCoroutine(SetActive_False());

            // 기타 버튼 비활성화
            Select_Album.instance.Select_Song_Btn.SetActive(true);
            //UI_Button.instance.Piano_Btn.SetActive(false);
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(1.4f);
            Rhythm_Fade.instance.Fade.SetActive(false);


            Pause_Text.text = "PAUSE";
        }*/

        }

    public void Go_Tempo()
    {
        //박자 교정 버튼
        Tempo = true;
    }

    public void Tempo_True()
    {
        //박자 교정 버튼
        Tempo = false;
    }


    public void Go_Story()
    {
        //스토리 버튼
        Story = true;
    }

    public void Story_True()
    {
        story = 1;
        SFX_Manager.instance.SFX_Button();

        Story = false;

        //음악 관련 오브젝트 비활성
        Pause_Text.text = "PAUSE";

        //음악 퍼즈 시간 초기화


        //음악 선택란이 있는 곳으로 이동
       // Title_Fade.instance.Fade_Canvas.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");



        StartCoroutine(Go_Game());



        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(1.0f);//2.25
            PlayerPrefs.SetString("NextScene", "Title_0930"); // 이동할 씬을 PlayerPrefs에 저장
            PlayerPrefs.Save();
            SceneManager.LoadScene("Loading_Scene");


            // 퍼즈 버튼들 비활성
            for (int j = 0; j < Winter_Pause_5.Length; j++)
            {
                Winter_Pause_5[j].enabled = false;
            }

            Pause_Text.text = "PAUSE";

            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Songs[0].SetActive(false);//윈터 0번째 음악 리듬게임 비활성

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록

            //스와이프 다 리셋
            //Select_Album.instance.win.Reset();
            //Select_Album.instance.rev.Reset();
            //Swipe_1_fin.instance.Reset();
            //스와이프 다 리셋
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();


            //스토리 버튼
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(true);//비활성화 했던거 다 활성화
            }*/

            //UI_Button.instance.Piano.SetActive(false);
            //Select_Album.instance.select_Album.SetActive(true);

            song_select_btn.SetActive(true);
            select_Album.SetActive(true);

            // 기타 버튼 비활성화
            //Select_Album.instance.Select_Song_Btn.SetActive(false);
            //UI_Button.instance.Piano_Btn.SetActive(false);

            //윈터 음악들 관련 오브젝트 전부 비활성화
            for (int i = 0; i < Winter_Songs.Length; i++)
            {
                Winter_Songs[i].SetActive(false);
            }

            //윈터 재생되는 음악 오브젝트 전부 비활성화
            for (int i = 0; i < Winter_Music_Obj.Length; i++)
            {
                Winter_Music_Obj[i].SetActive(false);
            }

            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(1.4f);
            //Title_Fade.instance.Fade_Canvas.SetActive(false);


            Pause_Text.text = "PAUSE";
        }
    }

    public void Go_W_Music_0()
    {
        song_select = 0;
        story = 0;

        SFX_Manager.instance.SFX_Button();
        /*PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // 이동할 씬을 PlayerPrefs에 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene("Loading_Scene");*/
        //Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        // 1.4초 후에 로딩 씬으로 이동하는 코루틴 시작
        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            // 1.4초 대기 후 로딩 씬으로 이동
            yield return new WaitForSecondsRealtime(1.0f);

            //Select_Album.instance.Select_Song_Btn.SetActive(false);
            //Select_Album.instance.Album[0].SetActive(false);
            song_select_btn.SetActive(false);
            select_Album.SetActive(false);

            // PlayerPrefs에 "NextScene" 값 저장
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // 이동할 씬을 PlayerPrefs에 저장
            PlayerPrefs.Save();
            SceneManager.LoadScene("Loading_Scene");

            
        }

        
    }

    /*public void Go_W_Music_03()
    {
        // 음악 퍼즈 시간 초기화

        // 음악 선택란이 있는 곳으로 이동
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        // 1.4초 후에 로딩 씬으로 이동하는 코루틴 시작
        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            // 1.4초 대기 후 로딩 씬으로 이동
            yield return new WaitForSecondsRealtime(1.4f);
            Select_Album.instance.Piano.SetActive(false);
            Select_Album.instance.Piano_Btn.SetActive(false);

            Select_Album.instance.select_Album.SetActive(false);
            Select_Album.instance.Select_Song_Btn.SetActive(false);

            Select_Album.instance.Album[0].SetActive(false);
            Select_Album.instance.Album[1].SetActive(false);



            // PlayerPrefs에 "NextScene" 값 저장
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // 이동할 씬을 PlayerPrefs에 저장
            PlayerPrefs.Save();
            //SceneManager.LoadScene("Loading_Scene");
            // 페이드 아웃 후 로딩 씬으로 이동
             StartCoroutine(LoadSceneWithFade());

            // 게임 세팅 초기화 코드 (로딩 씬에서 실행됨)
            InitializeGameSettings();

            // 페이드 아웃 후 실행될 추가 작업
            StartCoroutine(Go_Empty());
            StartCoroutine(Music_Go());
        }

        // 로딩 씬을 페이드 후 로드하는 코루틴
        IEnumerator LoadSceneWithFade()
        {
            // 페이드 애니메이션이 끝날 때까지 대기
            yield return new WaitForSecondsRealtime(1f); // 페이드 완료 대기 (애니메이션 길이에 맞추기)

            // 로딩 씬으로 이동
            SceneManager.LoadScene("Loading_Scene");
        }

        // 게임 설정 초기화 코드 (로딩 씬에서 실행)
        void InitializeGameSettings()
        {
            Winter_Songs[0].SetActive(true);

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);
            }
            Pause.SetActive(false);

            // 점수 초기화
            foreach (var m in manager)
            {
                m.currentScore = 0.0f;
                m.Good_Hits = 0;
                m.Perfect_Hits = 0;
                m.Miss_Hits = 0;
                m.Long_Note_Miss = 0;
                m.ScoreText.text = "0.00%"; // 점수 리셋
            }

            // 롱 노트와 콜라이더 활성화
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;
                // 리셋
                ResetLongNotes(j);
            }

            // Winter_0_Note 활성화
            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);
            }

            // 노트 배열 초기화
            InitializeNotes();
        }

        void ResetLongNotes(int j)
        {
            // 롱 노트 관련 리셋
            //Win_0_Long[j].ResetTouchStatus_0();
            Win_0_Long[j].ResetTouch_Count_0();
            //Win_0_Long[j].ResetTouchStatus_1();
            Win_0_Long[j].ResetTouch_Count_1();
            Win_0_Long[j].ResetTouch_Count_2();
            Win_0_Long[j].ResetTouch_Count_3();
            Win_0_Long[j].ResetTouch_Count_4();
            Win_0_Long[j].ResetTouch_Count_5();
            // 계속 추가...
        }

        void InitializeNotes()
        {
            var NoteArrays = new List<Note_1105[]>()
        {
            Win_0_Note,
            // Win_1_Note, etc.
        };

            // 모든 배열의 rect.anchoredPosition을 조작
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }
        }

        // 페이드 아웃 후 실행될 추가 작업
        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            //Rhythm_Fade.instance.Fade.SetActive(true);
            //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            Debug.Log("페이드 아웃 되라고");

            // 필요시 추가 작업 (게임 관련 요소 비활성화 등)
            StartCoroutine(SetActive_False());
        }

        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5초보다는 크고
            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
                                           //Winter_Music_Obj[0].SetActive(true);//윈터 0번째 음악 리듬게임 비활성
            Winter_Music_Audio[0].Play();
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);
            Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("페이드 아웃 완료");

            // 추가 작업
        }
    }


    */


    //아래부터는 음악 진입 코드 관련
    //hopeful Piano곡 연주하러 가는 버튼
    public void Go_W_Music_1()
    {

        //음악 퍼즈 시간 초기화


        //음악 선택란이 있는 곳으로 이동
        Rhythm_Fade.instance.Fade.SetActive(true);
        
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                          //다시 시작 버튼

            // SceneManager.LoadScene("Go_Rhythm");//씬 이동
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // 이동할 씬을 PlayerPrefs에 저장
            PlayerPrefs.Save();
            SceneManager.LoadScene("LoadingScene"); // 로딩 씬으로 이동

            //Load_Control.LoadScene("Go_Rhythm");
            Win_Note_Pos.instance.Load_AllPositions();
            

            //Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            Winter_Songs[0].SetActive(true);//윈터 0번째 음악 리듬게임 활성

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록

           // Select_Album.instance.winter_song.SetActive(false);//윈터 음악 선택 비활성
            //Select_Album.instance.song_select_btn.SetActive(false);//음악 선택 버튼들 비활성

            //여기 추가
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(false);
            }*/

            /*for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//퍼즈 검정이 보이지 않도록
            }
            Pause.SetActive(false);//퍼즈 내용물이 보이지 않도록
            */
            //UI_Button.instance.Piano_Btn.SetActive(false);

            /* manager[0].currentScore = 0.0f;
             manager[0].Good_Hits = 0;
             manager[0].Perfect_Hits = 0;
             manager[0].Miss_Hits = 0;
             manager[0].Long_Note_Miss = 0;
            */

            
                foreach (var m in manager)
                {
                    m.currentScore = 0.0f;
                    m.Good_Hits = 0;
                    m.Perfect_Hits = 0;
                    m.Miss_Hits = 0;
                    m.Long_Note_Miss = 0;

                    m.ScoreText.text = "0.00%";//점수 리셋
                    m.currentScore = 0;
                }
            


            //롱 노트와 롱 노트 끝부분에 있는 콜라이더 활성화
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;

                //리셋
                //Win_0_Long[j].ResetTouchStatus_0();
                Win_0_Long[j].ResetTouch_Count_0();

                //Win_0_Long[j].ResetTouchStatus_1();
                Win_0_Long[j].ResetTouch_Count_1();

                //Win_0_Long[j].ResetTouchStatus_2();
                Win_0_Long[j].ResetTouch_Count_2();

                //Win_0_Long[j].ResetTouchStatus_3();
                Win_0_Long[j].ResetTouch_Count_3();

                //Win_0_Long[j].ResetTouchStatus_4();
                Win_0_Long[j].ResetTouch_Count_4();

                //Win_0_Long[j].ResetTouchStatus_5();
                Win_0_Long[j].ResetTouch_Count_5();
                //Win_0_Long[j].ResetTouchStatus();

                Debug.Log("페이드 아웃 되라고2");
            }


            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);//버튼 눌리도록
                                                 //Winter_1_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_2_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_3_Note[k].SetActive(true);//버튼 눌리도록
                                                 //Winter_4_Note[k].SetActive(true);//버튼 눌리도록
            }


            var NoteArrays = new List<Note_1105[]>()
                        {
    Win_0_Note,
    //Win_1_Note,
    //Win_2_Note,
    //Win_3_Note,
    //Win_4_Note
};
            // 모든 배열의 rect.anchoredPosition을 조작
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }

            StartCoroutine(Go_Empty());

            //내려오는 중일 경우에 
            StartCoroutine(Music_Go());

        }

        

        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5초보다는 크고
            Winter_Music_Audio[0].time = 0;//퍼즈 시간 초기화
            //Winter_Music_Obj[0].SetActive(true);//윈터 0번째 음악 리듬게임 비활성
            Winter_Music_Audio[0].Play();
        }

        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            Debug.Log("페이드 아웃 되라고5");

            //Keep_Speed();

            //StartCoroutine(SetActive_False());
        }



        /*IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);

            //Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("페이드 아웃 되라고");

            //StartCoroutine(Note_Reset());




        }*/
    }

 
    }
