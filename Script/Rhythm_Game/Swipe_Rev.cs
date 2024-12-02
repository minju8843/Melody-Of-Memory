using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Swipe_Rev_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_Rev : MonoBehaviour
{
    //public Swipe_Rev rev;

    public Swipe_1_fin swipe_1;

    public GameObject scrollbar, imageContent;
    public float Scroll_Value = 0.0f;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;


    public Button[] btn;//리듬게임으로 들어가는 버튼

    public GameObject[] Winter_BGM;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부

    public static Swipe_Rev instance;

    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장

    public RectTransform content; // Content의 Transform
    private List<float> originalPositionsX = new List<float>(); // X 좌표만 저장
    private bool positionsSaved = false;




    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;
    }

    public void SavePositions()
    {
        originalPositionsX.Clear(); // 기존에 저장된 X 위치 초기화

        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // X 좌표만 저장
                originalPositionsX.Add(rectTransform.anchoredPosition.x);
            }
        }

        positionsSaved = true; // 위치 저장 완료 표시
        Debug.Log("자식 오브젝트들의 X 위치가 저장되었습니다.");
        for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
        {
            Debug.Log("저장된 X 위치 - 자식 " + i + ": " + originalPositionsX[i]);
        }
    }

    void Update()
    {
        if (runIt == true)
        {
            GecisiDuzenle();// -> 얘 때문에 리셋이 안 되던 거였음

            // 위치 저장 및 복원 메서드 호출
            SavePositions(); // 위치 저장
            RestorePositions(); // 저장된 위치 복원

            // 복원 후 runIt을 false로 설정하여 중복 호출 방지
            runIt = false;
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // 스와이프 중에는 소리 재생 방지
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;



                // 조건: 이전 버튼이 0이 아니었고 현재 btnNumber가 0일 때만 소리 재생
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("이전 버튼이 0이 아닐 때 버튼 효과음 실행");
                    Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = (i == btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
            Winter_BGM[i].SetActive(i == btnNumber); // 넘버와 같으면 음악 재생, 아니면 비활성화
        }
    }

    void LateUpdate()
    {
        if (positionsSaved)
        {
            // 주기적으로 복원 작업을 실행
            RestorePositions();
            positionsSaved = false;//추가
        }
    }

    void RestorePositions()
    {
        if (positionsSaved)
        {
            // 저장된 X 위치를 실시간으로 불러와서 적용
            for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
            {
                RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // 기존의 Y, Z 값을 그대로 두고 X 값만 복원
                    Vector3 currentPos = rectTransform.anchoredPosition;
                    currentPos.x = originalPositionsX[i]; // 저장된 X 값으로 복원
                    rectTransform.anchoredPosition = currentPos;
                    Debug.Log("적용된 X 위치 - 자식 " + i + ": " + originalPositionsX[i]);
                }
            }
        }
    }

    /*public void Save()
    {
        //데이터 저장
        Swipe_Win_Data data = new Swipe_Win_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Win.json", jsonData);


        //데이터 저장
        Swipe_Win_Data data1 = new Swipe_Win_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_Win_num.json", jsonData1);
    }*/

    public void Save()
    {
        Swipe_Rev_Data data = new Swipe_Rev_Data
        {
            Scroll = scrollbar.GetComponent<Scrollbar>().value,
            number = btnNumber
        };

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev.json", jsonData);
    }



    private void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    private void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        // scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;



                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    public void GecisiDuzenle()
    {
        // btnNumber가 올바른 범위인지 확인
        if (btnNumber < 0 || btnNumber >= pos.Length)
        {
            Debug.LogError("btnNumber 값이 잘못되었습니다. 올바른 범위로 설정하십시오.");
            return; // 유효하지 않은 경우 함수 종료
        }

        // btnNumber에 해당하는 값으로 스크롤바 위치를 업데이트
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber]; // btnNumber가 0으로 리셋된 상태에서 동작
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

        // 파일 삭제 후 초기화
        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0; // 스크롤바 값을 0으로 초기화
            scroll_pos = 0;
            btnNumber = 0; // 버튼 번호를 0으로 초기화
        }

        if (File.Exists(path1))
        {
            File.Delete(path1);
            btnNumber = 0;
            previousBtnNumber = -1;
        }

        // 파일 삭제 후 Load() 메서드 호출
        Load();

        // Load()가 끝난 후 UI 상태 갱신
        GecisiDuzenle();
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 Swipe_Win_Data 객체로 변환
            Swipe_Rev_Data data = JsonUtility.FromJson<Swipe_Rev_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;
            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);
        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 Swipe_Win_Data 객체로 변환
            Swipe_Rev_Data data1 = JsonUtility.FromJson<Swipe_Rev_Data>(json1);

            btnNumber = data1.number;
            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);
        }
        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }



    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // 스크롤바 초기화
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f); // 첫 번째 오브젝트 확대


    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Swipe_Rev_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_Rev : MonoBehaviour
{

    public Swipe_Win win;

    public Swipe_1_fin swipe_1;

    public GameObject scrollbar, imageContent;
    //public float Scroll_Value = 0.0f;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    //public HorizontalLayoutGroup hor;

    public Button[] btn;//리듬게임 안으로 들어가는 버튼

    public GameObject[] Rev_BGM;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부

    public static Swipe_Rev instance;

    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장

    public void Go_Back()
    {

        

        if (Select_Album.instance.Album[1].activeSelf == true)//레브리가 활성화된 상태인 경우
        {
            

            SFX_Manager.instance.SFX_Button();
            //swipe_1.hor.enabled = true;
            //페이드 인 아웃
            Title_Fade.instance.Fade_Canvas.SetActive(true);
            Title_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

            

            

            StartCoroutine(Go_Game());
            IEnumerator Go_Game()
            {
                yield return new WaitForSeconds(1.4f);
                //다시 선택하는 창으로
                //swipe_1.hor.enabled = true;
                //win.hor.enabled = false;
                //hor.enabled = false;

                swipe_1.btnNumber = 1;
                //swipe_1.Scroll_Value = 0;
                swipe_1.previousBtnNumber = 1;
                swipe_1.scrollbar.GetComponent<Scrollbar>().value = 0.2f;



                StartCoroutine(SetActive_False()); 
                Select_Album.instance.select_Album.SetActive(true);//앨범 선택 활성
                                                                   //나머지 오브젝트 비활성
 

                Select_Album.instance.Select_Song_Btn.SetActive(false);//뒤로가기 비활성
                UI_Button.instance.Piano_Btn.SetActive(true);//앨범 선택 뒤로가기 활성

                Title_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
                //StartCoroutine(SetActive_False());
                for (int i = 0; i < Select_Album.instance.Album.Length; i++)
                {
                    Select_Album.instance.Album[i].SetActive(false);
                }
                Select_Album.instance.BGM.SetActive(true);//테마 선택 BGM 활성화

                
            }

            IEnumerator SetActive_False()
            {
                yield return new WaitForSeconds(1.4f);
                Title_Fade.instance.Fade_Canvas.SetActive(false);
            }

            
        }

        else
        {
            return;
        }

    }


    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;
    }

    void FixedUpdate()
    {
        Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // 스와이프 중에는 소리 재생 방지
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // 조건: 이전 버튼이 0이 아니었고 현재 btnNumber가 0일 때만 소리 재생
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("이전 버튼이 0이 아닐 때 버튼 효과음 실행");
                }
            }
        }

        // 이전 버튼 번호를 업데이트=
        previousBtnNumber = btnNumber;

        ScaleObjects();

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = (i == btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
            Rev_BGM[i].SetActive(i == btnNumber); // 넘버와 같으면 음악 재생, 아니면 비활성화
        }
    }


    public void Save()
    {
        //데이터 저장
        Swipe_Rev_Data data = new Swipe_Rev_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev.json", jsonData);


        //데이터 저장
        Swipe_Rev_Data data1 = new Swipe_Rev_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev_num.json", jsonData1);

    }

    public void Reset()
    {

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("데이터 없음");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "Swipe_Rev_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_Rev_Data data = JsonUtility.FromJson<Swipe_Rev_Data>(json);

            //변환된 객체에서 Sentences_0_Index값을 불러와서 현재 Sentences_0에 저장
            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;//현재 효과음 볼륨을 슬라이더에서 가져와서

        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_Rev_Data data1 = JsonUtility.FromJson<Swipe_Rev_Data>(json1);

            //변환된 객체에서 Sentences_0_Index값을 불러와서 현재 Sentences_0에 저장
            btnNumber = data1.number;//현재 효과음 볼륨을 슬라이더에서 가져와서


        }
        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    private void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    private void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    public void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }

    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // 스크롤바 초기화
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.64f, 0.64f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.4f, 0.4f); // 첫 번째 오브젝트 확대
    }
}*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Rev : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    //private float time;
    //private Button takeTheBtn;
    public int btnNumber;

    //private float distance; // distance를 멤버 변수로 추가

    void Start()
    {
        SetPositions();
        CenterOnStart();


    }

    void Update()
    {


        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;
            }
        }

        ScaleObjects();
    }

    private void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    private void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }



    private void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true; // runIt을 true로 설정하여 부드럽게 중앙으로 이동하도록 함
                break;
            }
        }
    }

    //테스트중(거의 해냈다 ㅜㅠ)
    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        // 선택된 인덱스 찾기
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i; // 선택된 인덱스 저장
                break;
            }
        }

        // 현재 선택된 오브젝트가 확대된 상태인지 확인
        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
        {
            // 중심 오브젝트가 이미 확대된 상태라면 나머지 오브젝트를 즉시 0.4f로 조정
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    // 나머지 오브젝트를 0.4f로 즉시 조정
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return; // Lerp를 사용하지 않도록 중단
        }

        // 선택된 오브젝트 확대 및 나머지 오브젝트 축소
        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                // 현재 선택된 오브젝트 확대
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
            }
            else
            {
                // 나머지 오브젝트를 0.4f로 즉시 조정
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    private void GecisiDuzenle()
    {
        // 스크롤바가 가장 가까운 오브젝트 위치로 즉시 이동
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // 스크롤바가 움직이는 동안 화면 중앙으로 정렬
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();

        // 화면 중앙 좌표 계산
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // Screen 좌표를 UI 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageContent.GetComponent<RectTransform>(),
            screenCenter,
            null,
            out Vector2 localPoint);

        // Content 위치를 화면 중앙에 맞추도록 조정
        selectedChild.anchoredPosition = localPoint;

        runIt = false; // 동작이 완료되면 runIt를 false로 설정
    }

}*/



//가운데 정렬 외에 굿
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Win : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber;

    void Start()
    {
        SetPositions();
        CenterOnStart();
    }

    void Update()
    {
        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;
            }
        }

        ScaleObjects();
    }

    private void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        // 처음부터 레이아웃 그룹이 제대로 반영되도록 강제로 업데이트
        LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
    }

    private void CenterOnStart()
    {
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.45f, 0.45f);
                }
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.45f, 0.45f);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
    }

    private void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageContent.GetComponent<RectTransform>(),
            screenCenter,
            null,
            out Vector2 localPoint);

        selectedChild.anchoredPosition = localPoint;
        runIt = false;
    }
}*/

