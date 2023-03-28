using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogscript : MonoBehaviour
{
    ParticleSystem pS;
    public ParticleSystemShapeType boxShape = ParticleSystemShapeType.Box;
    public Vector3 boxSize;
    ParticleSystem.ShapeModule shape;
    // Start is called before the first frame update
    void Start()
    {
        pS = this.gameObject.GetComponent<ParticleSystem>();
        shape = pS.shape;
        shape.shapeType = boxShape;
    }

    // Update is called once per frame
    void Update()
    {
        boxSize = this.GetComponentInParent<Transform>().localScale;
        shape.scale = boxSize;
    }
}
