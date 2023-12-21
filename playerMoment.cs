using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playerMoment : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 velocity;
    public int score;
    public TextMeshProUGUI textScore;
    float speedAmount = 3f;
    float jumpAmount = 8f;
    public Animator anim;
    public TextMeshProUGUI playerScoreText;


    // fiziksel her türlü iþlemi rigidbody üzerinden yapýyoruz
    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "score:" + score.ToString();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        anim.SetFloat("Speed",Mathf.Abs( Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0f))
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }


        if (anim.GetBool("IsJumping") && Mathf.Approximately(rb.velocity.y, 0))
        {
            anim.SetBool("IsJumping", false);
        }

        // yüz çevir
       if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        // yüz çevir
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnGroundCheck()
    {
      //  isGrounded = Physics2D.OverCirvle(pozisyon, çap, layer);
    }
}