using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    public Trap instance;
    public Answer answerModel;
    private Answer answer1;
    private Answer answer2;
    private Answer answer3;
    private Answer answer4;
   
    // blue,tim,do,vang,xanh la
    private Rigidbody2D mybody;
    // tim
    public static Color color1 = new Color(0.608f, 0.035f, 1, 1);
    // vang
    public static Color color2 = new Color(0.961f, 0.863f, 0.352f, 1);
    //do
    public static Color color3 = new Color(1, 0, 0.267f, 1);
    //xanh blue
    public static Color color4 = new Color(0.208f, 0.886f, 0.949f, 1);
    public static Color[] arrColor = { color1,color2,color3,color4 };
    public Answer[] answerArr = new Answer[5];
    void Awake()
    {
        float f = 1.40f;
        _makeInstance();
        int x = Controller.instance.mau1;
        int y = Controller.instance.mau2;
        if(y == x)
        {
            if( x != arrColor.Length - 1)
            {
                y = x + 1;
            }
            else
            {
                y = x - 1;
            }
        }
        //-2.24,-0.71,0.8,2.29

        mybody = gameObject.GetComponent<Rigidbody2D>();
        Vector2 temp = new Vector2(-2.11f, 5);
        answer1 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += f;
        answer2 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += f;
        answer3 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += f;
        answer4 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += f;
        answer1.transform.parent = gameObject.transform;
        answer2.transform.parent = gameObject.transform;
        answer3.transform.parent = gameObject.transform;
        answer4.transform.parent = gameObject.transform;
        Answer[] answer = new Answer[5];
        answer.SetValue(answer1, 0);
        answer.SetValue(answer2, 1);
        answer.SetValue(answer3, 2);
        answer.SetValue(answer4, 3);
        answerArr = answer;
        _setColor(answer,x, y);
    }

    void _makeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void _setColor(Answer[] answer, int mau1,int mau2)
    {
        bool first = true;
        int x = Random.Range(0, answer.Length - 1);
        int y = Random.Range(0, 3);
        if (y == x)
        {
            if (x != answer.Length - 1)
            {
                y = x + 1;
            }
            else
            {
                y = x - 1;
            }
        }

        answer[x].sprite.color = arrColor[mau1];
        answer[x].color = mau1;
        answer[y].sprite.color = arrColor[mau1];
        answer[y].color = mau1;
        answer[x]._setRightFalse();
        for(int i = 0; i < 4; i++)
        {
            if(i != x && i !=y)
            {
                if (first)
                {
                    answer[i]._setRightFalse();
                    first = false;
                }
                answer[i].sprite.color = arrColor[mau2];
                answer[i].color = mau2;
            }
            answer[i]._setText();
        }

    }

    public void changeTag(Answer[] answer)
    {
        for(int i = 0; i < 4; i++)
        {
            if(answer[i] != null)
            {
                answer[i].gameObject.tag = "oldAnswer";
            }
        }
    }


    // Update is called once per frame
    void Update () {
	}
}
