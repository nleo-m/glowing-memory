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
    Coroutine coolDownCoroutine = null;

    private void Start()
    {
        power = 0;
    }

    void Update()
    {
        Mathf.Clamp(power, 0, 1);

        if (Input.GetButtonUp("Fire2") && power > 0)
        {
            slowingDown = !slowingDown;
            
            if (coolDownCoroutine == null) 
                coolDownCoroutine = StartCoroutine(coolDown());
        }

        if (power <= 0 && slowingDown)
        {
            slowingDown = false;
            coolDownCoroutine = StartCoroutine(coolDown());
        }

        if (slowingDown)
        {
            Time.timeScale = 0.5f;
            power -= 1f / drainTime * Time.deltaTime;
        } else
        {
            Time.timeScale = 1f;
            
            if (power < 0.25f && coolDownCoroutine == null)
            {
                power += 0.05f * Time.deltaTime;
            }
        }

        bar.fillAmount = power;
    }

    IEnumerator coolDown ()
    {
        yield return new WaitForSeconds(5);

        coolDownCoroutine = null;
    }
}