
public var cam1 : Camera;
public var cam3 : Camera;
function Start () {
    cam1.enabled = true;
    cam3.enabled = false;
}

function Update () {
    if (Input.GetKeyDown(KeyCode.C)) {
        cam1.enabled = !cam1.enabled;
        cam3.enabled = !cam3.enabled;
    }
}