using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    private bool canTeleport = true;
    private float teleportCooldown = 2.0f;

    public float _movementSpeed = 40.0f;
    public Rigidbody2D rb;
    public Weapon weapon;


    Vector2 moveDirection;
    Vector2 mousePosition;

    

    void Start()
    {

    }

    void Update()
    {
        PlayerMovement();

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * _movementSpeed, moveDirection.y * _movementSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport)
        {
            GameObject teleporterAW = GameObject.Find("Teleporter_AW" + other.tag.Substring(2, 2));
            GameObject teleporterZA = GameObject.Find("Teleporter_ZA" + other.tag.Substring(2, 2));
            GameObject mainCamera = GameObject.Find("MainCamera");

            if (other.tag.Substring(0, 2) == "ZA")
            {
                transform.position = teleporterAW.transform.position;
                mainCamera.transform.position = new Vector3(150f, 0f, -10f);

            }
            else if (other.tag.Substring(0, 2) == "AW")
            {
                transform.position = teleporterZA.transform.position;
                mainCamera.transform.position = new Vector3(0f, 0f, -10f);
            }
        }
        StartCoroutine(TeleportCooldown());

        if (other.tag == "EnemyMelee")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }



}
