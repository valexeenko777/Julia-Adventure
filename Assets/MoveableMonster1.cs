using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableMonster1 : MonoBehaviour {

    public GameObject character;
    
    
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("char");        
    }
        
    void Update()
    {

    }
}
