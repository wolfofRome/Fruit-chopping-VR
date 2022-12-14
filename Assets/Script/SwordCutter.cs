using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))] //Rigid body
public class SwordCutter : MonoBehaviour {
    
	public Material capMaterial;
    AudioSource chopSound;
    AudioSource sound1;
    void Start()
    {
        chopSound = GetComponent<AudioSource>();
        sound1 = GetComponent<AudioSource>();

    }

    //Trigger, Collision

    void OnCollisionEnter(Collision collision)
    {

        GameObject victim = collision.collider.gameObject;
        if (victim.tag == "Fruit")
        {
            GameManager.instance.GetScore();
            chopSound.Play();
            victim.tag = "Untagged";
        }
        if (GameManager.instance.retscore()==2) {
            sound1.Play();
        }
        

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
        {

            pieces[1].AddComponent<Rigidbody>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;

        }
        Destroy(pieces[0], 1);
        Destroy(pieces[1], 1);//left side & right side
    }
    

}
