using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManagers : MonoBehaviour
{
    public List<GameManagersEditor> anjay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() 
    {
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.red);
    }
}

[System.Serializable]
public class GameManagersEditor
{
    public string nama;
    public int level;
    public enum attackType
    {
        melee,
        ranged
    }
    public attackType _attackType;
}
