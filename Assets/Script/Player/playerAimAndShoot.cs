using UnityEngine;
using UnityEngine.InputSystem;

public class playerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    private GameObject bulletInst;
    [SerializeField] private Transform bulletSpawnPoint;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleGunPosition();
        HandleGunShooting();

    }
    private void HandleGunPosition()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        
        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(0.06f,0.06f,0.06f);
        if(angle >90 || angle < -90)
        {
            localScale.y = -0.06f;
        }
        else
        {
            localScale.y = 0.06f;
        }
        gun.transform.localScale = localScale;
    }
    private void HandleGunShooting()
    {
        if (Input.GetMouseButtonDown(0)) {
            audioManager.playSFX(audioManager.soundGun);
             bulletInst = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
