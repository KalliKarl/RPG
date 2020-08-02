using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<Message> MessageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            SendMessageToChat("You Pressed space");
        }
    }
    public void SendMessageToChat(string text) {
        Message newMessage = new Message();
        newMessage.text = text;
        MessageList.Add(newMessage);
    }

    [System.Serializable]
    public class Message {
        public string text;
    }
}
