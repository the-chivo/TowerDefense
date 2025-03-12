using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float angle;
    [SerializeField] float bulletSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] float maxBulletDistance;
    public float bulletDamage = 35;
    GameObject player;
    Vector3 bulletDistance;
    
    void Start()
    {
        Vector3 mouseScreenCoords = Input.mousePosition;
        Vector3 mouseInWorldCoords = Camera.main.ScreenToWorldPoint(mouseScreenCoords);
        mouseInWorldCoords.z = 0;
        Vector3 directionToMouse = mouseInWorldCoords - transform.position;
        Vector3 referenceDirection = new Vector3(0,1,0);
        angle = Vector3.SignedAngle(referenceDirection, directionToMouse, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Euler(0,0,angle);
        direction = directionToMouse;

         player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        gameObject.transform.position += (Vector3)direction.normalized * Time.deltaTime * bulletSpeed;
        //Sistema de distancia maxima de la bala
        bulletDistance = new Vector3(0,0,0) - gameObject.transform.position;
        if(bulletDistance.x >= maxBulletDistance || bulletDistance.x <= -maxBulletDistance)
        {
            Destroy(gameObject);
        }
        if(bulletDistance.y >= maxBulletDistance || bulletDistance.y <= -maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        { 
            collision.gameObject.GetComponent<EnemyHealth>().TakeBulletDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
