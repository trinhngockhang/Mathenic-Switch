using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public void _startGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("GAmePlay");
    }

    public void _facebook()
    {
        Application.OpenURL("facebook.com/khang.trinhngoc");
    }
}
