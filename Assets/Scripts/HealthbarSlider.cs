
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthbarSlider : MonoBehaviour {
    
    [Range(0, 1)]
    public float HealthPercentage;
    
    public Image Fill;
    public Image Container;
    
    public void SetHealthBar(float percentage) 
    {
        HealthPercentage = percentage;
        Fill.rectTransform.sizeDelta = new Vector2( HealthPercentage * 826, Fill.rectTransform.sizeDelta.y); 
    }
}