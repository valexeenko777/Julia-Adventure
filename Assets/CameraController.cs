using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;         
    }
    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("char");
    }
    private void Update()
    {if(character.activeSelf == false)
        { Vector3 nw = new Vector3(20, 20, -10);
            target.position = nw  ;
        }
        Vector3 position = target.position; position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }

}
