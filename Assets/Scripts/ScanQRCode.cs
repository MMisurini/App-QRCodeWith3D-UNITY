using UnityEngine;
using System.Collections;
using ZXing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScanQRCode : MonoBehaviour 
{
	private WebCamTexture webCamTexture = null;
	private string resultText;
    [SerializeField]
    private Image quadImage = null;
    [SerializeField]
	private Material quadMat = null;
    [SerializeField]
    private Text error = null;

    // Use this for initialization
    void Awake () {
        webCamTexture = new WebCamTexture();
		WebCamDevice[] devices = WebCamTexture.devices;
		webCamTexture.deviceName = devices[0].name;
		quadMat = quadImage.GetComponent<Image>().material;
		quadMat.mainTexture = webCamTexture;
		webCamTexture.Play ();

		InvokeRepeating ("Scan", 1f, 1f);
	}

    void Update(){
        if (quadMat == null) {
            quadMat = quadImage.GetComponent<Image>().material;
            quadMat.mainTexture = webCamTexture;
        }

        transform.rotation = Quaternion.AngleAxis(webCamTexture.videoRotationAngle, -Vector3.forward);


		var webCamAspect = (float)webCamTexture.width / webCamTexture.height;

		var rot90 = (webCamTexture.videoRotationAngle / 90) % 2 != 0;
		if (rot90) {
			webCamAspect = 1.0f / webCamAspect;
		}

		if (!rot90)
			transform.localScale = new Vector3 (1, 1, 1);
     
			
		var mirror = webCamTexture.videoVerticallyMirrored;
		quadMat.mainTextureOffset = new Vector2(0, mirror ? 1 : 0);
		quadMat.mainTextureScale = new Vector2(1, mirror ? -1 : 1);

        Scan();
    }

	private void Scan(){
		if (webCamTexture != null && webCamTexture.width > 100) {
			resultText = Decode(webCamTexture.GetPixels32 (), webCamTexture.width, webCamTexture.height);
            if (resultText != null) {
                Check(resultText);
            } else {
                error.text = "Coloque a Câmera sobre o QR Code.";
                error.color = Color.white;
            }
        }
	}

    void Check(string value) {
        switch (value) {
            default:
                error.text = "Nenhum QR válido encontrado.";
                error.color = Color.red;
                error.fontStyle = FontStyle.Bold;
                resultText = null;
                break;
            case "Divamax":
                SceneManager.LoadScene("Game");
                break;
            case "Bosch":
                SceneManager.LoadScene("Game 1");
                break;
            case "Ishida":
                SceneManager.LoadScene("Game 2");
                break;
            case "Varpe":
                SceneManager.LoadScene("Game 3");
                break;
            case "Hawmak":
                SceneManager.LoadScene("Game 4");
                break;
            case "FCivil":
                Application.OpenURL("");
                break;
        }
    }

	public string Decode(Color32[] colors, int width, int height)
	{
		BarcodeReader reader = new BarcodeReader ();
		var result = reader.Decode (colors, width, height);
		if (result != null) 
		{
			return result.Text;
		}
		return null;
	}

}
