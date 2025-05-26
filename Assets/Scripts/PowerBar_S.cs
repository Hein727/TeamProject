    using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar_S : MonoBehaviour
{
    private GameObject shootingObject;
    public Image image;
    public Image image1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootingObject = GameObject.FindGameObjectWithTag("Shooting");
    }

    // Update is called once per frame
    void Update()
    {        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            image.enabled = true;
            image1.enabled = true;
            if (shootingObject)
            {
                float power = shootingObject.GetComponent<Shooting_S>().power;
                image.fillAmount = Mathf.Clamp01(power);
            }
            Debug.Log("Player" + player);
        }
        else
        {
            image.enabled = false;
            image1.enabled = false; 
        }

    }
}
