using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour {

    public SpriteRenderer mySprite;
    private Vector3 mousePosition;
    private float moveSpeedMouse = 0.1f;
    private Vector2 velocity = new Vector2(0, 0);
    Rigidbody2D mybody;
    // Use this for initialization
    void Awake()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        _setColor();
        mybody = gameObject.GetComponent<Rigidbody2D>();
    }

    void _setColor()
    {
        mySprite.color = Trap.arrColor[Controller.instance.mau1];

    }


    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // transform.position = Vector2.Lerp(transform.position, temp, moveSpeedMouse);
            if(Mathf.Abs(mousePosition.x - transform.position.x) > 0.5)
            {
                velocity.x = mousePosition.x * 7;
            }
            else
            {
                velocity.x = 0;
            }
            
        }
        else
        {
            velocity.x = 0;
        }
        mybody.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "newAnswer")
        {
            Answer ans = collision.gameObject.GetComponent<Answer>();
            if(ans.right == Controller.instance._getBool())
            {
                Destroy(collision.gameObject);
                Controller.instance._setRandomMath(Controller.instance.mathText);
                _setColor();

            }
            else {
                Controller.instance.Lose();
            }
        }
    }
}
