using UnityEngine;
using System.Collections;

public class CameraObjectFader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit[] hit = Physics.SphereCastAll(transform.position,5f,-Vector3.up,3f, LayerMask.GetMask("Level"));
        for(int i = 0; i < hit.Length; i++)
        {
            float Yoffset;
            switch (hit[i].transform.name)
            {
                case "pCone":
                    Yoffset = 1f;
                    break;
                default:
                    Yoffset = 0f;
                    break;

            }
            float distance =  transform.position.y - (hit[i].transform.position.y+Yoffset);
            Renderer renderer = hit[i].transform.GetComponent<Renderer>();
            renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,(distance/10));
        }
    }
}
