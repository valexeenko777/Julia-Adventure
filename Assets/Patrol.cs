using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public GameObject point1, point2, gdb;  // точки патрулирвоания 

    public float speed;

    public bool p1 = false, p2= false; // к какой точке сейчас идем

    public float dis_p1, dis_p2;
    void Patrol_Enemy () // система патрулирования 
    {
        // можно через передвижение координатов через transform.position
      
        if (p1 == true) // ели первая включена идем к ней     
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, point1.transform.position, Time.deltaTime * speed);
            
        }
        if(p2 == true)// ели вторая включена идем к ней
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, point2.transform.position, Time.deltaTime * speed);

        }
        if (p1 == false && p2 == false) // ели обе точки выключены, выбирается первая point1
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, point1.transform.position, Time.deltaTime * speed);
        }

    }

   public void point_distance() // расчет дистанции от моба до точки
    {
         dis_p1 = Vector2.Distance(this.gameObject.transform.position, point1.transform.position); // раст. до 1 точки
         dis_p2 = Vector2.Distance(this.gameObject.transform.position, point2.transform.position); // раст. до 2ой точки

        if (dis_p1 <= 0.1f)
        {
            p2 = true;
            p1 = false;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
        if(dis_p2 <= 0.1f)
        {
            p2 = false;
            p1 = true;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void Difficult(float new_speed)
    {
        speed = new_speed;
    }

    void ChoiseDifficalt()
    {
        if (gdb.GetComponent<menu>().easy_b == true)
        {
            Difficult(gdb.GetComponent<menu>().easy_l);
        }

        if (gdb.GetComponent<menu>().normal_b == true)
        {
            Difficult(gdb.GetComponent<menu>().normal_l);
        }

        if (gdb.GetComponent<menu>().hard_b == true)
        {
            Difficult(gdb.GetComponent<menu>().hard_l);
        }

        if (gdb.GetComponent<menu>().unreal_b == true)
        {
            Difficult(gdb.GetComponent<menu>().unreal_l);
        }
    }

    void Start() // работает при старте
    {
                gdb = GameObject.FindGameObjectWithTag("gdb");
        ChoiseDifficalt();
    }


    void Update () // работает всегда
    { // требуют обновления тк. работают с координатами ( передвижение объекта)
        point_distance(); 
        Patrol_Enemy();

    }
}
