using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputsController : MonoBehaviour
{
    public InputField user;
    string nickName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void SavePlayer(){
        nickName = user.text;
        DataBaseController ddbb = new DataBaseController();
        ddbb.Start();
        ddbb.CheckPlayer(nickName);
    }

    public void SelectGame(){
        nickName = user.text;
        DataBaseController ddbb = new DataBaseController();
        ddbb.Start();
        ddbb.CheckSavedGame(nickName);
    }
}
