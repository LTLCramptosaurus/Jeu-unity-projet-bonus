using UnityEngine;
using UnityEngine.UI;

public class HpBarre : MonoBehaviour
{
    public Slider slider;

    public void UpdateSlider(float maxHp, float CurrentHp)
    {
        slider.value = CurrentHp / maxHp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
