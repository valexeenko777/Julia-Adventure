using UnityEngine;
using System.Collections;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;
    public float asd;
    public bool ent = false;
    public bool sta = false;
    public bool exi = false;

    private Bullet bullet;

    protected override void Awake()
    {
        
        bullet = Resources.Load<Bullet>("Bullet");
    }



    private void OnTriggerEnter(Collider other)
    {     
        if (other!=null)
        {
            ent = true;
        }
        if (other.gameObject.tag == "char1")
        {
            Destroy(this);
        }

        if (other.gameObject.tag == "char1") // тригер стай
        {
            sta = true;
        }

        if (other ==null) // тригер стай
        {
            exi = true;
        }
    }



    protected override void OnTriggerEnter2D(Collider2D collider)
    {       
        if (collider.tag=="char")
        {           
            Destroy(collider.gameObject);           
        } 


      

    }
}
