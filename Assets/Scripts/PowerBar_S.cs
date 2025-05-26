    using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar_S : MonoBehaviour
{
    public new GameObject gameObject;
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject = GameObject.FindGameObjectWithTag("Shooting");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject)
        {
            float power = gameObject.GetComponent<Shooting_S>().power;
            image.fillAmount = Mathf.Clamp01(power);
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
