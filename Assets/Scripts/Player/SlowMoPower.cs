using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightPower : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] Image outline;
    [SerializeField] float drainTime = 10f;
    [SerializeField] float power;
    bool slowingDown = false;

    private void Start()
    {
        power = 1;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire2") && power > 0)
            slowingDown = !slowingDown;
        
        if (power <= 0 && slowingDown) slowingDown = false;

        if (slowingDown)
        {
            Time.timeScale = 0.5f;
            power -= 1f / drainTime * Time.deltaTime;
            bar.fillAmount = power;
        } else
        {
            Time.timeScale = 1f;
        }

    }
}