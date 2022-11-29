using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]//Rigid body set up automatically
public class SwordCutter : MonoBehaviour {
    
	public Material capMaterial;
    AudioSource chopSound;
    void Start()
    {
        chopSound = GetComponent<AudioSource>();

    }

    //A function called when an object collides. 
    //TriggerEnter is for physical calculation X CollisionEnter is suitable for Fruit Ninja.

    void OnCollisionEnter(Collision collision)
    {

        GameObject victim = collision.collider.gameObject;
        if (victim.tag == "Fruit")
        {
            GameManager.instance.GetScore();
            chopSound.Play();
            victim.tag = "Untagged";
        }


        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
        {

            pieces[1].AddComponent<Rigidbody>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;

        }
        Destroy(pieces[0], 1);
        Destroy(pieces[1], 1);//Remove the cut pieces (left side & right side)
    }
    

}
