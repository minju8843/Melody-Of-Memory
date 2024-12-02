using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//저장 관련
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class Slider_Data
{
    public float Person_1_Like;//레브리 호감도
    public float Person_2_Like;//로티 호감도
    public float Person_3_Like;//수라 호감도
    public float Person_4_Like;//반 호감도
    public float Person_5_Like;//혼 호감도
}


public class Like_Slider : MonoBehaviour
{

    //호감도 관련
    public Slider[] Person_Like_Slider;//호감도 슬라이더
    public float Default_Like = 0f;//기본 호감도

    public TextMeshProUGUI Person_1_text;
    public TextMeshProUGUI Person_2_text;
    public TextMeshProUGUI Person_3_text;
    public TextMeshProUGUI Person_4_text;
    public TextMeshProUGUI Person_5_text;

    public float Current_Person_1;//사람1 호감도
    public float Current_Person_2;//사람2 호감도
    public float Current_Person_3;//사람3 호감도
    public float Current_Person_4;//사람4 호감도
    public float Current_Person_5;//사람5 호감도

    public static Like_Slider instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Load_Like();//호감도 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        Save_Like();
    }

    private void Load_Like()
    {
        //호감도 불러오기
        string path_1 = Application.persistentDataPath + "/Person_1_Like.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Like.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Like.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Like.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Like.json";


        if (File.Exists(path_1))
        {
            //파일이 존재하는 경우 파일을 읽어온다
            string json_1 = File.ReadAllText(path_1);

            Slider_Data data_1 = JsonUtility.FromJson<Slider_Data>(json_1);
            Person_Like_Slider[0].value = data_1.Person_1_Like;

            //Debug.Log("현재 1번 호감도는:" + Person_Like_Slider[0].value);
            Person_1_text.text = "호감도 " + Person_Like_Slider[0].value.ToString() + "%";
        }

        else if(!File.Exists(path_1))
        {
            // 저장된 값이 없을 경우 초기화
            Person_Like_Slider[0].value = 0;
        }

        //2번
        if (File.Exists(path_2))
        {
            //파일이 존재하는 경우 파일을 읽어온다
            string json_2 = File.ReadAllText(path_2);

            Slider_Data data_2 = JsonUtility.FromJson<Slider_Data>(json_2);
            Person_Like_Slider[1].value = data_2.Person_2_Like;

            //Debug.Log("현재 2번 호감도는:" + Person_Like_Slider[1].value);
            Person_2_text.text = "호감도 " + Person_Like_Slider[1].value.ToString() + "%";
        }

        else if (!File.Exists(path_2))
        {
            // 저장된 값이 없을 경우 초기화
            Person_Like_Slider[1].value = 0;
        }

        //3번
        if (File.Exists(path_3))
        {
            //파일이 존재하는 경우 파일을 읽어온다
            string json_3 = File.ReadAllText(path_3);

            Slider_Data data_3 = JsonUtility.FromJson<Slider_Data>(json_3);
            Person_Like_Slider[2].value = data_3.Person_3_Like;

            //Debug.Log("현재 3번 호감도는:" + Person_Like_Slider[2].value);
            Person_3_text.text = "호감도 " + Person_Like_Slider[2].value.ToString() + "%";
        }

        else if (!File.Exists(path_3))
        {
            // 저장된 값이 없을 경우 초기화
            Person_Like_Slider[2].value = 0;
        }

        //4번
        if (File.Exists(path_4))
        {
            //파일이 존재하는 경우 파일을 읽어온다
            string json_4 = File.ReadAllText(path_4);

            Slider_Data data_4 = JsonUtility.FromJson<Slider_Data>(json_4);
            Person_Like_Slider[3].value = data_4.Person_4_Like;

            //Debug.Log("현재 4번 호감도는:" + Person_Like_Slider[3].value);
            Person_4_text.text = "호감도 " + Person_Like_Slider[3].value.ToString() + "%";
        }

        else if (!File.Exists(path_4))
        {
            // 저장된 값이 없을 경우 초기화
            Person_Like_Slider[3].value = 0;
        }

        //5번
        if (File.Exists(path_5))
        {
            //파일이 존재하는 경우 파일을 읽어온다
            string json_5 = File.ReadAllText(path_5);

            Slider_Data data_5 = JsonUtility.FromJson<Slider_Data>(json_5);
            Person_Like_Slider[4].value = data_5.Person_5_Like;

            //Debug.Log("현재 5번 호감도는:" + Person_Like_Slider[4].value);
            Person_5_text.text = "호감도 " + Person_Like_Slider[4].value.ToString() + "%";
        }

        else if (!File.Exists(path_5))
        {
            // 저장된 값이 없을 경우 초기화
            Person_Like_Slider[4].value = 0;
        }
    }

    private void Save_Like()
    {
        //호감도 저장하기
        Slider_Data data_1 = new Slider_Data();
        data_1.Person_1_Like = Person_Like_Slider[0].value;//현재 효과음 볼륨을 슬라이더에서 가져와서

        string jsonData_1 = JsonUtility.ToJson(data_1);

        //JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Person_1_Like.json", jsonData_1);
       /// Debug.Log("현재 1번 호감도는:" + Person_Like_Slider[0].value+"%");

        Person_1_text.text = "호감도 " + Person_Like_Slider[0].value.ToString()+"%";

       //호감도2
        Slider_Data data_2 = new Slider_Data();
        data_2.Person_2_Like = Person_Like_Slider[1].value;//현재 효과음 볼륨을 슬라이더에서 가져와서

        string jsonData_2 = JsonUtility.ToJson(data_2);

        //JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Person_2_Like.json", jsonData_2);
        //Debug.Log("현재 2번 호감도는:" + Person_Like_Slider[1].value + "%");
        
        Person_2_text.text = "호감도 " + Person_Like_Slider[1].value.ToString() + "%";

        //호감도3
        Slider_Data data_3 = new Slider_Data();
        data_3.Person_3_Like = Person_Like_Slider[2].value;//현재 효과음 볼륨을 슬라이더에서 가져와서

        string jsonData_3 = JsonUtility.ToJson(data_3);

        //JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Person_3_Like.json", jsonData_3);
        //Debug.Log("현재 3번 호감도는:" + Person_Like_Slider[2].value + "%");

        Person_3_text.text = "호감도 " + Person_Like_Slider[2].value.ToString() + "%";


        //호감도4
        Slider_Data data_4 = new Slider_Data();
        data_4.Person_4_Like = Person_Like_Slider[3].value;//현재 효과음 볼륨을 슬라이더에서 가져와서

        string jsonData_4 = JsonUtility.ToJson(data_4);

        //JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Person_4_Like.json", jsonData_4);
        //Debug.Log("현재 4번 호감도는:" + Person_Like_Slider[3].value + "%");

        Person_4_text.text = "호감도 " + Person_Like_Slider[3].value.ToString() + "%";

        //호감도5
        Slider_Data data_5 = new Slider_Data();
        data_5.Person_5_Like = Person_Like_Slider[4].value;//현재 효과음 볼륨을 슬라이더에서 가져와서

        string jsonData_5 = JsonUtility.ToJson(data_1);

        //JSON문자열로 변환
        File.WriteAllText(Application.persistentDataPath + "/Person_5_Like.json", jsonData_5);
        //Debug.Log("현재 5번 호감도는:" + Person_Like_Slider[4].value + "%");

        Person_5_text.text = "호감도 " + Person_Like_Slider[4].value.ToString() + "%";
    }

    public void Reset_Likes()
    {
        string path_1 = Application.persistentDataPath + "/Person_1_Like.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Like.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Like.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Like.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Like.json";


        if (File.Exists(path_1))
        {
            File.Delete(path_1);

            Person_Like_Slider[0].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_2))
        {
            File.Delete(path_2);

            Person_Like_Slider[1].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_3))
        {
            File.Delete(path_3);

            Person_Like_Slider[2].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_4))
        {
            File.Delete(path_4);

            Person_Like_Slider[3].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_5))
        {
            File.Delete(path_5);

            Person_Like_Slider[4].value = Default_Like;
            Load_Like();
        }

        else
        {
            Debug.Log("삭제할 타이핑 데이터 없음");
        }
    }
}
