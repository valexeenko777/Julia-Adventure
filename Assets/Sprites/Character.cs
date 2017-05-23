using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : Unit
{

    public Text LivePanel;
    public Text CoinPanel;
    public float timer;
    public int limit_level;
    public Text TimePanel;
    public GameObject canv, resbt;
    public int lives = 5;
    

    [SerializeField]
    private float speed = 3F;

    [SerializeField]
    public float jumpForce = 15F;

    private bool isGrounded = false;

    private Bullet bullet;



    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        timer = GameObject.FindGameObjectWithTag("gdb").GetComponent<menu>().cur_time_lvl;

        bullet = GameObject.Find("BulletObject").GetComponent<Bullet>(); //Resources.Load<Bullet>("BulletObject");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        

        if (this.transform.position.y <= -18 )
        {            
            this.gameObject.GetComponent<Lives>().CurrentLive = 0;
            resbt.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if (timer <= 0)
        {
            this.gameObject.GetComponent<Lives>().CurrentLive = 0;
            resbt.SetActive(true);
            this.gameObject.SetActive(false);
        }

        lives = this.gameObject.GetComponent<Lives>().CurrentLive;
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButton("Horizontal")) Run();

        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

        LivePanel.text = lives.ToString(); // вот тут мы переводим лайв-панел в стринг
        CoinPanel.text = this.gameObject.GetComponent<Lives>().Coins.ToString();
        
        limit_level = (int)timer;
        TimePanel.text = limit_level.ToString();



    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if(isGrounded) State = CharState.Run;
    }


    private void Jump()
    {   bool can_jmp = GameObject.FindGameObjectWithTag("char1").GetComponent<Distance>().in_ground;
        if (can_jmp == true)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void Shoot()
    {        
        Vector3 position = transform.position; position.y -= 0.25F;


        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
           newBullet.Destroy();
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }


    public override void ReceiveDamage()
    {

        this.gameObject.GetComponent<Lives>().CurrentLive--;
        rigidbody.AddForce(transform.right * -3.5F, ForceMode2D.Impulse);
        if (lives == 1)
        {            
            this.gameObject.GetComponent<Lives>().CurrentLive = 0;
            LivePanel.text = "0";
            resbt.SetActive(true);
            this.gameObject.SetActive(false);
        }
        Debug.Log(lives);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0F);

        isGrounded = colliders.Length > 1;

        if(!isGrounded) State = CharState.Jump;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "BlueDude"|| collision.gameObject.tag == "wormt") 
        {
            ReceiveDamage();            
            
        }
    }

}