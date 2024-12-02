using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    // public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public RectTransform content; // Content의 Transform
    private List<float> originalPositionsX = new List<float>(); // X 좌표만 저장
    private bool positionsSaved = false;

    public static Swipe_1_fin instance;




    void Start()
    {
        SetPositions();
        CenterOnStart();

        instance = this;
        Load();

        // 5초 후에 자식 오브젝트들의 X 위치를 저장
        // Invoke("SavePositions", 5f);

        // 1초 후부터 1초 간격으로 RestorePositions() 호출
        //InvokeRepeating("TriggerRestorePositions", 0f, 1f);
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
        //Debug.Log("자식 오브젝트들의 X 위치가 저장되었습니다.");
        //for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
        //{
            //Debug.Log("저장된 X 위치 - 자식 " + i + ": " + originalPositionsX[i]);
        //}
    }


    // LateUpdate()에서 복원 작업 수행
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // 주기적으로 복원 작업을 실행
            RestorePositions();
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
                    //Debug.Log("적용된 X 위치 - 자식 " + i + ": " + originalPositionsX[i]);
                }
            }
        }
    }


    //수정
    void Update()
    {
        if (runIt== true)
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
                   // Debug.Log("이전 버튼이 0이 아닐 때 버튼 효과음 실행");
                    Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


    }


    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

       // Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        //Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }


    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0; // 스크롤바 값을 0으로 초기화
                                                           // 여기서 변수들을 초기화해줍니다.
            scroll_pos = 0;
            btnNumber = 0; // 버튼 번호를 0으로 초기화
            Load(); // 기본 설정을 불러옵니다. (또는 이 부분을 수정하여 리셋 후 새로운 상태로 초기화)
        }

        if (File.Exists(path1))
        {
            File.Delete(path1);
            btnNumber = 0;
            previousBtnNumber = -1;
            Load();
        }
        else
        {
            return;
            //Debug.Log("스와이프 아직 안 들어감");
        }

        // 데이터가 리셋된 후 GecisiDuzenle()를 호출하여 UI 상태를 업데이트합니다.
        GecisiDuzenle();
    }


    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            //Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            //Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            return;
            //파일이 존재하지 않는 경우
            //Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);

    }

    public void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber]; // btnNumber가 0으로 리셋된 상태에서 동작
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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}


//여기 괜찮음. 수정은 위에서
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

   // public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public RectTransform content; // Content의 Transform
    private List<float> originalPositionsX = new List<float>(); // X 좌표만 저장
    private bool positionsSaved = false;

    public static Swipe_1_fin instance;


    //초기화 코드
    public void InitializeValues()
    {
        btnNumber = 0;
        previousBtnNumber = -1;
    }

    void Start()
    {
        SetPositions();
        CenterOnStart();

        instance = null;
        // Load();

        // 5초 후에 자식 오브젝트들의 X 위치를 저장
       // Invoke("SavePositions", 5f);

        // 1초 후부터 1초 간격으로 RestorePositions() 호출
        //InvokeRepeating("TriggerRestorePositions", 0f, 1f);
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


    // LateUpdate()에서 복원 작업 수행
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // 주기적으로 복원 작업을 실행
            RestorePositions();
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


    //수정
    void Update()
    {
        if (runIt)
        {
            GecisiDuzenle();

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

       
    }


    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    public void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public static Swipe_1_fin instance;

    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;

    }





    void Update()
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
                    //Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
        }
    }

    //오후 7시 42분
    public void ArrangeObjectsWithSpacing(float spacing)
    {
        int childCount = imageContent.transform.childCount;
        if (childCount == 0) return;

        // 중심을 기준으로 첫 번째 자식을 가운데 배치
        float centerX = 0;
        RectTransform centerChild = imageContent.transform.GetChild(childCount / 2).GetComponent<RectTransform>();
        centerChild.anchoredPosition = new Vector2(centerX, centerChild.anchoredPosition.y);

        // 가운데를 기준으로 좌측과 우측에 자식 배치
        float currentXLeft = centerX - (centerChild.rect.width / 2) - spacing;
        float currentXRight = centerX + (centerChild.rect.width / 2) + spacing;

        for (int i = (childCount / 2) - 1; i >= 0; i--)
        {
            RectTransform leftChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXLeft -= (leftChild.rect.width / 2);
            leftChild.anchoredPosition = new Vector2(currentXLeft, leftChild.anchoredPosition.y);
            currentXLeft -= (leftChild.rect.width / 2) + spacing;
        }

        for (int i = (childCount / 2) + 1; i < childCount; i++)
        {
            RectTransform rightChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXRight += (rightChild.rect.width / 2);
            rightChild.anchoredPosition = new Vector2(currentXRight, rightChild.anchoredPosition.y);
            currentXRight += (rightChild.rect.width / 2) + spacing;
        }
    }

    //오후 3시 49분 이전거
    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }



    //3시 50분 이전 코드
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // 스크롤 위치와 가장 가까운 버튼을 선택
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

        // 위치가 바뀌면 자식 오브젝트들의 크기 다시 조정
        //ScaleObjects();

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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
        // 스크롤바의 값을 현재 선택된 위치로 설정
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // 선택된 자식 오브젝트를 가져와 중앙에 배치
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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}*/

//기본 세팅
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public static Swipe_1_fin instance;

    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;

    }





    void Update()
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
                    //Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
        }
    }

    //오후 7시 42분
    public void ArrangeObjectsWithSpacing(float spacing)
    {
        int childCount = imageContent.transform.childCount;
        if (childCount == 0) return;

        // 중심을 기준으로 첫 번째 자식을 가운데 배치
        float centerX = 0;
        RectTransform centerChild = imageContent.transform.GetChild(childCount / 2).GetComponent<RectTransform>();
        centerChild.anchoredPosition = new Vector2(centerX, centerChild.anchoredPosition.y);

        // 가운데를 기준으로 좌측과 우측에 자식 배치
        float currentXLeft = centerX - (centerChild.rect.width / 2) - spacing;
        float currentXRight = centerX + (centerChild.rect.width / 2) + spacing;

        for (int i = (childCount / 2) - 1; i >= 0; i--)
        {
            RectTransform leftChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXLeft -= (leftChild.rect.width / 2);
            leftChild.anchoredPosition = new Vector2(currentXLeft, leftChild.anchoredPosition.y);
            currentXLeft -= (leftChild.rect.width / 2) + spacing;
        }

        for (int i = (childCount / 2) + 1; i < childCount; i++)
        {
            RectTransform rightChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXRight += (rightChild.rect.width / 2);
            rightChild.anchoredPosition = new Vector2(currentXRight, rightChild.anchoredPosition.y);
            currentXRight += (rightChild.rect.width / 2) + spacing;
        }
    }

    //오후 3시 49분 이전거
    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }



    //3시 50분 이전 코드
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // 스크롤 위치와 가장 가까운 버튼을 선택
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

        // 위치가 바뀌면 자식 오브젝트들의 크기 다시 조정
        //ScaleObjects();

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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
        // 스크롤바의 값을 현재 선택된 위치로 설정
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // 선택된 자식 오브젝트를 가져와 중앙에 배치
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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public static Swipe_1_fin instance;

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
                    //Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
        }
    }


    //오후 3시 49분 이전거
    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }



    //3시 50분 이전 코드
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        //scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // 스크롤 위치와 가장 가까운 버튼을 선택
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

        // 위치가 바뀌면 자식 오브젝트들의 크기 다시 조정
        ScaleObjects();

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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
        // 스크롤바의 값을 현재 선택된 위치로 설정
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // 선택된 자식 오브젝트를 가져와 중앙에 배치
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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}*/





//위치는 잘 저장되는데 0번 자식 오브젝트를 제외하고 비율에 따른 중앙 위치가 안됨

//11월 16일 오후 5시 5분 이전 코드
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform

    public RectTransform content; // Content의 Transform
    private List<float> originalPositionsX = new List<float>(); // X 좌표만 저장
    private bool positionsSaved = false;



    void Start()
    {
        SetPositions();
        CenterOnStart();


        // Load();

        // 5초 후에 자식 오브젝트들의 X 위치를 저장
        Invoke("SavePositions", 5f);

        // 1초 후부터 1초 간격으로 RestorePositions() 호출
        InvokeRepeating("TriggerRestorePositions", 0f, 1f);
    }


    void SavePositions()
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

    // InvokeRepeating()을 통해 트리거된 RestorePositions() 메서드
    void TriggerRestorePositions()
    {
        if (positionsSaved)
        {
            RestorePositions();
        }
    }

    // LateUpdate()에서 복원 작업 수행
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // 주기적으로 복원 작업을 실행
            RestorePositions();
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

   
    void Update()
    {


        //Save();

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
                    Save();
                }
            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
        }
    }


    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    public void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }



}*/

//24.11.16.오후 4시 30분 이전 코드

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // 버튼 효과음 실행 여부
    public int previousBtnNumber = -1; // 이전 버튼 번호를 저장


    //public RectTransform content; // 스크롤 내용을 담는 RectTransform


    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

    }





    void Update()
    {
      

        //Save();

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
                    Save();
                }

            }
        }

        // 이전 버튼 번호를 업데이트
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber와 같으면 활성화, 아니면 비활성화
        }
    }



    //오후 3시 49분 이전거
    public void Save()
    {
        //데이터 저장
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("저장하는 값이 얼마야!" + data.Scroll);

        //데이터 저장
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("저장하는 숫자가 얼마야!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

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
            Debug.Log("스와이프 아직 안 들어감");
        }
    }



    //3시 50분 이전 코드
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("불러오는 값이 얼마야!" + scrollbar.GetComponent<Scrollbar>().value);

           
        }

        if (File.Exists(path1))
        {
            //파일이 존재하는 경우 파일을 읽어옴
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson을 통해 GameData_Typing객체로 변환한다.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("불러오는 숫자가 뭐야!" + btnNumber);

        }

        else
        {
            //파일이 존재하지 않는 경우
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }


    public void SetPositions()
     {
         pos = new float[transform.childCount];
         float distance = 1f / (pos.Length - 1f);

         for (int i = 0; i < pos.Length; i++)
         {
             pos[i] = distance * i;
         }
     }



    public void CenterOnStart()
    {
        // 첫 번째 자식을 화면 중앙에 배치
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // 첫 번째 자식 오브젝트 크기 조정
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    
    public void CenterOnClosest()
    {
        // 스크롤 위치와 가장 가까운 버튼을 선택
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

        // 위치가 바뀌면 자식 오브젝트들의 크기 다시 조정
        //ScaleObjects();
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
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
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


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
        // 스크롤바의 값을 현재 선택된 위치로 설정
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // 선택된 자식 오브젝트를 가져와 중앙에 배치
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
            child.localScale = new Vector2(0.4f, 0.4f); // 초기 크기 설정
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // 첫 번째 오브젝트 확대
    }


    
}
*/


//이거는 안 쓰는 거

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;

    void Start()
    {
        // 초기화: 0번째 자식 오브젝트를 화면 중앙에 배치하고 크기를 키움
        CenterAndScaleObject(0, new Vector2(0.54f, 0.54f));
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level: " + i);

                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                    }
                }

                // 스크롤바가 가장 가까운 오브젝트 위치로 부드럽게 이동
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 1f * Time.deltaTime);

                // 선택된 오브젝트의 RectTransform 가져오기
                RectTransform selectedChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();

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

                // 중앙에 위치했는지 체크
                if (Vector2.Distance(selectedChild.anchoredPosition, localPoint) < 0.1f)
                {
                    Debug.Log("오브젝트가 중앙에 위치했습니다. 오브젝트 이름: " + selectedChild.name);
                }
            }
        }
    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);
            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            btn.transform.name = ".";
        }
    }

    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }
    }

    // 중앙에 배치하는 메서드 (초기화용)
    private void CenterAndScaleObject(int index, Vector2 scale)
    {
        RectTransform child = imageContent.transform.GetChild(index).GetComponent<RectTransform>();
        child.localScale = scale;

        // 중앙 위치 설정
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageContent.GetComponent<RectTransform>(),
            screenCenter,
            null,
            out Vector2 localPoint);

        child.anchoredPosition = localPoint;
    }
}*/


//무난무난
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_1_fin : MonoBehaviour
{
   public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    //private float time;
    //private Button takeTheBtn;
    public int btnNumber;

    public HorizontalLayoutGroup hor;



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
            if(!Input.GetMouseButton(0) || Input.touchCount == 0)
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
        firstChild.localScale = new Vector2(0.54f, 0.54f);
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
         if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.53f)
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
                 transform.GetChild(i).localScale = new Vector2(0.54f, 0.54f);
                 imageContent.transform.GetChild(i).localScale = new Vector2(0.54f, 0.54f);
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
     }*/

/*private void ScaleObjects()
{
 float distance = 1f / (pos.Length - 1f);
 for (int i = 0; i < pos.Length; i++)
 {
     if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
     {
         // 현재 선택된 오브젝트 확대
         transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);
         imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);

         // 나머지 오브젝트 축소
         for (int j = 0; j < pos.Length; j++)
         {
             if (j != i)
             {
                 imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                 transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
             }
         }
     }
 }


}


private void GecisiDuzenle()
{
// 스크롤바가 가장 가까운 오브젝트 위치로 부드럽게 이동
scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);

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
}*/


//이건 거의 안쓸거

/*public void WhichBtnClicked(Button btn)
{
    btn.transform.name = "clicked";
    for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
    {
        if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
        {
            btnNumber = i;
            takeTheBtn = btn;
            scroll_pos = (pos[btnNumber]);
            runIt = true; // 버튼 클릭 시 runIt를 true로 설정
        }
    }
}*/

//}