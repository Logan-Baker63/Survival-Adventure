using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{

    string m_StartingColour = "grey";
    string m_HoverColour = "white";

    Image m_BackgroundImage;
    
    // Start is called before the first frame update
    void Start()
    {
        m_BackgroundImage = gameObject.transform.GetChild(0).GetComponent<Image>();
    }

    public void CursorHover()
    {
        m_BackgroundImage.color = Color.white;
    }

    public void CursorExitHover()
    {
        m_BackgroundImage.color = Color.grey;
    }

}
