using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNinja : MonoBehaviour
{
    public GameObject[] fruitPrefab;
    public int fruitNum;
    GameObject manager;
    AudioSource fruitUp;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        fruitUp = GetComponent<AudioSource>();
        fruitNum = 0;
        StartCoroutine("SpawnFruit");
    }
    

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            start = GameManager.instance.gameStart;
            //wait until start
            if (start == true)
             {
                GameObject go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);//Randomly select one of the fruits
                fruitUp.Play();//sound effect
                fruitNum++;
                Rigidbody temp = go.GetComponent<Rigidbody>();//Get selected fruit information

                temp.velocity = new Vector3(0f, Random.Range(4f, 6f), -0.5f);//speed setting
                temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));//Angular velocity setting (object rotation)
                temp.useGravity = true;//gravity settings

                Vector3 pos = transform.position;
                pos.x += Random.Range(-0.7f, 0.7f);//Set axis x  position randomly
                go.transform.position = pos;//positioning


                yield return new WaitForSeconds(1.2f);//wait a few seconds
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
