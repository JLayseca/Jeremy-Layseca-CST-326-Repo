using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class victoryCondition : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    public TextMeshProUGUI victoryMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider mario){
        Destroy(countDown);
        victoryMessage.text = $"You win!";
    } 
}
