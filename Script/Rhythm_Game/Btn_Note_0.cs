using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Btn_Note_0 : MonoBehaviour
{
    //public static Note_Btn_0 instance;
    //public BoxCollider2D col_0;

    // public RectTransform[] button;

    public GameObject[] Line_0_Note;
    public Note_1105[] Line_0;

    public Long_Col[] Long_fin_0;//롱노트 끝부분
    public Long_Note[] Long_Note_0;
    public RectTransform[] Long_Note_0_Rect;

    public GameObject[] Line_1_Note;
    public Note_1105[] Line_1;

    public Long_Col[] Long_fin_1;//롱노트 끝부분
    public Long_Note[] Long_Note_1;
    public RectTransform[] Long_Note_1_Rect;

    public GameObject[] Line_2_Note;
    public Note_1105[] Line_2;

    public Long_Col[] Long_fin_2;//롱노트 끝부분
    public Long_Note[] Long_Note_2;
    public RectTransform[] Long_Note_2_Rect;

    public GameObject[] Line_3_Note;
    public Note_1105[] Line_3;

    public Long_Col[] Long_fin_3;//롱노트 끝부분
    public Long_Note[] Long_Note_3;
    public RectTransform[] Long_Note_3_Rect;

    public GameObject[] Line_4_Note;
    public Note_1105[] Line_4;

    public Long_Col[] Long_fin_4;//롱노트 끝부분
    public Long_Note[] Long_Note_4;
    public RectTransform[] Long_Note_4_Rect;

    public GameObject[] Line_5_Note;
    public Note_1105[] Line_5;

    public Long_Col[] Long_fin_5;//롱노트 끝부분
    public Long_Note[] Long_Note_5;
    public RectTransform[] Long_Note_5_Rect;//롱노트 흰색 위치 -> 0823 이펙트가 안 없어지는 문제 때문에

    //public GameObject[] Long_fin_4_Long_Note;//롱노트 흰색
    

    //public GameObject[] Line_5_Long_Note;//롱노트 흰색
    




    

    //public Transform[] Long_Note_5_Tran;

    //public GameObject[] Long_fin_5_Long_Note;//롱노트 흰색


    public bool Line_0_Touch = false;
    public bool Line_1_Touch = false;
    public bool Line_2_Touch = false;
    public bool Line_3_Touch = false;
    public bool Line_4_Touch = false;
    public bool Line_5_Touch = false;

    public static Btn_Note_0 instance;



    //1108
    public GameObject btn0;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;



    void Start()
    {
        instance = this;
        Input.multiTouchEnabled = true;  // 멀티터치 활성화

        //// 초기 상태 설정
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            buttonPressed[i] = false;
        }
    }

    private void Awake()
    {
        Input.multiTouchEnabled = true;  // 멀티터치 활성화
    }

    public List<GameObject> buttons; // 여러 버튼을 처리하기 위해 List<GameObject> 사용


    private bool[] buttonPressed = new bool[6]; // 6개의 버튼 (Btn_0 ~ Btn_5)



    // 버튼 터치 시작
    public void OnButtonDown(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonPressed.Length)
        {
            buttonPressed[buttonIndex] = true;
            Debug.Log($"Button {buttonIndex} Down");
            HandleButtonPress(buttonIndex, true);
        }
    }

    // 버튼 터치 종료
    public void OnButtonUp(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonPressed.Length)
        {
            buttonPressed[buttonIndex] = false;
            Debug.Log($"Button {buttonIndex} Up");
            HandleButtonPress(buttonIndex, false);
        }
    }

    // 버튼 상태 처리 (기존 동작을 연결)
    private void HandleButtonPress(int buttonIndex, bool isPressed)
    {
        switch (buttonIndex)
        {
            case 0:
                if (isPressed) Btn_0_Down();
                else Btn_0_Up();
                break;
            case 1:
                if (isPressed) Btn_1_Down();
                else Btn_1_Up();
                break;
            case 2:
                if (isPressed) Btn_2_Down();
                else Btn_2_Up();
                break;
            case 3:
                if (isPressed) Btn_3_Down();
                else Btn_3_Up();
                break;
            case 4:
                if (isPressed) Btn_4_Down();
                else Btn_4_Up();
                break;
            case 5:
                if (isPressed) Btn_5_Down();
                else Btn_5_Up();
                break;
        }
    }







    /*private bool isBtn0Pressed = false;
    private bool isBtn1Pressed = false;
    private bool isBtn2Pressed = false;
    private bool isBtn3Pressed = false;
    private bool isBtn4Pressed = false;
    private bool isBtn5Pressed = false;

    private bool[] buttonTouched = new bool[6];
    private bool[] buttonTouchStarted = new bool[6];
    */


    /* void Update()
     {
         if (Input.touchCount > 0) // 터치가 있을 때
         {
             for (int i = 0; i < Input.touchCount; i++)
             {
                 Touch touch = Input.GetTouch(i);
                 Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                 // 각 버튼에 대해 터치 시작 및 종료 체크
                 for (int j = 0; j < buttons.Count && j < 6; j++) // 버튼이 6개 이내인 경우에만 확인
                 {
                     if (IsTouchingButton(buttons[j], touchPosition))
                     {
                         if (touch.phase == TouchPhase.Began)
                         {
                             buttonTouchStarted[j] = true; // 해당 버튼에 대한 터치 시작됨
                             Debug.Log($"{j}번째 버튼 터치 시작되었습니다.");
                         }
                         else if (touch.phase == TouchPhase.Ended)
                         {
                             buttonTouched[j] = true; // 해당 버튼에 대한 터치 종료됨
                             Debug.Log($"{j}번째 버튼 터치 종료되었습니다.");
                         }
                     }
                 }
             }
         }
     }

     // 터치가 해당 버튼에 포함되는지 확인하는 메서드
     bool IsTouchingButton(GameObject button, Vector2 touchPosition)
     {
         Collider2D buttonCollider = button.GetComponent<Collider2D>();
         if (buttonCollider != null)
         {
             return buttonCollider.OverlapPoint(touchPosition);
         }
         return false;
     }

     // 버튼 터치 시작 여부를 반환하는 메서드 (원하는 버튼 번호의 상태를 확인)
     public bool IsButtonTouchStarted(int buttonIndex)
     {
         if (buttonIndex >= 0 && buttonIndex < buttonTouchStarted.Length)
         {
             return buttonTouchStarted[buttonIndex];
         }
         return false;
     }

     // 버튼 터치 종료 여부를 반환하는 메서드 (원하는 버튼 번호의 상태를 확인)
     public bool IsButtonTouched(int buttonIndex)
     {
         if (buttonIndex >= 0 && buttonIndex < buttonTouched.Length)
         {
             return buttonTouched[buttonIndex];
         }
         return false;
     }*/



    //분명 멀티 터치 잘 되었던 것 같은데, 잘 안됨
    /*void Update()
    {
        int i = 0;
        Debug.Log("현재 터치 몇개: " + Input.touchCount); // 현재 터치 개수를 출력하여 디버그

        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                //Debug.Log("Touch began - FingerId: " + t.fingerId);

                // 각 버튼에 대해 터치가 영역 내에 있는지 확인
                foreach (GameObject button in buttons)
                {
                    if (IsTouchInsideButton(button, t))
                    {
                        // 터치한 버튼이 0번 버튼인지 확인
                        if (button == buttons[0] && t.fingerId == 0)
                        {
                            isBtn0Pressed = true;
                            ExecuteButtonFunction(button, t.fingerId); // 0번 버튼 눌림 동작
                        }
                        else if (button != buttons[0]) // 0번 버튼이 아닌 다른 버튼인 경우
                        {
                            isBtn0Pressed = false;
                            ExecuteButtonFunction(button, t.fingerId); // 다른 버튼 동작
                        }


                    }
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
               // Debug.Log("Touch ended - FingerId: " + t.fingerId);
                isBtn0Pressed = false;  // 터치가 종료될 때 0번 버튼 상태 초기화
            }

            i++;
        }
    }

    bool IsTouchInsideButton(GameObject button, Touch touch)
    {
        // 버튼의 RectTransform을 가져와서 터치 위치와 비교
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        return buttonRect.rect.Contains(buttonRect.InverseTransformPoint(touch.position));
    }

    // 버튼이 눌렸을 때 호출되는 함수
    void ExecuteButtonFunction(GameObject button, int fingerId)
    {
        // 터치한 버튼과 fingerId에 따라 다른 기능을 실행
        switch (fingerId)
        {
            case 0:
                break;

            case 1:
                Btn_1_Down();
                break;

            case 2:
                Btn_2_Down();
                break;

            case 3:
                Btn_3_Down();
                break;

            case 4:
                Btn_4_Down();
                break;

            case 5:
                Btn_5_Down();
                break;

        }
    }*/

    /*public List<GameObject> buttons;  // 버튼 목록 (각 버튼에 대한 GameObject)

    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                // 터치가 시작된 위치가 버튼 영역 내에 있는지 체크
                CheckButtonPress(t);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("touch ended");
                // 터치가 종료되었을 때의 처리 (필요 시 추가 기능 작성 가능)
            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("touch is moving");
                // 터치가 이동 중일 때의 처리 (필요 시 추가 기능 작성 가능)
            }

            ++i;
        }
    }

    // 터치 위치를 UI 화면 좌표로 변환
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return touchPosition;  // UI에서 사용하는 좌표는 Screen space 그대로 사용
    }

    // 터치가 버튼 영역 내에 있는지 체크하고, 버튼의 기능을 실행
    void CheckButtonPress(Touch t)
    {
        Vector2 touchPosition = getTouchPosition(t.position);

        // 각 버튼에 대해서 터치 위치가 해당 버튼의 Collider2D 영역 내에 있는지 확인
        foreach (var button in buttons)
        {
            Collider2D buttonCollider = button.GetComponent<Collider2D>();
            if (buttonCollider.OverlapPoint(touchPosition))
            {
                // 버튼을 눌렀을 때 실행할 기능을 호출
                ExecuteButtonFunction(button);
            }
        }
    }

    // 버튼을 눌렀을 때 실행할 기능
    void ExecuteButtonFunction(GameObject button)
    {
        // 버튼에 맞는 기능을 여기에 작성
        // 예시로 버튼 이름을 출력하는 기능:
        Debug.Log(button.name + " pressed");
    }*/


    /*private void Update()
    {
        // 터치가 있을 경우에만 처리
        if (Input.touchCount > 0)
        {
            // 모든 터치를 순차적으로 처리
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // 터치 위치를 월드 좌표로 변환
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // 터치의 상태에 따라 버튼 처리
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // 터치가 시작될 때, 각 버튼의 영역에 터치가 포함되어 있는지 확인
                        HandleTouchBegin(touchPosition);
                        break;



                    case TouchPhase.Ended:
                        // 터치가 끝났을 때, 터치 종료 처리
                        HandleTouchEnd(touchPosition);
                        break;
                }
            }
        }
    }

    private void HandleTouchBegin(Vector2 touchPosition)
    {
        if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_0_Down();
        }

        if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_1_Down();
        }

        if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_2_Down();
        }

        if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_3_Down();
        }

        if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_4_Down();
        }

        if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_5_Down();
        }
    }

    private void HandleTouchEnd(Vector2 touchPosition)
    {
        if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_0_Up();
        }

        if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_1_Up();
        }

        if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_2_Up();
        }

        if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_3_Up();
        }

        if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_4_Up();
        }

        if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_5_Up();
        }
    }*/

    //1108
    /*private void Update()
     {
         for (int i = 0; i < Input.touchCount; i++)
         {
             Touch touch = Input.GetTouch(i);

             if (touch.phase == TouchPhase.Began)
             {
                 // 터치 위치를 월드 좌표로 변환
                 Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                 // 각 버튼의 Collider를 가져와서 터치 위치가 해당 버튼 영역 안에 있는지 확인
                 if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_0_Down(); // Btn_4_Down 호출
                 }

                 if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_1_Down(); // Btn_5_Down 호출
                 }

                 if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_2_Down(); // Btn_5_Down 호출
                 }

                 if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_3_Down(); // Btn_5_Down 호출
                 }

                 if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_4_Down(); // Btn_5_Down 호출
                 }

                 if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_5_Down(); // Btn_5_Down 호출
                 }
             }
         }
     }//1108
    */


    public void Btn_0_Down()
    {

        for (int i = 0; i < Line_0.Length; i++)
        {
            Line_0[i].Button_0_Pressed = true;
        }

        for (int i = 0; i < Long_Note_0.Length; i++)
        {

            Long_Note_0[i].Button_0_Pressed = true;

        }

        for (int i = 0; i < Long_fin_0.Length; i++)
        {

            Long_fin_0[i].Button_0_Pressed = true;

        }

        //Debug.Log("0 내림");

    }

    public void Btn_0_Up()
    {
      

        //마스크 비활성화
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_0_Note.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_Note_0.Length; i++)
        {

            Long_Note_0[i].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_fin_0.Length; i++)
        {

            

            Long_fin_0[i].Button_0_Pressed = false;


        }

        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag5 = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag5)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }

        GameObject[] objectsWithTag6 = GameObject.FindGameObjectsWithTag("Note_Effect0");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag6)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        //Debug.Log("5올림");
    }



    public void Btn_1_Down()
    {

        for (int i = 0; i < Line_1.Length; i++)
        {
            Line_1[i].Button_1_Pressed = true;
        }

        for (int i = 0; i < Long_Note_1.Length; i++)
        {

            Long_Note_1[i].Button_1_Pressed = true;

        }

        for (int i = 0; i < Long_fin_1.Length; i++)
        {

            Long_fin_1[i].Button_1_Pressed = true;

        }

       // Debug.Log("1 내림");

    }

    public void Btn_1_Up()
    {
        //마스크 비활성화
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_1_Note.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
        }

        for (int i = 0; i < Long_Note_1.Length; i++)
        {

            Long_Note_1[i].Button_1_Pressed = false;
        }

        for (int i = 0; i < Long_fin_1.Length; i++)
        {



            Long_fin_1[i].Button_1_Pressed = false;


        }

        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect1");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        //Debug.Log("5올림");
    }

    //2
    public void Btn_2_Down()
    {

        for (int i = 0; i < Line_2.Length; i++)
        {
            Line_2[i].Button_2_Pressed = true;
        }

        for (int i = 0; i < Long_Note_2.Length; i++)
        {

            Long_Note_2[i].Button_2_Pressed = true;

        }

        for (int i = 0; i < Long_fin_2.Length; i++)
        {

            Long_fin_2[i].Button_2_Pressed = true;

        }

        //Debug.Log("2 내림");

    }

    public void Btn_2_Up()
    {
 

        //마스크 비활성화
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_2_Note.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
        }

        for (int i = 0; i < Long_Note_2.Length; i++)
        {

            Long_Note_2[i].Button_2_Pressed = false;
        }

        for (int i = 0; i < Long_fin_2.Length; i++)
        {

            Long_fin_2[i].Button_2_Pressed = false;


        }

        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }

        GameObject[] objectsWithTag3 = GameObject.FindGameObjectsWithTag("Note_Effect2");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag3)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        //Debug.Log("2올림");
    }

    //3
    public void Btn_3_Down()
    {

        for (int i = 0; i < Line_3.Length; i++)
        {
            Line_3[i].Button_3_Pressed = true;
        }

        for (int i = 0; i < Long_Note_3.Length; i++)
        {

            Long_Note_3[i].Button_3_Pressed = true;

        }

        for (int i = 0; i < Long_fin_3.Length; i++)
        {

            Long_fin_3[i].Button_3_Pressed = true;

        }

       // Debug.Log("3 내림");

    }

    public void Btn_3_Up()
    {
        //마스크 비활성화
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_3_Note.Length; j++)
        {
            Line_3[j].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_Note_3.Length; i++)
        {

            Long_Note_3[i].Button_3_Pressed = false;
        }

        for (int i = 0; i < Long_fin_3.Length; i++)
        {



            Long_fin_3[i].Button_3_Pressed = false;


        }

        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect3");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        //Debug.Log("5올림");
    }

    public void Btn_4_Down()
    {

        for (int i = 0; i < Line_4.Length; i++)
        {
            Line_4[i].Button_4_Pressed = true;
        }

        for (int i = 0; i < Long_Note_4.Length; i++)
        {

            Long_Note_4[i].Button_4_Pressed = true;

        }

        for (int i = 0; i < Long_fin_4.Length; i++)
        {

            Long_fin_4[i].Button_4_Pressed = true;

        }
        //Debug.Log("4내림");
    }

    public void Btn_4_Up()
    {
        //마스크 비활성화
        //Manager_0..instance.Long_Line_Mask[4].enabled = false;

        for (int j = 0; j < Line_4_Note.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
        }

        for (int i = 0; i < Long_Note_4.Length; i++)
        {

            Long_Note_4[i].Button_4_Pressed = false;
        }

        for (int i = 0; i < Long_fin_4.Length; i++)
        {

            //만약 이펙트가 있었따면
           /* GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

            foreach (GameObject obj in objectsWithTag)
            {
                //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
                Destroy(obj);
            }*/

            Long_fin_4[i].Button_4_Pressed = false;


        }

        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect4");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }
    }

    //5
    public void Btn_5_Down()
    {

        for (int i = 0; i < Line_5.Length; i++)
        {
            Line_5[i].Button_5_Pressed = true;
        }

        for (int i = 0; i < Long_Note_5.Length; i++)
        {

            Long_Note_5[i].Button_5_Pressed = true;

        }

        for (int i = 0; i < Long_fin_5.Length; i++)
        {

            Long_fin_5[i].Button_5_Pressed = true;

        }

        //Debug.Log("5 내림");

    }

    public void Btn_5_Up()
    {
        //마스크 비활성화
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_5_Note.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
        }

        for (int i = 0; i < Long_Note_5.Length; i++)
        {

            Long_Note_5[i].Button_5_Pressed = false;
        }

        for (int i = 0; i < Long_fin_5.Length; i++)
        {

            //만약 이펙트가 있었따면
           /* GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

            foreach (GameObject obj in objectsWithTag)
            {
                //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
                Destroy(obj);
            }*/

            Long_fin_5[i].Button_5_Pressed = false;


        }
        //만약 이펙트가 있었따면
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect5");//Hierarchy내에서 오브젝트 찾기

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5태그를 가진 오브젝트가 있으면 삭제한다.
            Destroy(obj);
        }


        //Debug.Log("5올림");
    }



}
