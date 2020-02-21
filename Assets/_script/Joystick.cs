using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public Transform weapon;
    public float speed = 40.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;
    
    void Start()
    {
        
    }

    void Update()
    {
        //moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }else{
            touchStart = false;
            
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 direction = pointB - pointA;
            Vector2 offset = Vector2.ClampMagnitude(direction, 1.0f);
            moveCharacter(direction);
            
            circle.transform.position = new Vector2(pointA.x + offset.x, pointA.y + offset.y);
        }else{
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void moveCharacter(Vector2 direction)
    {
        //player.Translate(direction * speed * Time.deltaTime);
        //player.eulerAngles = new Vector3( 0, Mathf.Atan2(Input.mousePosition.x, Input.mousePosition.y) * 180 / Mathf.PI, 0 );
        //Quaternion target = Quaternion.Euler((Input.mousePosition.x * 60.0f), 0, (Input.mousePosition.y * 60.0f));
        //player.rotation = Quaternion.Slerp(player.rotation, target,  Time.deltaTime * speed);
        float heading = Mathf.Atan2((direction.x),(direction.y)) * -1;
        player.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);
        weapon.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);

        //Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction2 = (mouseWorldPosition - (Vector2) transform.position).normalized;
        //player.up = direction2;
    }
}
