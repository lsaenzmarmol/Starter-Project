using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Text countDownText; 
    public Text InstructionsText;
    public float speed;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip eatingClip;
    public AudioClip instructionAudio;
    public AudioClip MainMusic;
    public AudioClip WinMusic;
    public AudioClip LoseMusic;
    int enemiesKilled;
    public CountDown StartTimer; 
    public static Player instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlaySound(instructionAudio);
        InstructionsText.text = "Move the bunny using the arrow keys and eat all the carrots before time runs out";
        Invoke("TextDelay",2f);
    }

    void TextDelay()
    {
        InstructionsText.gameObject.SetActive(false);
        StartTimer.enabled = true;
        PlaySound2(MainMusic);
    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKey(KeyCode.UpArrow))
           {
                transform.position = new Vector2(    
                    transform.position.x,transform.position.y + speed * Time.deltaTime);
           }
           else if (Input.GetKey(KeyCode.DownArrow))
           {
                transform.position = new Vector2(    
                    transform.position.x,transform.position.y - speed * Time.deltaTime);
           }
           else if (Input.GetKey(KeyCode.RightArrow))
           {
                transform.position = new Vector2(    
                    transform.position.x + speed * Time.deltaTime,transform.position.y);
           }
           else if (Input.GetKey(KeyCode.LeftArrow))
           {
                transform.position = new Vector2(    
                    transform.position.x - speed  * Time.deltaTime,transform.position.y);
           }      
    }
    public void PlaySound2(AudioClip clip2)
    {
        audioSource2.clip=clip2;
        audioSource2.Play();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip=clip;
        audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PlaySound(eatingClip);
            enemiesKilled++;
            if(enemiesKilled == enemySpawner.GetNumberOfEnemies())
            {
                countDownText.text = "You Won!";
                PlaySound2(WinMusic);
                Time.timeScale = 0;
            } 
        } 
    }
    

}

