using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{
    public Image LButton;
    public Image Rbutton;
    public Text info;
    public Image textBG;

    public Image panelIntroBG;
    public Text panelText;
    // Start is called before the first frame update
    void Start()
    {
        LButton.enabled = false;
        Rbutton.enabled = false;
        info.enabled = false;
        textBG.enabled = false;

        panelIntroBG.enabled = false;
        panelText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Yellow")
        {
            LButton.enabled = true;
            Rbutton.enabled = true;
            info.enabled = true;
            textBG.enabled = true;
        }
        else
        {
            LButton.enabled = false;
            Rbutton.enabled = false;
            info.enabled = false;
            textBG.enabled = false;
        }

        if(collision.gameObject.tag == "Panel")
        {
            panelIntroBG.enabled = true;
            panelText.enabled = true;
        }
    }
}
