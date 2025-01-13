using UnityEngine;

public class Background : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float movement = cam.transform.position.x*(1-parallaxEffect);
        transform.position = new Vector3(dist+startPos,transform.position.y, transform.position.z);

        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length) { 
            startPos -= length;
        }

    }
}
