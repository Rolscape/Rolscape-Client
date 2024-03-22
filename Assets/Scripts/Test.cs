using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Managers.Resource.Instantiate("Player");
        go.name = "Player";
        
        GameObject student = Managers.Resource.Instantiate("StudentRoot");
        student.transform.SetParent(go.transform);

        go.GetOrAddComponent<Student>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
