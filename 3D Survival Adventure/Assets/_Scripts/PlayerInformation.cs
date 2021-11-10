using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInformation : MonoBehaviour
{

    public static PlayerInformation PI;
    public string nickname;

    public Sprite slotOneImage;

    private void OnEnable()
    {
        if(PlayerInformation.PI == null)
        {
            PlayerInformation.PI = this;
        }
        else
        {
            if (PlayerInformation.PI != this)
            {
                Destroy(PlayerInformation.PI.gameObject);
                PlayerInformation.PI = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);


    }

}
