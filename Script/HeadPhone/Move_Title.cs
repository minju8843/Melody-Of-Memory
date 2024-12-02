using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Move_Title : MonoBehaviour
{
    public TextMeshProUGUI firstTextPrefab; // 첫 번째 텍스트 프리팹
    public TextMeshProUGUI secondTextPrefab; // 두 번째 텍스트 프리팹
    public RectTransform maskArea; // RectMask2D 범위를 설정한 마스크 영역
    private float speed = 50f; // 텍스트가 움직이는 속도
    public int spaceBetweenTexts = 10; // 텍스트 사이의 공백 (문자 기준)

    public RectTransform firstText;
    public RectTransform secondText;
    private float firstTextWidth;
    private float secondTextWidth;
    private float spacing; // 공백을 실제 거리로 변환한 값

    public void Start()
    {
        // 첫 번째 텍스트 생성
        firstText = Instantiate(firstTextPrefab, maskArea).GetComponent<RectTransform>();
        //오브젝트를 maskArea안에 생성한다
        //firstTextPrefab이라는 프리팹을 복제해서 새로운 인스턴스 생성
        //firstTextPrefab를 생성할 때, maskArea라는 RectTransform을 부모로 지정
        //->내가 마스크한 이미지

        //.GetComponent<RectTransform>();
        // -> 새로 생성된 firstTextPrefab의 RectTransform을 가져옴


        firstText.anchoredPosition = new Vector2(0, 0);
        //처음에는 0,0 위치에 배치한다

        // 두 번째 텍스트 생성
        secondText = Instantiate(secondTextPrefab, maskArea).GetComponent<RectTransform>();
        secondText.anchoredPosition = new Vector2(0, 0);

        // 공백 간격을 텍스트의 폰트 크기 기준으로 설정
        spacing = spaceBetweenTexts * firstTextPrefab.fontSize;
        //공백 수에 폰트 크기를 곱해서 공갭 간격 계산

        // 각 텍스트의 너비 계산
        firstTextWidth = firstText.rect.width;
        secondTextWidth = secondText.rect.width;

        // 두 번째 텍스트를 첫 번째 텍스트 뒤에 배치
        secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        
        //Set_Text();
    }

    public void Set_Text()
    {
        // 첫 번째 텍스트 생성
        //firstText = Instantiate(firstTextPrefab, maskArea).GetComponent<RectTransform>();
        //오브젝트를 maskArea안에 생성한다
        //firstTextPrefab이라는 프리팹을 복제해서 새로운 인스턴스 생성
        //firstTextPrefab를 생성할 때, maskArea라는 RectTransform을 부모로 지정
        //->내가 마스크한 이미지

        //.GetComponent<RectTransform>();
        // -> 새로 생성된 firstTextPrefab의 RectTransform을 가져옴


        firstText.anchoredPosition = new Vector2(0, 0);
        //처음에는 0,0 위치에 배치한다

        // 두 번째 텍스트 생성
        //secondText = Instantiate(secondTextPrefab, maskArea).GetComponent<RectTransform>();
        secondText.anchoredPosition = new Vector2(0, 0);

        // 공백 간격을 텍스트의 폰트 크기 기준으로 설정
        spacing = spaceBetweenTexts * firstTextPrefab.fontSize;
        //공백 수에 폰트 크기를 곱해서 공갭 간격 계산

        // 각 텍스트의 너비 계산
        firstTextWidth = firstText.rect.width;
        secondTextWidth = secondText.rect.width;

        // 두 번째 텍스트를 첫 번째 텍스트 뒤에 배치
        secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);

        //Move_Update();
    }

    /*public void Move_Update()
    {
        // 첫 번째와 두 번째 텍스트 모두 좌측으로 이동
        firstText.anchoredPosition += Vector2.left * speed * Time.deltaTime;
        secondText.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // 첫 번째 텍스트가 마스크 범위를 벗어나면 위치를 재설정
        if (firstText.anchoredPosition.x <= -firstTextWidth - spacing)
        {//firstText.anchoredPosition.x -> 현재 X축의 위치
            //firstTextWidth는 텍스트의 너비

            //-firstTextWidth - spacing->텍스트가 화면 왼쪽 끝을 넘어서 이동한 거리
            //첫 번째 텍스트의 X위치가 왼쪽으로 사라졌는지

            firstText.anchoredPosition = new Vector2(secondText.anchoredPosition.x + secondTextWidth + spacing, 0);
            //화면을 벗어났다면 새로운 위치 설정
            //secondText.anchoredPosition.x -> 두 번째 텍스트의 현재 X위치
            //두 번째 텍스트의 현재 X위치에 두 번째 텍스트의 너비와 공백을 더하여 첫 번째 텍스트가 두 번째 텍스트의 오른쪽에 배치되도록
        }

        // 두 번째 텍스트가 마스크 범위를 벗어나면 위치를 재설정
        if (secondText.anchoredPosition.x <= -secondTextWidth - spacing)
        {
            secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        }
    }*/

    void Update()
    {
        // 첫 번째와 두 번째 텍스트 모두 좌측으로 이동
        firstText.anchoredPosition += Vector2.left * speed * Time.deltaTime;
        secondText.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // 첫 번째 텍스트가 마스크 범위를 벗어나면 위치를 재설정
        if (firstText.anchoredPosition.x <= -firstTextWidth - spacing)
        {//firstText.anchoredPosition.x -> 현재 X축의 위치
            //firstTextWidth는 텍스트의 너비

            //-firstTextWidth - spacing->텍스트가 화면 왼쪽 끝을 넘어서 이동한 거리
            //첫 번째 텍스트의 X위치가 왼쪽으로 사라졌는지

            firstText.anchoredPosition = new Vector2(secondText.anchoredPosition.x + secondTextWidth + spacing, 0);
            //화면을 벗어났다면 새로운 위치 설정
            //secondText.anchoredPosition.x -> 두 번째 텍스트의 현재 X위치
            //두 번째 텍스트의 현재 X위치에 두 번째 텍스트의 너비와 공백을 더하여 첫 번째 텍스트가 두 번째 텍스트의 오른쪽에 배치되도록
        }

        // 두 번째 텍스트가 마스크 범위를 벗어나면 위치를 재설정
        if (secondText.anchoredPosition.x <= -secondTextWidth - spacing)
        {
            secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        }
    }
}
