using UnityEngine;

public class AirPlane : MonoBehaviour
{
    [SerializeField] Rigidbody rd;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rd.AddForce(transform.forward * enginePower);
        }
        Vector3 lift = Vector3.Project(rd.linearVelocity, transform.forward);
        rd.AddForce(transform.up * lift.magnitude * liftBooster);

        rd.linearDamping = rd.linearVelocity.magnitude * drag;
        rd.angularDamping = rd.linearVelocity.magnitude + angularDrag;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rd.AddTorque(transform.up * yaw);
        rd.AddTorque(transform.right * pitch);
        rd.AddTorque(transform.forward * roll);






    }

}
