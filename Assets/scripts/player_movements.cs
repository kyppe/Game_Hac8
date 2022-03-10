using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movements : MonoBehaviour
{
    private SpriteRenderer spri;
    private BoxCollider2D collid;
    private bool grounded=false;
    public float Speed=4.5f; 
    private float jumpforce=100f;
    private Rigidbody2D rigid;
    Quaternion lockedRotation;
    // Start is called before the first frame update
    private void Awake() 
    {
        spri= GetComponent<SpriteRenderer>();
        collid= GetComponent<BoxCollider2D>();
        rigid= GetComponent<Rigidbody2D>();
    
    }
    void Start()
    {
        
    }
    private void FixedUpdate() 
    {
        grounded=isgrounded();
    }
    // Update is called once per frame
    void Update()
    {
        move();
        
        move_anim();
    }
    bool isgrounded()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position,1f);
        if(col.Length>1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void move_anim()
    {
        
    }
    void move()
    {
        if ((Input.GetKey("z") || Input.GetKey(KeyCode.UpArrow)) && grounded )
        {
            grounded=false;
            rigid.AddForce(new Vector2(0f,jumpforce));
        }
        if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftArrow))
        {
            spri.flipX=true;
            transform.position += new Vector3(-Time.deltaTime*Speed,0f,0f);

        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            spri.flipX=false;
            transform.position += new Vector3(Time.deltaTime*Speed,0f,0f);
        }
        
    }
}
