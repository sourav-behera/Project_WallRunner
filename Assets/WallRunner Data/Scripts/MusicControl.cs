using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{   
    public static MusicControl musicControl;

    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (musicControl == null) musicControl = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}