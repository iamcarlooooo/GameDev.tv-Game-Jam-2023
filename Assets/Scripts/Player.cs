using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 20.0f;
    private bool canTeleport = true;
    private float teleportCooldown = 2.0f;

    void Start()
    {

    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * _movementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport)
        {
            GameObject teleporterAW = GameObject.Find("Teleporter_AW" + other.tag.Substring(2, 2));
            GameObject teleporterZA = GameObject.Find("Teleporter_ZA" + other.tag.Substring(2, 2));

            if (other.tag.Substring(0, 2) == "ZA")
            {
                transform.position = teleporterAW.transform.position;
            }
            else if (other.tag.Substring(0, 2) == "AW")
            {
                transform.position = teleporterZA.transform.position;
            }
        }
        StartCoroutine(TeleportCooldown());
    }

    IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }



}
