using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera  cam;

    public string hitPOS = "Hit: ";

    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target !=null) {
                    target.ReactToHit();
                }
                else {
                    StartCoroutine(SphereIndicator(hit.point));
                }

                hitPOS = "Hit: " + hit.point.ToString();
            }
        }
    }

    void OnGUI() {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;

        int pos = 30;
        float posX = cam.pixelWidth / 2 - pos / 4;
        float posY = cam.pixelHeight / 2 - pos / 2;
        GUI.Label(new Rect(posX, posY, pos, pos), "+", myStyle);
        
        GUI.Label(new Rect(0, 0, pos, pos), hitPOS, myStyle);
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
