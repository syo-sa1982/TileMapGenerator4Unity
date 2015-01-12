using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.IO;

public class XmlMapGenerator
{
	private string xmlPath;
	// 画像のパス
	private string spriteFileName;
	private string spriteName;


	private int mapWidth;
	private int mapHight;
	private int tileWidth;
	private int tileHight;

	private Dictionary<string, XmlNodeList> tileDatas;


	/**
	 * map生成
	 */
	public void MapGenerate ()
	{
	}

	/**
	 * XMLをバラしてmap生成に必要な情報を取得 
	 */
	public void XmlPerse (string xmlString)
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(new StringReader(xmlString));

		XmlNode root = xmlDoc.FirstChild;

		// マップ情報のセット
		XmlNodeList mapList = xmlDoc.GetElementsByTagName("map");

		mapWidth = int.Parse(mapList [0].Attributes ["width"].Value);
		mapHight = int.Parse(mapList [0].Attributes ["hight"].Value);
		tileWidth = int.Parse(mapList [0].Attributes ["tilewidth"].Value);
		tileHight = int.Parse(mapList [0].Attributes ["tilehight"].Value);

		XmlNodeList images = xmlDoc.GetElementsByTagName ("image");
		XmlNodeList layerList = xmlDoc.GetElementsByTagName("layer");

		int i = 0;
		foreach(XmlNodeList layer in layerList){
			Debug.Log (layerList[i].Attributes["name"].Value);
			string key = layerList [i].Attributes ["name"].Value;
			i++;
		}


	}


}
