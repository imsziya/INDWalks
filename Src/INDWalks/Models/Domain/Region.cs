﻿using System.Collections;

namespace INDWalks.Models.Domain;

public class Region
{
    public int Id { get; set; }
    public string Code { get; set; }  = string.Empty;
    public string Name { get; set; }  = string.Empty;
    public double Area { get; set; } 
    public double Lat { get; set; }
    public double Long { get; set; }
    public long Population { get; set; }
    public IEnumerable<Walk> Walks { get; set; } = [];
}
