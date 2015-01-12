using UnityEngine;
using System.Collections;

using System.Xml;
using System.IO;

public class XMLsample : MonoBehaviour 
{
	public string filePath = "map1.xml";


	// Use this for initialization
	void Start () 
	{
		TextAsset fileName = Resources.Load (filePath) as TextAsset;
		XmlPerse (fileName.text);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	public void XmlPerse (string xmlString)
	{

//		Debug.Log( xmlString );
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(new StringReader(xmlString));

		XmlNode root = xmlDoc.FirstChild;

		XmlNodeList layerList = xmlDoc.GetElementsByTagName("layer");

		XmlNodeList tiles = layerList [0].ChildNodes [0].ChildNodes;

//		Debugger.Array<XmlNode> (tiles);

		foreach (XmlNode tile in tiles) {
			string gid = tile.Attributes ["gid"].Value;
			Debug.Log(gid);
		}
//

//		Debug.Log( root.Name );
//		Debug.Log( layerList[0].ChildNodes[0].ChildNodes.Count); // layer > data > tile
//		Debug.Log( layerList[1]);
//		Debug.Log( layerList[0].Attributes["name"].Value );
//		Debug.Log( layerList[1].Attributes["name"].Value );



	}
}
