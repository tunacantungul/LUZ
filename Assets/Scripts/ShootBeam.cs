using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeam : MonoBehaviour
{
    [SerializeField] GameObject beamPrefab;  
    [SerializeField] Transform firePoint;   
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject beamLightPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = (mousePos - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        lineRenderer.SetPosition(0, firePoint.position);
        GameObject beam = Instantiate(beamPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        Vector3 extendedPos = mousePos + (direction * 1f);
        lineRenderer.SetPosition(1, extendedPos);
        
        if (beamLightPrefab != null)
        {
            GameObject beamLight = Instantiate(beamLightPrefab, firePoint.position, Quaternion.identity);
            Destroy(beamLight, 0.2f);
        }
        
        StartCoroutine(PulseBeam());
        //lineRenderer.SetPosition(1, mousePos);
        float beamLength = Vector2.Distance(mousePos, firePoint.position);
        beam.transform.localScale = new Vector3(beamLength, 0.5f, 0.5f);
        Invoke("setToZero", 0.2f);
        Destroy(beam, 0.2f);
    }
    
    void setToZero()
    {
        lineRenderer.SetPosition(1, firePoint.position);
    }
    
    IEnumerator PulseBeam()
    {
        float time = 0; 
        while (time < 0.2f)
        {
            lineRenderer.startWidth = Mathf.Lerp(0.1f, 0.2f, Mathf.PingPong(Time.time * 5, 1));
            lineRenderer.endWidth = Mathf.Lerp(0.1f, 0.2f, Mathf.PingPong(Time.time * 5, 1));

            time += Time.deltaTime; 
            yield return null; 
            Debug.Log("pulsing");
        }
    }

}