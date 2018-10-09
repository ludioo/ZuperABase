using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static int curHealth;

    public GameObject[] weapon = null;
    public Sprite[] popUp = null;
    public Image img = null;
    private int currentWeapon = 0;
    private int weaponLength;

    private float speed = 5f;
    private float jumpForce = 400f;
    [SerializeField]private float fireRate;
    private float nextFire;
    private bool grounded;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer ren;
    private AudioManager audioManager;



	// Use this for initialization
	void Start () {
        ren = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
        grounded = true;
        curHealth = 5;
        weaponLength = weapon.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (curHealth <= 0)
        {
            GameManager.instance.coins = 0;
            GameManager.instance.soal = 0;
            GameManager.instance.asam = 0;
            GameManager.instance.basa = 0;
            curHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log("Current weapon = " + currentWeapon);
	}
    
    public void Jump()
    {
        if(grounded)
        {
            audioManager.sfxJump.Play();
            animator.Play("Player_Jump");
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void MoveLeft()
    {
        ren.flipX = true;
        
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    public void MoveRight()
    {
        ren.flipX = false;
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    public void ChangeWeapon()
    {
        StartCoroutine("Change");
    }

    private IEnumerator Change()
    {
        img.gameObject.SetActive(true);
        currentWeapon++;
        if(currentWeapon > weaponLength - 1)
        {
            currentWeapon = 0;
        }
        img.sprite = popUp[currentWeapon];
        
        yield return new WaitForSeconds(1f);
        img.gameObject.SetActive(false);
    }
    public void Fire()
    {
        PopUpController popUpController;
        popUpController = FindObjectOfType<PopUpController>();
        if(!popUpController.triggered)
        {
            if(Time.time > nextFire)
            {
                GameObject gun = GameObject.Find("Gun");
                GameObject weaponGO = Instantiate(weapon[currentWeapon], transform.position, Quaternion.identity);
                
                if(ren.flipX){
                    weaponGO.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, 4);
                }else{
                    weaponGO.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 4);
                }
                nextFire = Time.time + fireRate;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laut")
        {
            audioManager.sfxAir.Play();
            curHealth-=2;
            transform.position = GameManager.instance.GetSpawnPoint();
        }
        if(collision.gameObject.tag == "Enemy")
        {
            curHealth-=2;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            audioManager.sfxCoin.Play();
            GameManager.instance.coins++;
            Destroy(collision.gameObject);
        }
    }
}
