using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCollections.Models;

public class Home
{
    public string Description { get; set; }
    public string Location { get; set; }
    public int YearBuilt { get; set; }

    public string[] Photos => new string[]
        { "home01.jpg", "kitchen.jpg", "livingroom.jpg", "bedroom.jpg", "bathroom.jpg" };

    public string CarouselPhoto{ get; set; } 
}

