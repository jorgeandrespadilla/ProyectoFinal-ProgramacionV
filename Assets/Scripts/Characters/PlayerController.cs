using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public readonly float damage = 3f;
    public float life = 100f;
    public float remainingLife;
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    public Slider LifeSlider;
    public int count = 0;
    [SerializeField]
    private GameObject Bullet;
    private bool canShoot = true;
    private float fireRate = 0.5f;
    private float nextShot = -1f;
    private int maxBullet = 5;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
        Cursor.lockState = CursorLockMode.Confined;
        remainingLife = life;
        LifeSlider.value = life;
        var bulletController = Bullet.GetComponent<BulletMovement>();
        bulletController.setCreator(this.gameObject);
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

        canShoot = (Time.time > nextShot && count < maxBullet);

        if (Input.GetKey(KeyCode.Space) && canShoot == true)
        {
            FireBulletCR();
            nextShot = Time.time + fireRate;
        }

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime)
                                + (transform.up * activeHoverSpeed * Time.deltaTime);

        LifeSlider.value = remainingLife / life;
    }

    private void FireBulletCR()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        count++;
    }
}