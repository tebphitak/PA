using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

	public int Health = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Animator animator;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

	public PlayerMovement playerMovement;
	bool IsDead;
	bool damaged;

	void Start () {
		currentHealth = Health;
	}

	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !IsDead) {
			Dead ();
		}
	}

	void Dead (){
		IsDead = true;
		animator.SetTrigger ("IsDead");
		playerMovement.enabled = false;
	}
}
