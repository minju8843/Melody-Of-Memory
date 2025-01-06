using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]//JsonUtility�� ����Ͽ� JSON�������� ��ȯ�Ϸ���
//��ü�� Serializable�ؾ� ��.

public class Pro_Typing_Data
{
    //������ ���� ���� Ŭ����
    public int Sentences_0_Index;//�� ��° ��������
    public int Bg_0_Index;//�� ��° �������
}

public class Pro_Typing : MonoBehaviour
{
    public Animator Open_Eye;//���� ���� �ִϸ��̼�
    public Animator Disappera_Rev;//���긮 ����� �ִϸ��̼�

    public GameObject Pro_Win;//���ѷα׿� ���Ǵ� ����
    public GameObject Rev;//���긮 ��Ʈ

    public static Pro_Typing instance;

   // public Button btn;//��ǳ�� ��ư Ȱ��/��Ȱ���� ����

    public GameObject Dia;//��ǳ�� �ִ� ��
    public GameObject Inside_Dia;//��ȭâ�� ǥ�õ� TMP(Ȱ��, ��Ȱ���� ����)

    public TextMeshProUGUI dialogueText;//��ȭâ�� ǥ�õ� TMP
    public string[] sentences_str_0;//ǥ�õ� �����

    public GameObject[] Name;//ĳ���� �̸�
    public GameObject[] Ch;//ĳ���� ���� �� ȭ�鿡 ������ �̹���

   // public GameObject Arrow;//���� â �ؿ� ȭ��ǥ

    //���� ������ ����Ǿ�����
    public int Default_Sentences_0 = 0;//������ �� ����
    public int Sentences_0;//���� ������ �� ��°����

    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����
    public bool isTyping = false; // Ÿ���� ������ ����

    //���� ī�޶�
    public GameObject Winter_Camera;

    //���� ī�޶� �ƴ� ���ѷα� ī�޶� + ������ ����
    public GameObject Pro_Camera;

    //��Ʈ�ѷ� �� Ž�� ��ư
    public GameObject Controller;
    public GameObject Serch_Btn;

    public GameObject OutSide_Map;//�ۿ� �ܿ� ǳ�� ����(�÷��̾� ���ƴٴϴ� ��)

    public void OnEnable()
    {
        //Ȱ��ȭ�� ��, �ҷ�����
        //Load_Sentences_0();
    }

    public void Start()
    {
        instance = this;

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        //�ҷ�����
       

        Load_Sentences_0();
        Debug.Log("�ҷ���");

    }

    public void FixedUpdate()
    {
        if (Typing.instance.Sentences_0 >= 142)//������ ���ѷα� ��簡 �� ���� �ڿ� ���;� ��
        {
            //21 -> ���� ��
            if (Sentences_0 == 0)//���ѷα� ��簡 �� �������鼭 0�� ���
            {
               Controller.SetActive(false);//��Ʈ�ѷ� ��Ȱ��
                Serch_Btn.SetActive(false);//Ž�� ��ư ��Ȱ��
                OutSide_Map.SetActive(true);//�� ���� Ȱ��

                Pro_Camera.SetActive(true);//é��1 ���ѷα� ī�޶� Ȱ��
                Winter_Camera.SetActive(false);//é��1 ���� ī�޶� ��Ȱ��

                Pro_Win.SetActive(true);
                Rev.SetActive(true);

                Open_Eye.SetTrigger("Close_Eye");
                Disappera_Rev.SetTrigger("Normal");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[0].SetActive(true);

            }

            if (Sentences_0 == 8 || Sentences_0 == 24 || Sentences_0 == 41)//���ѷα� ��簡 �� �������鼭 0�� ���
            {

                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[0].SetActive(true);

            }

            //3-1
            if (Sentences_0 == 1 || Sentences_0 == 33)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[1].SetActive(true);

            }

            //2-1
            if (Sentences_0 == 2)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[2].SetActive(true);

            }

            //4-1
            if (Sentences_0 == 3 || Sentences_0 == 39)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[3].SetActive(true);

            }

            //���긮
            if (Sentences_0 == 4 || Sentences_0 == 5
                || Sentences_0 == 9 || Sentences_0 == 10
                || Sentences_0 == 12
                || Sentences_0 == 16 || Sentences_0 == 17
                || (Sentences_0 >= 19 && Sentences_0 <= 23)
                 || (Sentences_0 >= 27 && Sentences_0 <= 31)
                  || (Sentences_0 >= 34 && Sentences_0 <= 38))
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[1].SetActive(true);//���긮

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[15].SetActive(true);

            }

            //5-1
            if (Sentences_0 == 6 || Sentences_0 == 32)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[4].SetActive(true);

            }

            //6
            if (Sentences_0 == 7)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[6].SetActive(true);

            }

            //18
            if (Sentences_0 == 11)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[6].SetActive(true);

            }

            //26
            if (Sentences_0 == 13)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[7].SetActive(true);

            }

            //12
            if (Sentences_0 == 14)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[8].SetActive(true);

            }

            //13
            if (Sentences_0 == 15)
            {

                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.
                Open_Eye.SetTrigger("Open_Eye");

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[9].SetActive(true);

            }

            //5
            if (Sentences_0 == 18)
            {
                Open_Eye.SetTrigger("Open_Eye");
                //Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[10].SetActive(true);

            }

            //19
            if (Sentences_0 == 25 || Sentences_0 == 42)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[11].SetActive(true);

            }

            //29
            if (Sentences_0 == 26)
            {
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                // btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
                }

                Ch[12].SetActive(true);

            }

            //22
            if (Sentences_0 == 40)
            {
                Rev.SetActive(false);
                Open_Eye.SetTrigger("Open_Eye");
                // Dream_Manager.instance.dream_y_n = 1;//���� �޼������� ���ѷα��Դϴ�.

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i].SetActive(false);
                }
                Name[0].SetActive(true);//���ΰ�

                //Arrow.SetActive(true);//ȭ��ǥ Ȱ��ȭ
                //btn.enabled = true;//��ư ���� �� �ֵ���


                for (int i = 0; i < Ch.Length; i++)
                {
                    Ch[i].SetActive(false);//ĳ���� ��Ȱ��ȭ
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
        //->����Ǵ� ��ġ ������

      //  Save_Text.text = Application.persistentDataPath.ToString();
    }


    public void Save_Sentences_BG()//�� ��° ������ ���Դ��� ����
    {
        Pro_Typing_Data data = new Pro_Typing_Data();
        data.Sentences_0_Index = Sentences_0;//������ Sentens_0���� �Ҵ�
        string json = JsonUtility.ToJson(data);//JsonUtility.ToJson�� �����
        //GameData_Typing��ü�� JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Pro_Typing.json", json);
        //WriteAllText�� ����� ��ȯ�� JSON���ڿ��� Application.persistentDataPath��ο� �ִ�
        //Typing.json���Ϸ� ����.

        //  Debug.Log("Ÿ���� ����");

        //��� ���� -> ���� �� �ʿ䰡 �� ���̱� ��
    }

    public void Load_Sentences_0()
    {
        //���� �ҷ�����
        string path = Application.persistentDataPath + "/Pro_Typing.json";
        //Typing.json��� ������ �����ϴ��� Ȯ��

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Pro_Typing_Data data = JsonUtility.FromJson<Pro_Typing_Data>(json);

            //��ȯ�� ��ü���� Sentences_0_Index���� �ҷ��ͼ� ���� Sentences_0�� ����
            Sentences_0 = data.Sentences_0_Index;




            if (Sentences_0 > 0 && (Typing.instance.Sentences_0 >= 142) && Sentences_0 != 43 && Sentences_0 != 44 && Sentences_0 != 45) 
            {

                Pro_Camera.SetActive(true);//é��1 ���ѷα� ī�޶� Ȱ��
                Winter_Camera.SetActive(false);//é��1 ���� ī�޶� ��Ȱ��

                Controller.SetActive(false);//��Ʈ�ѷ� ��Ȱ��
                Serch_Btn.SetActive(false);//Ž�� ��ư ��Ȱ��
                OutSide_Map.SetActive(true);//�� ���� Ȱ��

                //���� ������ ����� ������ ��Ȱ��
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

                Pro_Win.SetActive(false);//���ѷα� ���� ��Ȱ��
                Rev.SetActive(false);//���ѷα� ���긮 ��Ȱ��

                Serch_Btn.SetActive(true);
                Controller.SetActive(true);
                Winter_Camera.SetActive(true);//é��1 ī�޶����� ����
                //���ѷα� ���丮 ī�޶� ��Ȱ��
                Pro_Camera.SetActive(false);

                Dia.SetActive(false);//���丮 ��ȭâ ��Ȱ��
            }

            

           if (Sentences_0 == 0 && (Typing.instance.Sentences_0 >=142))
            {
                Pro_Camera.SetActive(true);//é��1 ���ѷα� ī�޶� Ȱ��
                Winter_Camera.SetActive(false);//é��1 ���� ī�޶� ��Ȱ��

                //���� ������ ����� ������ ��Ȱ��
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
                //�޸���� ������ ���� Ȱ��ȭ
              
            }

           
        }

        else
        {
            //������ �������� �ʴ� ���
            //Debug.Log("����� ���� �����Ͱ� �����ϴ�.");

            if (Sentences_0 == 0 && (Typing.instance.Sentences_0 >= 142))
            {
                //���� ������ ����� ������ ��Ȱ��
                UI_Button.instance.Map.SetActive(false);
                UI_Button.instance.HeadPhone.SetActive(false);

                StartCoroutine(Wait_First_Sentence());
                IEnumerator Wait_First_Sentence()
                {
                    yield return new WaitForSeconds(1.3f);
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    Debug.Log("������ �������� �ʾƼ� �����");
                    StartTyping();
                }

               Controller.SetActive(false);//��Ʈ�ѷ� ��Ȱ��
                Serch_Btn.SetActive(false);//Ž�� ��ư ��Ȱ��
                OutSide_Map.SetActive(true);//�� ���� Ȱ��
            }
        }
    }

   

    //������ ������ �����ϴ� �ڵ�
    public void Delete_Typing_Data()
    {
        string path = Application.persistentDataPath + "/Pro_Typing.json";

        if (File.Exists(path))
        {//������ �����ϴ� ���

            File.Delete(path);

            //�ʱ�ȭ ���� ����
            Sentences_0 = Default_Sentences_0;

            Dia.SetActive(false);
            Inside_Dia.SetActive(false);
            Save_Sentences_BG();//0105�߰�

            Load_Sentences_0();

            Winter_Camera.SetActive(false);
            Pro_Camera.SetActive(true);

            Rev.SetActive(true);
            Pro_Win.SetActive(true);//���ѷα� ���� Ȱ��

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);//ĳ���� �̹��� ��Ȱ��ȭ
            }

        }
        else
        {
            //return;
            Debug.Log("������ Ÿ���� ������ ����");
        }
    }


    //Ÿ���� ���� �ڵ� ����
    public void Next_Text()
    {

        Controller.SetActive(false);//��Ʈ�ѷ� ��Ȱ��
        Serch_Btn.SetActive(false);//Ž�� ��ư ��Ȱ��
        OutSide_Map.SetActive(true);//�� ���� Ȱ��

        //Load_Sentences_0();

        if (isTyping)
        {
            //Ÿ���� ���� ��, Ÿ������ �ϼ���Ų��.
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
        //sentences_str_0�迭���� Sentences_0�� �ִ� ������ ����
        //�� ������ TypSentence()�� �����Ͽ� �ڷ�ƾ ����


    }

    public void NextSentence()
    {
        //���� ������ �������� �ϴ� ��
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
                    //�޸���� ������ ���� Ȱ��ȭ
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
                                                                  //�ٽ� ���� ��ư
                    Serch_Btn.SetActive(true);
                    Controller.SetActive(true);
                    Winter_Camera.SetActive(true);
                    //���ѷα� ���丮 ī�޶� ��Ȱ��
                    Pro_Camera.SetActive(false);

                    Dia.SetActive(false);//���丮 ��ȭâ ��Ȱ��
                    StartCoroutine(Go_Empty());

                }


                IEnumerator Go_Empty()
                {
                    yield return new WaitForSecondsRealtime(0.7f);
                    Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

                    Debug.Log("���̵� �ƿ� �Ƕ��5");
                    StartCoroutine(SetActive_False());
                }



                IEnumerator SetActive_False()
                {
                    yield return new WaitForSecondsRealtime(1.4f);

                    Rhythm_Fade.instance.Fade.SetActive(false);
                    Debug.Log("���̵� �ƿ� �Ƕ��");

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
            // Debug.Log("��ȭ ����");

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
                                                                  //�ٽ� ���� ��ư
                    Pro_Win.SetActive(false);//���ѷα� ���� ��Ȱ��
                    Rev.SetActive(false);

                    Serch_Btn.SetActive(true);
                    Controller.SetActive(true);
                    Winter_Camera.SetActive(true);//������ ���� + ī�޶� Ȱ��
                    //���ѷα� ���丮 ī�޶� ��Ȱ��
                    Pro_Camera.SetActive(false);
                    Dia.SetActive(false);//���丮 ��ȭâ ��Ȱ��

                    StartCoroutine(Go_Empty());

                }


                IEnumerator Go_Empty()
                {
                    yield return new WaitForSecondsRealtime(0.7f);
                    Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

                    Debug.Log("���̵� �ƿ� �Ƕ��5");
                    StartCoroutine(SetActive_False());
                }



                IEnumerator SetActive_False()
                {
                    yield return new WaitForSecondsRealtime(1.4f);

                    Rhythm_Fade.instance.Fade.SetActive(false);
                    Debug.Log("���̵� �ƿ� �Ƕ��");

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
        //Ÿ���� ���� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        // ���� ������ ������ �ٹٲ� ó��
        string completedSentence = sentences_str_0[Sentences_0].Replace("\\\\", "\n");

        dialogueText.text = completedSentence;//sentences_str_0[Sentences_0];
        isTyping = false;

    }


    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = ""; // ��ȭâ �ؽ�Ʈ �ʱ�ȭ

        // ���ڿ����� '\\\\'�� �ٹٲ� ����('\n')�� ��ȯ
        //�ν����Ϳ��� �ۼ��� ���� \\�� �־��ָ� �ٹٲ� ��
        //\\�� �ᵵ ������ \�� �ν�

        //�ٹٲ� �ϰ� ���� �� ����: Hello World! \\Welcome to Unity.

        sentence = sentence.Replace("\\\\", "\n");
        
        
        //Replace()�� ���ڿ� ������ Ư�� ���ڳ� ���ڿ��� �ٸ� ���ڳ� ���ڿ��� ��ü


        // ������ �ٹٲ� ����('\n')�� �������� ������ ó��
        string[] lines = sentence.Split('\n');

        foreach (string line in lines)
        {
            // �� ���� ������ �������� ������ ó��
            string[] words = line.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // ��� �ܾ� �� ���ڸ� ������ �ӵ��� ���
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter; // �� ���ھ� �ؽ�Ʈ�� �߰�
                    yield return new WaitForSeconds(0.05f); // 0.05�� ��ٸ��� ���� ���ڸ� ���
                }

                // ������ �ܾ �ƴ� ���, ���� �ܾ� �ڿ� ������ �߰�
                if (i < words.Length - 1)
                {
                    dialogueText.text += ' ';
                }
            }

            // �ٹٲ� �Ŀ��� �߰����� �ٹٲ� ���ڸ� �߰�
            dialogueText.text += '\n';

            // �ٹٲ� ���� �ð� ���� (���� ����, �ٹٲ� �Ŀ� �ణ�� ������ �ְ� ���� ��)
            //yield return new WaitForSeconds(0.1f);
        }

        isTyping = false; // Ÿ���� ����

        

    }
}
