using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{

    [SerializeField] GameObject gameObject1;          // Reference to the first GameObject
    [SerializeField] GameObject gameObject2;          // Reference to the second GameObject

    private LineRenderer line;                           // Line Renderer

    // Use this for initialization
    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = FindObjectOfType<LineRenderer>();
        // Set the width of the Line Renderer
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.05F, 0.05F);
        line.widthCurve = curve;
        // Set the number of vertex fo the Line Renderer
        line.positionCount =2;
        // Update default position of the two vertex of the Line Renderer
        line.SetPosition(0, gameObject1.transform.position);
        line.SetPosition(1, gameObject2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the GameObjects are not null
        if (gameObject1 != null && gameObject2 != null && line != null)
        {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
    }
}