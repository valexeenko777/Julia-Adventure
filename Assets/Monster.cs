using UnityEngine;
using System.Collections;

public class Monster : Unit

{
    GameObject character;
    protected virtual void Awake() { }
    protected virtual void Start()
    {
        character = GameObject.FindGameObjectWithTag("char");
    }
    protected virtual void Update() { }


    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
                
        if (bullet)
        {
            ReceiveDamage();
            character.GetComponent<Lives>().Coins++; // добавляем очко
        }
                
    }

   

}
