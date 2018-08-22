using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public Text mathText;
    public static Controller instance;
    public bool answerTrue;
    public LosePanel losePanel;
    public int mau1, mau2;
	// Use this for initialization
	void Awake () {
        _makeInstance();
        _setRandomMath(mathText);
	}
	public bool _getBool()
    {
        return answerTrue;
    }
    void _makeInstance()
    {
        if (instance == null) instance = this;
    }
	public void _setRandomMath(Text text)
    {
        // a + - b = c;
        int a, b, c;
        int randCMin,randCMax;
        int offset;
        float right;
        string t; // + or -
        // random t
        int x = Random.Range(0, 1);
        t = x == 1 ? "+":"-";
        
        //random a,b
         a = Random.Range(0, 20);
         b = Random.Range(0, 20);
        // random c
        right = Random.Range(0f, 1f);
        Debug.Log("right la : " + right);
        if(right >= 0.5)
        {
            c = x == 1 ? a + b : a - b;
            answerTrue = true;
        }
        else
        {
            answerTrue = false;
            offset = Random.Range(-3, 4);
            if (offset == 0) offset = -4;
            c = x == 1 ? a + b + offset : a - b + offset;
        }
        text.text = a + " " + t + " " + b + " " + "=" + " " + c;
        mau1 = Random.Range(0, 3);
        mau2 = Random.Range(0, 3);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.gameObject.SetActive(true);
    }

	void Update () {
		
	}
}
