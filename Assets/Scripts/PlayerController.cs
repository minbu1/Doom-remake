using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D rb;

    public float moveSpeed = 3f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera playerCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnimation;
    public Animator animation;

    private int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool dead;

    public TextMeshProUGUI health;
    public TextMeshProUGUI ammo;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        health.text = $"{currentHealth}%";
        ammo.text = currentAmmo.ToString();
    }

    private void Update()
    {
        if (!dead)
        {
            //movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;
            
            //camera control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
            
            
            Quaternion camRotate = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
            transform.rotation = camRotate;

            playerCam.transform.localRotation = Quaternion.Euler(playerCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
            

            //shooting
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                {
                    Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                    RaycastHit hit;
                    //if something is hit
                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<Enemy>().TakeDamage();
                        }
                    }
                    else
                    {
                        Debug.Log("i'm looking at nothing");
                    }
                    currentAmmo--;
                    gunAnimation.SetTrigger("Shoot");
                    updateAmmoUi();
                }
            }
            if(moveInput != Vector2.zero)
            {
                animation.SetBool("IsMoving", true);
            }
            else
            {
                animation.SetBool("IsMoving", false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            dead = true;
            currentHealth = 0;
            GameManager gameManager = new GameManager();
            gameManager.UnlockCursor();
        }

        health.text = $"{currentHealth}%";
    }

    public void AddHealth(int healAmmount)
    {
        currentHealth += healAmmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        health.text = $"{currentHealth}%";
    }

    public void updateAmmoUi()
    {
        ammo.text = currentAmmo.ToString();
    }
}
