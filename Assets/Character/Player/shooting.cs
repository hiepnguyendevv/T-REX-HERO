using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousPos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private Animator anim;

    
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire=false;
            //anim.SetTrigger("Shoot");
            Instantiate(bullet, bulletTransform.position, Quaternion.Euler(0,0,rotZ));
        }
    }
}
