using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightPower : MonoBehaviour
{
    //[SerializeField] Image bar;
    //[SerializeField] Image outline;
    [SerializeField] float drainTime = 75f;
    [SerializeField] float power;
    bool slowingDown = false;

    void Update()
    {
        //if (!PlayerState.HasItem("Flashlight"))
        //{
        //    flashLightOutline.color = Color.gray;
        //    flashLightBar.gameObject.SetActive(false);
        //}
        //else
        //{
        //    flashLightBar.gameObject.SetActive(true);
        //    if (PlayerState.flashLightPower < 0.1)
        //    {
        //        flashLightBar.color = Color.red;
        //    }
        //    else
        //    {
        //        flashLightBar.color = Color.white;
        //    }
        //}



        if (slowingDown)
        {
            //flashLightBar.fillAmount -= 1f / FLDrainTime * Time.deltaTime;
            //Power = flashLightBar.fillAmount;
        }

    }
}