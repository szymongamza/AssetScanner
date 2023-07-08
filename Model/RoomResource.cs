﻿
namespace AssetScanner.Model;
public class RoomResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public BuildingResource Building { get; set; }
}
