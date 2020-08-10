using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{ 
    [SerializeField] private GameObject gameObject;
    [SerializeField] GameObject sectionHolder;
    [SerializeField] Transform starBody;
    [SerializeField] float number = 42;
    [SerializeField] float minNumber = 1f;
    [SerializeField] float maxNumber = 1.2f;
    [SerializeField] int totalTorusesNumber = 5;
    [SerializeField] float starTranslation = 0.01f;

    //Torus position
    Vector3 torusTranslation = new Vector3(0.15f, 1.75f, 4f);
    Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    Color color;
    Vector3 starPosition;

    void Start()
    {
        float totalNumber = 48;

        starPosition = new Vector3(starTranslation * (totalNumber - number), 0.11f * (totalNumber - number), 0);
        color = new Color(0f, Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", color);

        GenerateTorusFromPieces();
        GenerateRemainingToruses();
    }

    private void GenerateTorusFromPieces()
    {
        for (int i = 0; i <= number; i++)
        {
            GameObject section = GameObject.Instantiate(gameObject, sectionHolder.transform);
            section.transform.Rotate(0, 0, i * 7.5f);
        }
        starBody.position = starPosition;
    }

    private void GenerateRemainingToruses()
    {
        for (int j = 0; j <= totalTorusesNumber - 2; j++)
        {
            float min = Random.Range(-minNumber, -maxNumber);
            float max = Random.Range(minNumber, maxNumber);
            float nb;
            if (j % 2 == 0) { nb = min; }
            else { nb = max; }

            GameObject torus = GameObject.Instantiate(sectionHolder);
            torus.AddComponent<Rotate>().SetTorus(torus.transform);
            torus.GetComponent<Rotate>().SetAnglePerTime(nb);

            torus.transform.position = originalPosition + torusTranslation;
            torus.transform.Rotate(0, 0, j * j * j * Random.Range(-10f, 10f));
            originalPosition += torusTranslation;
        }
    }
}
