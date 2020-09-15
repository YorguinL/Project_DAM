using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{

    public static Text message;
    // Start is called before the first frame update
    public static void Start(string msg)
    {
        message.text = msg;
        message.gameObject.SetActive(true);
        new WaitForSeconds(5);
        message.gameObject.SetActive(false);
    }
}
