using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revertTime : MonoBehaviour
{
    [SerializeField] private bool isReverting;
    
    List<Vector3> positions;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _textMesh;
    private playerMovement _playerMovement;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isReverting = false;
        positions = new List<Vector3>();
        _textMesh.SetActive(false);
        _playerMovement = GetComponent<playerMovement>();

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
        _textMesh.SetActive(false);

    }

    void Rewind()
    {
        if(positions.Count > 0 )
        {  transform.position = positions[0];
            positions.RemoveAt(0);
            _textMesh.SetActive(true);
        }
        else
        {
            EndRewind();
        }
    }

    void Record()
    {
        if(_playerMovement.isMoving)
        {
            positions.Insert(0, transform.position);
        }
    }
}
