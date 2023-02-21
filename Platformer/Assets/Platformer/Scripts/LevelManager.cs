using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if(Input.GetMouseButtonDown(0)){
            if (Physics.Raycast(MouseRay, out hitData, Mathf.Infinity))
            {
                if (hitData.collider.tag == "Breakable"){
                    GameObject hitBlock = hitData.collider.gameObject;
                    Destroy(hitBlock);
                }

                if (hitData.transform.tag == "CoinGiver"){
                    coins++;
                    if (coins < 10){
                         coinCount.text = $"Coins \nX0{coins}";
                    }
                    if (coins >= 10){
                    coinCount.text = $"Coins \nX{coins}";
                    }
                    if (coins == 100){
                        coins = 0;
                        coinCount.text = $"Coins \nX0{coins}";
                    }
                }
            }
        }
    }


}
//Input.mousePosition