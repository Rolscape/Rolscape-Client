using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject student = Managers.Resource.Instantiate("StudentRoot");
        student.transform.SetParent(transform);

        gameObject.GetOrAddComponent<Student>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
