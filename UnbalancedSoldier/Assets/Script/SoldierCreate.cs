using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierCreate : MonoBehaviour
{
    SoldierArmy Soldierarmy;
    [SerializeField] GameObject soldierPanel;
    [SerializeField] Slider soldierSlider;
    [SerializeField] Button soldierBtn;
    public float crossSpeed;
    public float soldierSleep;
    bool barCrossDecrease;
    bool barStopper;

    // Start is called before the first frame update
    void Start()
    {
        soldierBtn.onClick.AddListener(ShootTouchPlay);
        Soldierarmy = GetComponent<SoldierArmy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SoldierBar();
    }

    void SoldierBar()
    {
        if (!barStopper)
        {
            if (!barCrossDecrease)
            {
                soldierSlider.value += Time.deltaTime * crossSpeed;

                if (soldierSlider.value >= soldierSlider.maxValue)
                {
                    barCrossDecrease = true;
                }
            }

            if (barCrossDecrease)
            {
                soldierSlider.value -= Time.deltaTime * crossSpeed;

                if (soldierSlider.value <= 0)
                {
                    barCrossDecrease = false;
                }
            }
        }
    }

    void ShootTouchPlay()
    {
        Soldierarmy.SoldierCreator(soldierSlider.value);
        barStopper = true;
        StartCoroutine(SliderReset());
    }

    IEnumerator SliderReset()
    {
        yield return new WaitForSeconds(1f);
        soldierPanel.SetActive(false);
        soldierSlider.value = 0;
        barCrossDecrease = false;
        yield return new WaitForSeconds(soldierSleep);
        barStopper = false;
        soldierPanel.SetActive(true);
    }

}
