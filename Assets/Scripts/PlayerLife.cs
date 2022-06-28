using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
   [SerializeField] AudioSource DeathSound;
   bool dead = false;

   //Need to use update in order to keep getting the position of the player every frame for this logic to work
   private void Update()
   {
       if (transform.position.y < -1.5f && !dead)
       {
           Die();
       }
   }

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Enemy Body"))
       {
           GetComponent<MeshRenderer>().enabled = false;
           GetComponent<Rigidbody>().isKinematic = true;
           GetComponent<PlayerMovement>().enabled = false;
           Die();
       }
   }

   void Die()
   {
       //Invoke makes level load a little later after death
       Invoke(nameof(ReloadLevel), 1.3f);
       dead = true;
       DeathSound.Play();
    }

   void ReloadLevel()
   {
       //Loads the current level then loads the active scene that is current in the game
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
