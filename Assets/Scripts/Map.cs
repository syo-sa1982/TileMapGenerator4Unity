using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("map")]
public class Map
{
	#region class

	public class TileSet
	{
		[XmlAttribute]
		public string name;

		[XmlAttribute]
		public int firstgid,tilewidth,tileheight;

		public Image imgae;
	}

	public class Layer
	{
		[XmlAttribute]
		public string name;
		[XmlAttribute]
		public int width, height;

		public Data data;
	}

	public class Image
	{
		[XmlAttribute]
		public string source;
		[XmlAttribute]
		public int width, height;
	}

	public class Data
	{
		[XmlAttribute]
		public string encoding;
		[XmlElement()]
		public List<Tile> tile;
	}

	public class Tile
	{
		[XmlAttribute]
		public int gid;
	}

	#endregion

	#region public property

	[XmlAttribute]
	public string version,orientation;

	[XmlAttribute]
	public int width,height,tilewidth,tileheight;

	[XmlElement()]
	public List<TileSet> tileset;

	[XmlElement()]
	public List<Layer> layer; 

	#endregion

	#region public method
	public int[,] GetLayerData(string name){

		var oneLayer = GetLayer(name);

		if(oneLayer == null){
			return null;
		}
		var w = oneLayer.width;
		var h = oneLayer.height;
		var tiles = oneLayer.data.tile; 
		var grid = new int[w, h];

		for(int y=0; y<h; ++y){
			for(int x=0; x<w; ++x){
				var tileNo = x + (y * w);
				grid[x, y] = tiles[tileNo].gid;
			}
		}
		return grid;
	}
	#endregion


	#region private method

	private Layer GetLayer(string name){

		Debug.Log (name);
		Debug.Log (layer);

		foreach(var l in layer){

			if(l.name == name){
				return l;
			}

		}

		return null;

	}




	#endregion


}
