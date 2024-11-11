using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QManager questManager;//퀘스트 매니저를 변수로 생성하고 퀘스트번호를 가져온다
    public GameObject talkPanel;
    public Image portraitImg;//Image UI접근을 위해 변수를 생성하고 할당하낟.
    public Text talkText;//대화창 가지고 오는 거
    //public Text questText;//메뉴 버튼 위에 퀘스트 알림 메뉴 때문에 하는 거임
    public GameObject menuSet;//메뉴 버튼때문에 만든거임
    public GameObject scanObject;//플레이어가 조사했던 게임 오브젝트
    public GameObject player;//게임 저장메뉴 때문에 만든거임
    public bool isAction;//대화창을 띄웠는지 안 띄웠는지 확인을 위해 상태 저장용 변수를 추가
    public int talkIndex;

    public GameObject TitleSet;//시작 화면

    public GameObject fadeInPanel;//페이드 인 패널



    //public SceneTransition sceneTransition;//씬 전환
    //public SceneTransition sceneTransition2;//씬 전환
    //public string sceneToLoad;//씬 불러오는 거

    //public SceneDetails CurrentScene { get; private set; }//씬 전환 안 되면 지우기
    //public SceneDetails PrevScene { get; private set; }//씬 전환 안 되면 지우기

    //public static GameManager Instance { get; private set; }//씬 전환 안 되면 지우기

    /*private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

    }*/

    //public GameObject fadeOutPanel;//페이드 아웃 패널20220929

    void Start()
    {
        GameLoad();//게임 로드에서 세팅 메뉴때문에 만든거임

        Debug.Log(questManager.CheckQuest());//메뉴 만들기 전까지 썼었던 코드


        //매개변수가 없는 함수가 실행됨

        //매개변수에 따라 함수가 호출되는 것을 오버로딩(Overloading)이라 한다.

        //questText.text = questManager.CheckQuest();//퀘스트 텍스트 UI를 변수로 할당하여 퀘스트 이름 전달
        //요건 메뉴때문에 만든 거임
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

        
    }


    void Update()
    {
        //SubMenu
        if (Input.GetButtonDown("Cancel"))//Esc버튼을 누르면
        {
            //여기 밑엔 PC일 경우
            /*if (menuSet.activeSelf)//메뉴가 켜져 있으면
                menuSet.SetActive(false);//메뉴창을 꺼주세요
            else
                menuSet.SetActive(true);//아니면 메뉴창을 켜주세요*/

            SubMenuActive();//이건 액션 버튼때문에 만든 거임(v자 그림.)
        }

        

        if (TitleSet.activeSelf)//타이틀 켜져 있으면
        {
            

            TitleSet.SetActive(true);//타이틀을 켜주세요


            //soundmanager.bgSound.Pause();

        }


        else
        {
            TitleSet.SetActive(false);//아니면 타이틀을 꺼주세요
            //soundmanager.bgSound.Play();
            
        }
            


        //TitleSet.SetActive(true);//아니면 타이틀을 켜세요



    }

    public void SubMenuActive()//이건 액션 버튼때문에 만든 거임(v자 그림.)
    {
        if (menuSet.activeSelf)//메뉴가 켜져 있으면
            menuSet.SetActive(false);//메뉴창을 꺼주세요
        else
            menuSet.SetActive(true);//아니면 메뉴창을 켜주세요
    }


    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;//스캔했던 object를 저장한 뒤에
        ObjData objData = scanObject.GetComponent<ObjData>();
        //스캔한 오브젝트를 가지고 오면 오브젝트 데이터 가지고 와야 함
        Talk(objData.id, objData.isNpc);
        

        talkPanel.SetActive(isAction);
        //액션 여부에 따라 talkPanel이 나타나고 사라짐
        





        void Talk(int id, bool isNpc)
        {
            int questTalkIndex = questManager.GetQuestTalkIndex(id);//퀘스트 번호 가져옴
            string talkData=talkManager.GetTalk(id+questTalkIndex, talkIndex);
            //퀘스트 번호+NPC Id=퀘스트 대화 데이터Id

            //id, talkIndex에 해당하는 문자열이 나오는데 그걸 저장

            //만약 토크 데이터가 비어있으면(다음 대화가 없으면)
            //이 대화는 끝이 났다고 알림.
            if(talkData==null)
            {
                isAction = false;
                talkIndex = 0; //대화가 끝날 때 talkIndex를 0으로 초기화

                //questText.text = questManager.CheckQuest(id);//메뉴때문에 만든거임



                Debug.Log(questManager.CheckQuest(id));//퀘스트 이름을 반환하도록 함수 개조
                //메뉴 안 되면 이거 다시 살리기


                //대화가 끝났으면은 퀘스트 매니저에 가서 CheckQuest()를 불러온다
                //그러면 대사가 끝나면 questActionIndex++가 올라가면서 다음 퀘스트를 불러온다.
                return;//void함수에서 return은 강제 종료 역할이다
            }


            //만약에 Npc면 
            if (isNpc)
            {
                talkText.text = talkData.Split(':')[0];

                portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
                //GetPortrait로 인해 Sprite를 가져오고 그 Sprite를 PortraitImg에 집어넣는다

                portraitImg.color = new Color(1, 1, 1, 1);//NPC일때만 이미지가 보이도록 작성.(난 상관없이 다 쓸거라 둘다 쓸 예정)
                //color는 이미지의 투명도
            }
            else //Npc가 아니면
            {
                talkText.text = talkData.Split(':')[0];
                //talkText.text = talkData;

                portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
                portraitImg.color = new Color(1, 1, 1, 1);//NPC일때만 이미지가 보이도록 작성.(난 상관없이 다 쓸거라 둘다 쓸 예정)
                //color는 이미지의 투명도
                //안 보이게 하려면 (1, 1, 1, 0)으로 해야함

            }

            isAction = true;
            talkIndex++;//토크 인덱스를 늘려줘야함.
                        //대화의 다음 문장을 뽑아내기 위해 필요함

            
        }

        
    }



    public void GameSave()//게임 저장
    {
        Debug.Log("게임 저장");
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        //PlayerPrefs.SetString("SceneName", sceneTransition.sceneToLoad);//씬 때문에
        //PlayerPrefs.SetString("SceneName", sceneTransition2.sceneToLoad);//씬 때문에

        //**여기는 저장한 씬을 불러오기 위해 만든 것임**//
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

        //**여기까지 저장한 씬을 불러오기 위해 만든 것임**//


        PlayerPrefs.Save();//레지스토리에 위에 설정한 것들이 저장됨

        menuSet.SetActive(false);//저장 버튼 누르면 메뉴 버튼 사라짐
        

    }

    public void GameLoad()//게임 불러오기
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }

        Debug.Log("계속하기");
        //최초 게임 실행했을 때 데이터가 없으므로 예외처리
        if (!PlayerPrefs.HasKey("PlayerX"))//PlayerPrefs에 한 번이라도 저장한 적이 없다면
            return;//로드 자체를 하지 마

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        //**여기는 저장한 씬을 불러오기 위해 만든 것임**//
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

        //**여기까지 저장한 씬을 불러오기 위해 만든 것임**//
        





        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        //sceneTransition.sceneToLoad = sceneToLoad;//씬 떄문에
        //sceneTransition2.sceneToLoad = sceneToLoad;//씬 떄문에

        questManager.ControlObject();//저장때문에 만든거임

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }





    }

    

    public void GameExit()//게임 나가기 메뉴
    {
        Debug.Log("끝");
        //ControlSet.SetActive(true);
        //Application.Quit();//나중에 게임 실행할 떈 이것만 씀
        //SceneManager.LoadScene("Main");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//유니티 애디터 안에서 멈추게 한다
#else   
        Application.Quit();
#endif




    }

    public void OnClickQuit()
    {

        Debug.Log("끝");
        //ControlSet.SetActive(true);
        //Application.Quit();//나중에 게임 실행할 떈 이것만 씀
        //SceneManager.LoadScene("Main");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//유니티 애디터 안에서 멈추게 한다
#else   
        Application.Quit();
#endif

    }

    /*public void OnClickNewGame()
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }


        TitleSet.SetActive(false);//저장 버튼 누르면 메뉴 버튼 사라짐
        Debug.Log("다 삭제됐다 짜샤");
        PlayerPrefs.DeleteAll();
        //StartCoroutine(WaitPlease());
        
        SceneManager.LoadScene("SampleScene");


    }*/

    public void OnClickNewGame()
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }


        TitleSet.SetActive(false);//저장 버튼 누르면 메뉴 버튼 사라짐
        Debug.Log("다 삭제됐다 짜샤");
        PlayerPrefs.DeleteAll();
        //StartCoroutine(WaitPlease());

        SceneManager.LoadScene("Prologe");


    }

    public void OnClickGoMain()
    {
        
        TitleSet.SetActive(true);
        Debug.Log("메인 메뉴로");
        SceneManager.LoadScene("Main");

    }


    //페이드 인 코루틴 때문에 만든 거임
    /*IEnumerator WaitPlease()
    {
        yield return new WaitForSeconds(1.0f);
    }*/




    /* public void SetCurrentScene(SceneDetails currScene)//씬 전환때문에 만든 거. 안 되면 지우기
     {
         PrevScene = CurrentScene;
         CurrentScene = currScene;
     }*/



}


