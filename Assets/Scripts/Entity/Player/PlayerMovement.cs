using DesertStormZombies.Utility;
using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform torso;
    [SerializeField] private AudioSource audioSource;

    [Header("Movement")]
    [SerializeField] private float movementSmoothness;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float jumpForce;

    [Header("Mouse")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float rotationSmoothness;
    [SerializeField] private float minVerticalAngle;
    [SerializeField] private float maxVerticalAngle;

    [Header("Sound")]
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip walkSound;

    [Header("Input")]
    [SerializeField] private MovementInput input;

    private bool isGrounded;

    private CapsuleCollider capsule;

    private Rigidbody rigidbody3D;

    private SmoothVelocity velocityX;
    private SmoothVelocity velocityZ;

    private SmoothRotation rotationX;
    private SmoothRotation rotationY;

    private readonly RaycastHit[] wallCastResults = new RaycastHit[8];
    private readonly RaycastHit[] groundCastResults = new RaycastHit[8];

    private IntervalTimer walkTimer;

    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();

        rigidbody3D = GetComponent<Rigidbody>();
        rigidbody3D.constraints = RigidbodyConstraints.FreezeRotation;

        rotationX = new SmoothRotation(input.RotateX * mouseSensitivity);
        rotationY = new SmoothRotation(input.RotateY * mouseSensitivity);
        velocityX = new SmoothVelocity();
        velocityZ = new SmoothVelocity();

        Cursor.lockState = CursorLockMode.Locked;

        torso.SetPositionAndRotation(transform.position, transform.rotation);
    }

    private void OnCollisionStay(Collision collision)
    {
        var bounds = capsule.bounds;
        var extents = bounds.extents;
        var radius = extents.x - 0.01f;
        _ = Physics.SphereCastNonAlloc(bounds.center, radius, Vector3.down,
            groundCastResults, extents.y - radius * 0.5f, ~0, QueryTriggerInteraction.Ignore);

        if (!groundCastResults.Any(hit => hit.collider != null && hit.collider != capsule))
        {
            return;
        }

        for (var i = 0; i < groundCastResults.Length; i++)
        {
            groundCastResults[i] = new RaycastHit();
        }

        isGrounded = true;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        isGrounded = false;
    }

    private void Update()
    {
        torso.position = transform.position;

        Jump();

        if (isGrounded && rigidbody3D.velocity.sqrMagnitude > 0.1f)
        {
            audioSource.clip = input.Run ? walkSound : runSound;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    private void Jump()
    {
        if (!isGrounded || !input.Jump)
        {
            return;
        }

        isGrounded = false;
        rigidbody3D.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Move()
    {
        var direction = new Vector3(input.Move, 0f, input.Strafe).normalized;
        var worldDirection = transform.TransformDirection(direction);
        var velocity = worldDirection * (input.Run ? runningSpeed : walkingSpeed);

        if (CheckCollisionsWithWalls(velocity))
        {
            velocityX.Current = velocityZ.Current = 0f;
            return;
        }

        var smoothX = velocityX.Update(velocity.x, movementSmoothness);
        var smoothZ = velocityZ.Update(velocity.z, movementSmoothness);
        var force = new Vector3(smoothX - rigidbody3D.velocity.x, 0f, smoothZ - rigidbody3D.velocity.z);

        rigidbody3D.AddForce(force, ForceMode.VelocityChange);
    }

    private bool CheckCollisionsWithWalls(Vector3 velocity)
    {
        if (isGrounded)
        {
            return false;
        }
            
        var bounds = capsule.bounds;
        var radius = capsule.radius;
        var halfHeight = capsule.height * 0.5f - radius * 1.0f;
        var point1 = bounds.center;
        var point2 = bounds.center;

        point1.y += halfHeight;
        point2.y -= halfHeight;

        _ = Physics.CapsuleCastNonAlloc(point1, point2, radius, velocity.normalized, wallCastResults,
            radius * 0.04f, ~0, QueryTriggerInteraction.Ignore);

        if (!wallCastResults.Any(hit => hit.collider != null && hit.collider != capsule))
        {
            return false;
        }
           
        for (var i = 0; i < wallCastResults.Length; i++)
        {
            wallCastResults[i] = new RaycastHit();
        }

        return true;
    }

    private void Rotate()
    {
        var rotationX = this.rotationX.Update(input.RotateX * mouseSensitivity, rotationSmoothness);
        var rotationY = this.rotationY.Update(input.RotateY * mouseSensitivity, rotationSmoothness);
        var clampedY = RestrictVerticalRotation(rotationY);

        this.rotationY.Current = clampedY;

        var worldUp = torso.InverseTransformDirection(Vector3.up);
        var rotation = torso.rotation *
                       Quaternion.AngleAxis(rotationX, worldUp) *
                       Quaternion.AngleAxis(clampedY, Vector3.left);

        transform.eulerAngles = new Vector3(0f, rotation.eulerAngles.y, 0f);
        torso.rotation = rotation;
    }

    private float RestrictVerticalRotation(float mouseY)
    {
        var currentAngle = NormalizeAngle(transform.eulerAngles.x);

        return Mathf.Clamp(mouseY, minVerticalAngle + currentAngle + 0.01f, maxVerticalAngle + currentAngle - 0.01f);
    }

    private float NormalizeAngle(float angleDegrees)
    {
        if (angleDegrees > 180f)
        {
            angleDegrees -= 360f;
        }

        if (angleDegrees <= -180f)
        {
            angleDegrees += 360f;
        }

        return angleDegrees;
    }

    private class SmoothVelocity
    {
        private float current;
        private float currentVelocity;

        public float Update(float target, float smoothTime) =>current = Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime);

        public float Current
        {
            set => current = value;
        }
    }

    private class SmoothRotation
    {
        private float current;
        private float currentVelocity;

        public SmoothRotation(float startAngle)
        {
            current = startAngle;
        }

        public float Update(float target, float smoothTime) => current = Mathf.SmoothDampAngle(current, target, ref currentVelocity, smoothTime);

        public float Current
        {
            set => current = value;
        }
    }

    [Serializable]
    private class MovementInput
    {
        [SerializeField]
        private string rotateX = "Mouse X";

        [SerializeField]
        private string rotateY = "Mouse Y";

        [SerializeField]
        private string move = "Horizontal";

        [SerializeField]
        private string strafe = "Vertical";

        [SerializeField]
        private string jump = "Jump";

        [SerializeField]
        private string run = "Fire3";


        public float RotateX => Input.GetAxisRaw(rotateX);
 
        public float RotateY => Input.GetAxisRaw(rotateY);
  
        public float Move => Input.GetAxisRaw(move);
        
        public float Strafe => Input.GetAxisRaw(strafe);
         
        public bool Run => Input.GetButton(run);
          
        public bool Jump => Input.GetButtonDown(jump);
    }
}
