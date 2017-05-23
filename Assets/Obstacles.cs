using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }

}
    

