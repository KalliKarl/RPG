using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthui : MonoBehaviour
{
    public GameObject uiPrefab, can;
    public Transform target,target2;
    

    Transform ui,ui2;
    Image healthSlider;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main.transform;
        foreach ( Canvas c in FindObjectsOfType<Canvas>()) {
            if (c.renderMode == RenderMode.WorldSpace) {
                
                ui = Instantiate(uiPrefab,c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break; 
            }
        }

        
        ui2 = Instantiate(uiPrefab,target2).transform;
        ui2.transform.localScale = new Vector3(100f,100f,1f);
        //ui2.transform.Rotate(180f,0f,0f);
        healthSlider = ui2.GetChild(0).GetComponent<Image>();
        ui2.gameObject.SetActive(true);
        healthSlider.fillOrigin = 2;


        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChaned;

    }

    void OnHealthChaned(int maxHealth, int currentHealth) {
        if(ui != null) { 
            ui.gameObject.SetActive(true);
            float healthPercent = currentHealth / (float)maxHealth;
            healthSlider.fillAmount = healthPercent;

            can.GetComponent<Text>().text = currentHealth.ToString();
            if (currentHealth <= 0) {
                Destroy(ui.gameObject);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ui != null) {
            ui.position = target.position;
            ui.forward = -cam.forward;
        }
    }
}
