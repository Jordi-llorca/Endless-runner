using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    int position = 0;
    public float distancia = 3f;
    public float velocidad = 2f;

    public static int vHearts = 0;
    public static int lscore = 0;

    public GameObject[] hearts;
    public GameObject[] vhearts;
    public GameObject[] halfHearts;
    public int life;
    bool dead = false;

    public Animator myAnim;
    
    bool grounded = false;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;


    public GameObject bajar;
    public GameObject saltar;
    public GameObject golpeCuchillo;
    public GameObject golpeDebil;
    public GameObject OuchRojo;
    public GameObject Ouch;
    public GameObject GolpeTomate;
    public GameObject GolpeHarina;

    public GameObject momentoDolor;

    public float contador = 0;
    public float contadorVHearts = 0;



    private void Start()
    {
        vhearts[0].SetActive(false);
        vhearts[1].SetActive(false);
        halfHearts[0].SetActive(false);
        halfHearts[1].SetActive(false);
        momentoDolor.SetActive(false);
        vHearts = 0;
        contadorVHearts = 0;
        contador = 0;
        lscore = 0;
    }
    void Update()
    {
        if (dead) Morir();
        movimientoVertical();
        vanishingLives();
        if (contador > 0)
        {
            momentoDolor.SetActive(true);
            contador -= Time.deltaTime;
        }
        else momentoDolor.SetActive(false);

        if (vHearts > 0 && contadorVHearts <= 0) contadorVHearts = 10;
        if (contadorVHearts <= 1 && vHearts > 0)
        {
            TakeDamage(1);
            Score.scoreValue += (int)(Score.scoreValue * 0.10f);
            
        }
        if (contadorVHearts > 0) contadorVHearts -= Time.deltaTime;

    }
    void vanishingLives()
    {
        if(lscore == 1)
        {
            if(vHearts == 0)
            {
                vhearts[0].SetActive(false);
                vhearts[1].SetActive(false);
                halfHearts[0].SetActive(true);
                halfHearts[1].SetActive(false);
            }
            else
            {
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(false);
                halfHearts[0].SetActive(false);
                halfHearts[1].SetActive(true);
            }
        }
        else
        {
            if (vHearts == 1)
            {
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(false);
                halfHearts[0].SetActive(false);
                halfHearts[1].SetActive(false);
            }
            else if(vHearts == 2)
            {
                vhearts[0].SetActive(true);
                vhearts[1].SetActive(true);
                halfHearts[0].SetActive(false);
                halfHearts[1].SetActive(false);
            }
            else
            {
                vhearts[0].SetActive(false);
                vhearts[1].SetActive(false);
                halfHearts[0].SetActive(false);
                halfHearts[1].SetActive(false);
            }
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
            Instantiate(saltar);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && position != -1 && grounded)
        {
            myAnim.SetBool("isGrounded", false);
            myAnim.SetBool("Fall", true);
            transform.Translate(Vector3.down * distancia);
            position--;
            grounded = false;
            Instantiate(bajar);
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
        Transform pos = this.GetComponent<Transform>();
        Vector3 res = new Vector3(pos.position.x, pos.position.y);
        if (collision.gameObject.tag == "objetoMadera")
        {
            TakeDamage(1);
            Instantiate(golpeDebil);
            Instantiate(GolpeHarina, res, pos.rotation);
            Instantiate(Ouch, res, pos.rotation);
        }
        else if(collision.gameObject.tag == "objetoHierro")
        {
            TakeDamage(2);
            Instantiate(golpeCuchillo);
            Instantiate(GolpeTomate, res, pos.rotation);
            Instantiate(OuchRojo, res, pos.rotation);
        }
    }
    void Morir()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("MenuMuerte");
    }
    public void TakeDamage(int d)
    {
        if (contador <= 0)
        {
            contador = 1;
            if (vHearts > 0)
            {
                vHearts--;
                contador = 0;
                contadorVHearts = 0;
                for (int a = 0; a < d-1; a++) TakeDamage(1);
            }
            else if (life > 0)
            {
                life -= d;
                if (life < 3)
                {
                    hearts[2].SetActive(false);
                    if(life < 2)
                    {
                        hearts[1].SetActive(false);
                        if (life < 1)
                        {
                            hearts[0].SetActive(false);
                            dead = true;
                        }
                    }
                }
            }
        }
    }

}
