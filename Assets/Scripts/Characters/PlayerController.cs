using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float life = 100f;
    public float forwardSpeed = 25f,strafeSpeed = 7.5f,hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    public Slider LifeSlider;
    [SerializeField]
    private GameObject Bullet;
    public int count = 0;
    private bool canShoot = true;
    private float fireRate = 0.5f;
    private float nextShot = -1f;
    private int maxBullet=5;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
        Cursor.lockState = CursorLockMode.Confined;
        LifeSlider.value = life;   
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(
            -mouseDistance.y * lookRateSpeed * Time.deltaTime,
            mouseDistance.x * lookRateSpeed * Time.deltaTime,
            rollInput * rollSpeed * Time.deltaTime,
            Space.Self);
        
        activeForwardSpeed = Mathf.Lerp(
            activeForwardSpeed,
            Input.GetAxisRaw("Vertical") * forwardSpeed,
            forwardAcceleration * Time.deltaTime);

        activeStrafeSpeed = Mathf.Lerp(
            activeStrafeSpeed,
            Input.GetAxisRaw("Horizontal") * strafeSpeed,
            strafeAcceleration * Time.deltaTime);

        if(Time.time > nextShot && count < maxBullet){
            canShoot = true;
        }else{
            canShoot = false;
        }

        if(Input.GetKey(KeyCode.Space) && canShoot == true){
            FireBulletCR();
            nextShot = Time.time + fireRate;   
        }     

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) 
                                + (transform.up * activeHoverSpeed * Time.deltaTime);

        LifeSlider.value = life/100;
        Debug.Log("Vida de la nave: "+ life);
    }
    
    private void FireBulletCR()
    {
        Instantiate(Bullet,transform.position,transform.rotation);
        count++;
    }
}