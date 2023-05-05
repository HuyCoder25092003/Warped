using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    Vector2 movement;
    Rigidbody2D rigi;
    [SerializeField] float speed,jumpForce;
    
    [SerializeField] bool isOnGround;
    
    [SerializeField] GameObject _bullet;

    float timeCount;
    
    [SerializeField] float timeMax;

    bool isImmute = false;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //isImmute = true;
        timeCount = 0;
    }

    void Update()
    {
        Moving();
    }
    void Moving()
    {
        movement = rigi.velocity;
        movement.x = speed * Input.GetAxis("Horizontal");
        rigi.velocity = movement;

        if(Input.GetKey(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rigi.AddForce(new Vector2(0, jumpForce));
        }

        timeCount += Time.deltaTime;

        FireBullet();

    }
    void FireBullet()
    {
        if (!Input.GetKeyDown(KeyCode.R))
            return;

        if (timeCount < timeMax)
            return;

        GameObject bullet = ObjectPooling.Instant.GetObject(_bullet); //this.GetBullet();
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        bullet.SetActive(true);

        timeCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        //if (isImmute)
        //    return;
    }

}
