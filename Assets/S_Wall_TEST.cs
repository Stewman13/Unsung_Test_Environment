using UnityEngine;
using System.Collections;

public class S_Wall_TEST : MonoBehaviour {

	public GameObject player;
	public LineRenderer line;
	private BoxCollider col;
	private Vector3 playerPos;

	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		col = gameObject.AddComponent<BoxCollider>();

	}
	void Update () {
		Testing();
		playerPos = player.transform.position;
	}

	void Testing(){
	
		//change LineRenderer's Material, to make visible line
		line.SetWidth (0.2f, 0.2f);
		line.SetPosition(0, transform.position);
		line.SetPosition(1, playerPos);
		line.enabled = true;

		// make our position look at player
		Vector3 direction = player.transform.position - transform.position;
		transform.right = direction.normalized;
		
		// resize collider to fit line renderer
		col.center = Vector3.right * direction.magnitude /2;
		col.size = new Vector3(direction.magnitude, 0.2f,0.2f);
		col.isTrigger = true;

	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Wall")
		{
			print ("arrrghhh");

			Color newColour = other.renderer.material.color;
			newColour.a = 0.2f;
			other.renderer.material.color = newColour;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Wall")
		{
			print ("arrrghhh");
			Color newColour = other.renderer.material.color;
			newColour.a = 1.0f;
			other.renderer.material.color = newColour;
		}
	}
}
