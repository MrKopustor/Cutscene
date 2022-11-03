using UnityEngine;

public class animationStateControllerAdam : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    int VelocityHash;
    
    // Start is called before the first frame update
    void Start()
    {
        //set reference for animator
        animator = GetComponent<Animator>();
        
        //increases performance
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        // get key input from player
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed)
        {
            velocity += Time.deltaTime * acceleration;
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}
