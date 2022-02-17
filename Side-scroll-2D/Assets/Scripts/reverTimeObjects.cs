using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverTimeObjects : MonoBehaviour
{
    [SerializeField] private bool isReverting;
    List<Vector3> positions;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isReverting = false;
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            BeginRewind();
        }
        if(Input.GetKeyUp(KeyCode.P))
        {
            EndRewind();
        }
    }

    private void FixedUpdate() {
        if(isReverting)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    public void BeginRewind()
    {
        isReverting = true;
        _rigidbody2D.isKinematic = true;
        
    }

    public void EndRewind()
    {
        isReverting = false;
        _rigidbody2D.isKinematic = false;
    }

    void Rewind()
    {
        if(positions.Count > 0 )
        {  transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            EndRewind();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }
}
