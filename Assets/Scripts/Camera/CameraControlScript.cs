    using UnityEngine;
    using System.Collections;
     
     
    public class CameraControlScript : MonoBehaviour {
     
    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
     
    public float mHdg = 0F;
    public float mPitch = 0F;
     
    void Start()
    {
    // owt?
    }
     
    void Update()
    {
    if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
    return;
     
    float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
    float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;
     
			
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
    {
    Strafe(deltaX);
    ChangeHeight(deltaY);
    }
    else
    {
    if (Input.GetMouseButton(0))
    {
    MoveForwards(deltaY);
    ChangeHeading(deltaX);
    }
    else if (Input.GetMouseButton(1))
    {
    ChangeHeading(deltaX);
    ChangePitch(-deltaY);
    }
    }
    }
     
    void MoveForwards(float aVal)
    {
    Vector3 fwd = transform.forward;
    fwd.y = 0;
    fwd.Normalize();
    transform.position += aVal * fwd;
    }
     
    void Strafe(float aVal)
    {
    transform.position += aVal * transform.right;
    }
     
    void ChangeHeight(float aVal)
    {
    transform.position += aVal * Vector3.up;
    }
     
    void ChangeHeading(float aVal)
    {
    mHdg += aVal;
    WrapAngle(ref mHdg);
    transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }
     
    void ChangePitch(float aVal)
    {
    mPitch += aVal;
    WrapAngle(ref mPitch);
    transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }
     
    public static void WrapAngle(ref float angle)
    {
    if (angle < -360F)
    angle += 360F;
    if (angle > 360F)
    angle -= 360F;
    }
	
	
   public bool Rascunho = true;
   public bool City = true;
   public GameObject ObjRascunho;
   public GameObject objReconstrucao;
	
    void OnGUI()
    {
      if (GUI.Button(new Rect(30, 5, 200, 30), "Ativar / Desativar Rascunho"))
	  {
	     if(Rascunho)
			{
				ObjRascunho.SetActive(false);
				Rascunho = !Rascunho;
			}
			else
			{
				ObjRascunho.SetActive(true);
				Rascunho = !Rascunho;
			}
	  }
		
	  if (GUI.Button(new Rect(30, 40, 200, 30), "Ativar / Desativar Reconstrucao"))
	  {
	     if(City)
			{
				objReconstrucao.SetActive(false);
				City = !City;
			}
			else
			{
				objReconstrucao.SetActive(true);
				City = !City;
			}
	  }
	  

    }
}
	
