using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 4f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddletoBallVector;
    bool hasStarted = false;

    // reused references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        paddletoBallVector = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody.velocity = new Vector2(xPush,yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddletoBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
    }
}
