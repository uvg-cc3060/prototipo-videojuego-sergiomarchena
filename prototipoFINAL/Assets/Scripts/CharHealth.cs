using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{

	public float CurrentHealth {get; set;}
	public float MaxHealth {get; set;}
	public Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
    	MaxHealth = 20f;
    	CurrentHealth = MaxHealth;

    	HealthBar.value = CalculateHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.X))
    	{
    		DealDamage(6);
    	}
        
    }

    float CalculateHealth()
    {
    	return CurrentHealth/MaxHealth;
    }

    void DealDamage(float damage)
    {
    	CurrentHealth = CurrentHealth - damage;
    	HealthBar.value = CalculateHealth();
    	if(CurrentHealth <= 0)
    	{
    		Die();
    	}

    }

    void Die()
    {	
    	CurrentHealth = 0;
    	Debug.Log("YOU DIED YOU DIED YOU DIED YOU DIED YOU DIED YOU DIED YOU DIED YOU DIED");
    	Application.Quit();
    }
}
