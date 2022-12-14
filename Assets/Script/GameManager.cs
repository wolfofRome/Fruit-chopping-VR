using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject scoreText;
    public GameObject bestScoreText;
    public GameObject timeText;
    public GameObject finishText;
    public GameObject spawner;
    public GameObject board;
   
    public Image fadeImageRight;
    public Image fadeImageLeft;
    public bool gameStart;

    private int score;
    private float time;
    private int fruitNum;
   
    private int round;
    private float gameTime;

   
   

    AudioSource timeupSound;
    AudioSource sound1;

    //initial run function
    void Awake () {
        instance = this;
       
        gameTime = 60.0f;



    }

    void Start () {

        gameStart = false;
        round = 1; //round 1
        score = 0;
        time = gameTime;
        timeupSound = GetComponent<AudioSource> ();
        sound1 = GetComponent<AudioSource>();

    }

    void Update () {
      //  scoreText.GetComponent<TextMesh>().text = score.ToString();

        if (gameStart == true && round == 1) {
            scoreText.GetComponent<TextMesh>().text = "Your current score:" + score.ToString();
            bestScoreText.GetComponent<TextMesh> ().text = "BEST: " + GetBestScore ();
            timeText.GetComponent<TextMesh> ().text = time.ToString ("F1") + "seconds";
            time -= Time.deltaTime;

            //1 round 끝

            if (time < 0 && round == 1) {
                round = 2;
                gameStart = false;
                time = 0;
                fruitNum = spawner.GetComponent<FruitNinja> ().fruitNum;
                //1 round When finished, send concentration data
             
                StartCoroutine ("Round2");
            }
        } else if (gameStart == true && round == 2) {
            scoreText.GetComponent<TextMesh> ().text = score.ToString ();
            bestScoreText.GetComponent<TextMesh> ().text = "BEST: " + GetBestScore ();
            timeText.GetComponent<TextMesh> ().text = time.ToString ("F1") + "seconds";
            time -= Time.deltaTime;

           
        }

    }

    void UpdateBestScore () {
        if (GetBestScore () < score)
            PlayerPrefs.SetInt ("BestScore", score);
    }

    int GetBestScore () {

        int bestScore = PlayerPrefs.GetInt ("BestScore");

        return bestScore;

    }

    public void GetScore () {

        score++;
        if (score % 5 == 0)
        {
            sound1.Play();
        }
        


    }

    public int retscore()
    {

        return score;


    }

    IEnumerator Finish () {

        board.SetActive (false);

        timeupSound.Play ();

        finishText.GetComponent<TextMesh> ().text = "Times Up!";

        Debug.Log (score + " " + fruitNum);

        yield return new WaitForSeconds (2f);

        finishText.GetComponent<TextMesh> ().text = (((float) score / fruitNum) * 100).ToString ("F1");

        yield return new WaitForSeconds (4f);

        UpdateBestScore ();

        SceneManager.LoadScene (0); 

    }


    
}