using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour {
    Camera positionCam;

    public bool[] isActive;

    void Start(){
        isActive = new bool[] {false,false,false,false };
        positionCam = Camera.main;
    }

    void Update(){
        Up(isActive[0]);
        Down(isActive[1]);
        Left(isActive[2]);
        Right(isActive[3]);
    }

    void Up(bool value){
        if (value) {
            switch (SceneManager.GetActiveScene().name) {
                case "Game":
                    transform.Rotate(Vector3.left * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 1":
                    transform.Rotate(Vector3.left * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 2":
                    transform.Rotate(Vector3.left * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 3":
                    transform.Rotate(Vector3.left * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 4":
                    transform.Rotate(Vector3.left * Mathf.Deg2Rad * 50, Space.World);
                    break;
            }

            
            //transform.RotateAround(Vector3.zero, Vector3.right, Mathf.Deg2Rad * 50);
        }
    }
    void Down(bool value){
        if (value){
            switch (SceneManager.GetActiveScene().name) {
                case "Game":
                    transform.Rotate(Vector3.right * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 1":
                    transform.Rotate(Vector3.right * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 2":
                    transform.Rotate(Vector3.right * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 3":
                    transform.Rotate(Vector3.right * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 4":
                    transform.Rotate(Vector3.right * Mathf.Deg2Rad * 50, Space.World);
                    break;
            }

            //transform.RotateAround(Vector3.zero, Vector3.left, Mathf.Deg2Rad * 50);
        }
    }
    void Left(bool value){
        if (value){
            switch (SceneManager.GetActiveScene().name) {
                case "Game":
                    transform.Rotate(Vector3.down * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 1":
                    transform.Rotate(Vector3.down * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 2":
                    transform.Rotate(Vector3.down * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 3":
                    transform.Rotate(Vector3.down * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 4":
                    transform.Rotate(Vector3.down * Mathf.Deg2Rad * 50, Space.World);
                    break;
            }

            //transform.RotateAround(Vector3.zero, Vector3.up, Mathf.Deg2Rad * 50);
        }
    }
    void Right(bool value){
        if (value){
            switch (SceneManager.GetActiveScene().name) {
                case "Game":
                    transform.Rotate(Vector3.up * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 1":
                    transform.Rotate(Vector3.up * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 2":
                    transform.Rotate(Vector3.up * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 3":
                    transform.Rotate(Vector3.up * Mathf.Deg2Rad * 50, Space.World);
                    break;
                case "Game 4":
                    transform.Rotate(Vector3.up * Mathf.Deg2Rad * 50, Space.World);
                    break;
            }
            
            //transform.RotateAround(Vector3.zero,Vector3.down, Mathf.Deg2Rad * 50);
        }
    }

    public void Reset(){
        positionCam.transform.position = new Vector3(0,0,-10);
        positionCam.fieldOfView = 60;

        switch (SceneManager.GetActiveScene().name) {
            case "Game":
                transform.rotation = Quaternion.Euler(-90, 0, 0);
                break;
            case "Game 1":
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case "Game 2":
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "Game 3":
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "Game 4":
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }

    public void AbriLink(string value)
    {
        Application.OpenURL(value);
    }

    public bool[] IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
}