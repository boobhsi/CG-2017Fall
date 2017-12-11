
public var cam1: Camera;
public var cam3: Camera;
public var camG: Camera;

function Start () {
    cam1.enabled = false;
    cam3.enabled = false;
    camG.enabled = true;
}

function Update () {
    if (Input.GetKeyDown(KeyCode.C)) {
        cam1.enabled = !cam1.enabled;
        cam3.enabled = !cam3.enabled;
    }
}