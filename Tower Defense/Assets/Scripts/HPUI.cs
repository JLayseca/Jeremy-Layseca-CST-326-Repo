using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUI : MonoBehaviour
{
    public TMP_Text HPText;
    // Update is called once per frame
    void Update()
    {
        HPText.text = PlayerStats.HP + "LIVES";
    }
}
