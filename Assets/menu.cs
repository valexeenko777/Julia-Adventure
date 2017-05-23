using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public float easy_l = 2.5f;
    public float normal_l = 6.5f;
    public float hard_l = 8.5f;
    public float unreal_l = 102.5f;

    public bool easy_b = false;
    public bool normal_b = false;
    public bool hard_b = false;
    public bool unreal_b = false;
    public int cur_time_lvl = 0;

    public GameObject b_easy, b_normal, b_hard, b_unreal;

    //делаем подсветку
    public Text Easy_Button;

    public void Update()
    {
        
    }

    

    public void Start()
    {
       
    }

    public void JumpIn()
    {
        if ((easy_b == true) || (normal_b == true) || (hard_b == true) || (unreal_b == true))
        {
            Application.LoadLevel("Game1");
            
        }

        else
        {
            easy_b = true;
            normal_b = false;
            hard_b = false;
            unreal_b = false;
            cur_time_lvl = 180;
            b_easy.GetComponent<Image>().color = new Color(56 / 255f, 255 / 255f, 132 / 255f, 255 / 255f);
            b_normal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            b_hard.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            b_unreal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            Application.LoadLevel("Game1");
        }
    }

    public void easy_button()
    {
        easy_b = true;
        normal_b = false;
        hard_b = false;
        unreal_b = false;
        cur_time_lvl = 120;
        b_easy.GetComponent<Image>().color = new Color(56 / 255f, 255 / 255f, 132 / 255f, 255 / 255f);
        b_normal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_hard.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_unreal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
    }

    public void normal_button()
    {
        easy_b = false;
        normal_b = true;
        hard_b = false;
        unreal_b = false;
        cur_time_lvl = 120;
        b_normal.GetComponent<Image>().color = new Color(56/255f, 255/255f, 132/255f, 255/255f);
        b_easy.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_hard.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_unreal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
    }

    public void hard_button()
    {
        easy_b = false;
        normal_b = false;
        hard_b = true;
        unreal_b = false;
        cur_time_lvl = 60;
        b_hard.GetComponent<Image>().color = new Color(56 / 255f, 255 / 255f, 132 / 255f, 255 / 255f);
        b_easy.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_normal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_unreal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
    }

    public void unreal_button()
    {
        easy_b = false;
        normal_b = false;
        hard_b = false;
        unreal_b = true;
        cur_time_lvl = 40;
        b_unreal.GetComponent<Image>().color = new Color(56 / 255f, 255 / 255f, 132 / 255f, 255 / 255f);
        b_easy.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_normal.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        b_hard.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
    }

    public void Goto()
        {
        Destroy(GameObject.FindGameObjectWithTag("gdb").gameObject);
        Application.LoadLevel("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}



