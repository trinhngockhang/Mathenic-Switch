using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public Text mathText;
    public static Controller instance;
    public bool answerTrue;
    public LosePanel losePanel;
    public int mau1, mau2;
    public Player player;
    public Text scoreText;
    public int score;
    public Text scoreEndGame;
    public Text BestScore;
    public Text MathTextEndGame;
    public Vector2 vec = new Vector2(0, -3f);
    // Use this for initialization
    void Awake () {
        score = 0;
        _makeInstance();
        _setRandomMath(mathText);
        player._setColor();
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
        float right,equal;
        string t; // + or -
        // random t
        int x = Random.Range(0, 1);
        t = x == 1 ? "+":"-";
        
        //random a,b
         a = Random.Range(0, 20);
         b = Random.Range(0, 20);
        // random c
        right = Random.Range(0f, 1f);
        equal = Random.Range(0f, 1f);
        // ra dau =
        if(equal < 0.6f)
        {    // return true
            if (right >= 0.6)
            {
                c = x == 1 ? a + b : a - b;
                answerTrue = true;
            }
            //return false
            else if(right < 0.6 && right > 0.35 )
            {
                answerTrue = false;
                offset = Random.Range(-3, 4);
                if (offset == 0) offset = -4;
                c = x == 1 ? a + b + offset : a - b + offset;
            }
            else
            {
                answerTrue = false;
                c = x == 1 ? -(a + b)  : b - a ;
            }
            text.text = a + " " + t + " " + b + " " + "=" + " " + c;
        }
        // ra dau =
        else
        {
            if (right >= 0.5)
            {
                c = x == 1 ? a + b : a - b;
                answerTrue = false;
            }
            else if(right < 0.5 && right > 0.2)
            {
                answerTrue = true;
                offset = Random.Range(-3, 4);
                if (offset == 0) offset = -4;
                c = x == 1 ? a + b + offset : a - b + offset;
            }
            else{
                answerTrue = true;
                c = x == 1 ? -(a + b)  : b - a ;
            }
            text.text = a + " " + t + " " + b + " " + "!=" + " " + c;
        }
        
        mau1 = Random.Range(0, 3);
        mau2 = Random.Range(0, 3);
    }

    public void Lose()
    {
        
        scoreEndGame.text = "" + score;
        Time.timeScale = 0;
        int oldBestScore = ScoreManager.instance.getHighScore();
        if (score > oldBestScore)
        {
            ScoreManager.instance.setHighScore(score);
        }

        losePanel.gameObject.SetActive(true);
        MathTextEndGame.text = mathText.text;
        BestScore.text = "" + ScoreManager.instance.getHighScore();
    }

    public void _returnGame()
    {
        
        Application.LoadLevel("GAmePlay");
        Time.timeScale = 1;
    }

   

    public void _returnMenu()
    {
        Application.LoadLevel("Start");
    }

	void Update () {
        scoreText.text ="" + score;

    }
}
