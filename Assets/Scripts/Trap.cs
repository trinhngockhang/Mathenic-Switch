using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public Answer answerModel;
    private Answer answer1;
    private Answer answer2;
    private Answer answer3;
    private Answer answer4;
   
    
    private Rigidbody2D mybody;
    private Color[] arrColor = { new Color(0, 1, 1, 1),new Color(204, 0, 206, 1), new Color(0.5f, 0.5f, 0.5f, 1),
        new Color(1, 0.92f, 0.016f, 1)};
    void Awake()
    {
       
        int x = Random.Range(0, arrColor.Length-1);
        int y = Random.Range(0, arrColor.Length - 1);
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
        Debug.Log("2 mau dc chon la: " + x + "  " + y);

        mybody = gameObject.GetComponent<Rigidbody2D>();
        Vector2 temp = new Vector2(-2.252f, 5);
        answer1 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += 1.529f;
        answer2 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += 1.529f;
        answer3 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += 1.529f;
        answer4 = Instantiate(answerModel, temp, Quaternion.identity);
        temp.x += 1.529f;
        answer1.transform.parent = gameObject.transform;
        answer2.transform.parent = gameObject.transform;
        answer3.transform.parent = gameObject.transform;
        answer4.transform.parent = gameObject.transform;
        Answer[] answer = new Answer[5];
        answer.SetValue(answer1, 0);
        answer.SetValue(answer2, 1);
        answer.SetValue(answer3, 2);
        answer.SetValue(answer4, 3);
        _setColor(answer,x, y);
    }


    void _setColor(Answer[] answer, int mau1,int mau2)
    {
        bool first = true;
        int x = Random.Range(0, answer.Length - 1);
        Debug.Log(x);
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
        answer[y].sprite.color = arrColor[mau1];
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
            }
            answer[i]._setText();
        }

    }

    // Update is called once per frame
    void Update () {
	}
}
