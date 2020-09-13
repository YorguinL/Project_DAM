using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    private int m, s;

    [SerializeField]
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        m = minutes;
        s = seconds;
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    // Update is called once per frame
    void UpdateTimer()
    {
        if(s != 0){
            s--;
        } else {
            if(m == 0){
                // End game
            } else {
                m--;
                s = 59;
            }
        }
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    void WriteTimer(int m, int s){
        if(s < 10) {
            timerText.text = m.ToString() + ":0" + s.ToString();
        } else {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }
}
