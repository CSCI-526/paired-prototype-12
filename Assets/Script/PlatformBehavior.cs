using UnityEngine;
using System.Collections;

public class PlatformBehavior : MonoBehaviour
{
    public float riseHeight = 2f;
    public float riseTime = 0.5f;
    public float stayTime = 3f;
    public float fallTime = 0.5f;
    
    Vector3 startPos;
    
    void Start()
    {
        startPos = transform.position;
    }
    
    public void RiseForSeconds(float sec)
    {
        StartCoroutine(RiseThenFall(sec));
    }
    
    IEnumerator RiseThenFall(float sec)
    {
        // up
        yield return MoveTo(startPos+Vector3.up*riseHeight, riseTime);
        // wait
        yield return new WaitForSeconds(sec);
        // down
        yield return MoveTo(startPos, fallTime);
    }
    
    IEnumerator MoveTo(Vector2 target, float dur)
    {
        Vector2 from = transform.position;
        float t = 0;
        while (t < dur)
        {
            t += Time.deltaTime;
            float progress = t/dur;
            transform.position = Vector3.Lerp(from, target, progress);
            yield return null;
        }
        transform.position = target;
    }
}