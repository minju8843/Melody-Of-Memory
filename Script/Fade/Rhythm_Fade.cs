using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rhythm_Fade : MonoBehaviour
{

    public Animator Fade_Anim;
    public GameObject Fade;

    public static Rhythm_Fade instance;

    public void Start()
    {
        instance = this;
    }

}
