using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour
{

    public Sprite[] mySprites;
    private int index = 0;
    private SpriteRenderer mySpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
   
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        
    }

   
    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.08f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
