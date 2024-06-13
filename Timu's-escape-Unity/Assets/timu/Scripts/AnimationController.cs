using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void turn(float from, float to, Transform timuTransform){
        timuTransform.rotation = Quaternion.Euler(timuTransform.eulerAngles.x, Mathf.Lerp(timuTransform.eulerAngles.y, 150f, 1f), timuTransform.eulerAngles.z);
    }
}
