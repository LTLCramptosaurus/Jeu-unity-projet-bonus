using UnityEngine;
using UnityEngine.UI;

public class HpBarre : MonoBehaviour
{
    public Slider m_slider;

    public void UpdateSlider(float maxHp, float CurrentHp)
    {
        m_slider.value = CurrentHp / maxHp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
