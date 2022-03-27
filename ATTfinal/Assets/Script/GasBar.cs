using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public static GasBar instance;
    private Gas gas;
    public float gasAm2;
    public bool isUseGas2;
    private Image barImage;
    private void Awake()
    {
        instance = this;
        barImage = transform.Find("bar").GetComponent<Image>();
        gas = new Gas();

    }
    
    private void Update()
    {
        if (RefillGas.instance.isFill)
        {
            gas.gasRegenAmount = 1000f;
        }
        else
        {
          
            gas.gasRegenAmount = 0f;
        }
        isUseGas2 = Player.instance.isUseGas;
        gas.Update();
        gasAm2 = gas.gasAmount;
        barImage.fillAmount = gas.GetGasNormalized();
        if (isUseGas2)
        {
            gas.SpendGas( 4f);
        }
      
    }
}

public class Gas
{
    
    public const int GAS_MAX = 10000;
    public float gasAmount;
    public float gasRegenAmount;

    
    public Gas()
    {
        gasAmount = 5000;
        gasRegenAmount = 0f;
    }
    public void Update()
    {
        gasAmount += gasRegenAmount * Time.deltaTime;
        gasAmount = Mathf.Clamp(gasAmount, 0f, GAS_MAX);
    }
    public void SpendGas(float amount)
    {
        if (gasAmount >= amount)
        {
            gasAmount -= amount;
        }
    }
    public float GetGasNormalized()
    {
        return gasAmount / GAS_MAX;
    }
}
