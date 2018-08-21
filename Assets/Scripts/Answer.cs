using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {
    public SpriteRenderer sprite;
    public bool right = true;
    private Rigidbody2D mybody;
    private Vector2 vec = new Vector2(0, -3f );
    public Canvas myCanvas;
    private Text trueText;
    private void Awake()
    {
        right = true;
        trueText = myCanvas.GetComponentInChildren<Text>();
        mybody = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update () {
        mybody.velocity = vec;   	
	}

    public void _setRightFalse()
    {
        right = false;
    }

    public void _setText()
    {
        if (right)
        {
            trueText.text = "True";
        }
        else
        {
            trueText.text = "False";
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "destroy")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
