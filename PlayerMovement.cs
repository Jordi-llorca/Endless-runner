using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    int position = 0;
    public float distancia = 3f;
    public float velocidad = 2f;

    public static int vHearts = 0;
    public static int lscore = 0;

    public GameObject[] hearts;
    public GameObject[] vhearts;
    public int life;
    bool dead = false;

    public Animator myAnim;
    
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    SpriteRenderer sprite;

    private void Start()
    {
        vhearts[0].SetActive(false);
        vhearts[1].SetActive(false);

    }
    void Update()
    {

        if (dead) EndGame();

        movimientoVertical();

        if (dead) Morir();
   
        vanishingLives();

    }
    void loadSpriteVHeats(int vHeart, bool isComplete)
    {
        sprite = vhearts[vHeart].GetComponent<SpriteRenderer>();
        if(isComplete)
            sprite = Resources.Load<SpriteRenderer>("corazon_queso");
        else
            sprite = Resources.Load<SpriteRenderer>("medio_corazon");

        
    }
    void vanishingLives()
    {
        switch (lscore)
        {
            case 1:
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(false);
                loadSpriteVHeats(0, false);
                break;
            case 2:
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(false);
                loadSpriteVHeats(0, true);
                break;
            case 3:
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(true);
                loadSpriteVHeats(1, false);
                break;
            case 4:
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(true);
                loadSpriteVHeats(1, true);
                break;
            default:
                vhearts[0].SetActive(false);
                vhearts[1].SetActive(false);
                break;
        }
    }
    void movimientoVertical()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && position != 1 && grounded)
        {
            myAnim.SetBool("isGrounded", false);
            myAnim.SetBool("Jump", true);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velocidad), ForceMode2D.Impulse);
            position++;
            grounded = false;
            

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && position != -1 && grounded)
        {
            myAnim.SetBool("isGrounded", false);
            myAnim.SetBool("Fall", true);
            transform.Translate(Vector3.down * distancia);
            position--;
            grounded = false;
            
        }
        if (grounded)
        {
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Fall", false);
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "objetoMadera")
        {
            TakeDamage(1);
        }
        else if(collision.gameObject.tag == "objetoHierro")
        {
            TakeDamage(2);
        }
    }
    void Morir()
    {
        Destroy(this.gameObject);
    }
    public void TakeDamage(int d)
    {
        if(d > 1)
        {
            for (int a = 0; a < d; a++) TakeDamage(1);
        }
        if(vHearts > 0)
        {
            vhearts[vHearts - 1].SetActive(false);
            vHearts--;
        }
        else if(life > 0)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1) dead = true;
        }
        
    }

     void EndGame()
    {
        SceneManager.LoadScene("Principal");
    }

}
