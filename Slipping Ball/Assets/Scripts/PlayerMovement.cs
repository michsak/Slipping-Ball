using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    CameraMovement cameraMovement;

    //sound variables
    [SerializeField] AudioClip starGetSound;
    [SerializeField] AudioClip collisionSound;
    float regulatedVolume;

    //speed variables
    bool addingOneLevel = true;
    bool isCollision = false;
    bool actionIsStarted = true;
    bool changeMaterial = true;

    //ball variables
    [SerializeField] Material[] material;
    int materialNumber = 0;
    Vector3 ballRotation = new Vector3(15f, 0f, 10f);

    //displayment variables
    [SerializeField] int numberOfMoves = 5;
    int counter = 0;
    bool parameter = false;
    Vector3 newPlayerPosition = new Vector3(0f, 0f, 0f);
    Vector3 playerTranslation = new Vector3(0.15f, 1.75f, 4f);
    Vector3 partlyPlayerTranslation = new Vector3(0.15f, 1.75f, 4f);
    Vector3 partlyNewPlayerPosition = new Vector3(0.15f, 0f, 3.35f);

    PauseButton pauseButton;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        regulatedVolume = PlayerPrefsController.GetMasterVolume();
        pauseButton = FindObjectOfType<PauseButton>();
    }

    private void Update()
    {
        if (changeMaterial)
        {
            GetComponent<MeshRenderer>().material = material[materialNumber];
            changeMaterial = false;
        }

        if (Input.GetButtonDown("Fire1") && actionIsStarted && pauseButton.IsButtonClicked() == false)
        {
            actionIsStarted = false;
            StartCoroutine(MovingPlayerInside());
            counter += 1;
        }

        if (counter >= numberOfMoves && isCollision == false)
        {
            StartCoroutine(WaitTillNextScene());
        }
    }

    private void FixedUpdate()
    {
        if (materialNumber >= 2)       //rotate in x or z axis
        {
            transform.Rotate(ballRotation * Time.deltaTime);
        }
    }

    private IEnumerator MovingPlayerInside()
    {
        float t = 0;
        float speed = 0.8f;
        while(t < 1 && isCollision == false)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, newPlayerPosition, t);
            yield return null; 
        }

        if (counter >= 1)
        {
            SetSwitchOfPath();
        }

        if (isCollision == false  && counter < numberOfMoves)       //maybe <=
        {
            t = 0;
            speed = 0.4f;
            cameraMovement = FindObjectOfType<CameraMovement>();
            cameraMovement.SetCameraMove(false);
            while (t < 1)
            {   
                if (t < 0.5)
                {
                    t += speed * Time.deltaTime;
                }
                else
                {
                    t += speed;
                }
                transform.position = Vector3.Lerp(transform.position, partlyNewPlayerPosition, t);
                yield return null;
            }
            actionIsStarted = true;
            newPlayerPosition += playerTranslation;
            partlyNewPlayerPosition += partlyPlayerTranslation;
        }
    }

    private IEnumerator WaitTillNextScene()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
        if (addingOneLevel)
        {
            FindObjectOfType<DisplayLevel>().AddLevel();
            addingOneLevel = false;
        }
    }

    private IEnumerator WaitTillSameScene()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<LevelLoader>().LoadCurrentLevel();
        //FindObjectOfType<DisplayStarsNumber>().ResetTheStars();
    }

    private void OnCollisionEnter(Collision collision)
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        isCollision = true;
        AudioSource.PlayClipAtPoint(collisionSound, transform.position, regulatedVolume);
        if (PlayerPrefsController.GetVibrations() == 1)
        {
            Vibration.Vibrate(200);
        }
        if (cameraMovement)
        {
            cameraMovement.SetCameraOnCollision(false);
        }
        StartCoroutine(WaitTillSameScene());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)    //8 == Star
        {
            FindObjectOfType<DisplayStarsNumber>().AddStars(1);       //1 for now for beggining levels
            AudioSource.PlayClipAtPoint(starGetSound, transform.position, regulatedVolume);
            Destroy(other.gameObject);
        }
    }

    private void SetSwitchOfPath()
    {
        parameter = true;
    }

    public bool GetSwitchOfPath()
    {
        return parameter;
    }

    public void SetMaterialNumber(int newNumber)
    {
        materialNumber = newNumber;
    }
}
