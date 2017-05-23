using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

    GameObject character;
    public bool in_ground = false;



    void Start()
    {
        character = GameObject.FindGameObjectWithTag("char");
    }

    

    // окончание дистанции

    void OnTriggerEnter2D(Collider2D enemy) // это колайдер объекта который входит в нижний круг под персонажем. в данном случаи враг
    {
        //  Debug.Log(other);
        if (enemy.tag == "BlueDude" && in_ground==false) // тэг нашего врага
        {
            character.GetComponent<Rigidbody2D>().AddForce(transform.up * character.GetComponent<Character>().jumpForce, ForceMode2D.Impulse);
            character.GetComponent<Lives>().Coins++; // добавляем очко
            character.GetComponent<Lives>().Coins++; // добавляем очко еще раз
            Destroy(enemy.gameObject); // убиваем врага            
        }
        if (enemy.tag == "grnd")
        {
            in_ground = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.tag == "grnd" )
        {
            in_ground = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "grnd")
        {
            in_ground = true;
        }
    }

}
