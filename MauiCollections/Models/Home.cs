using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCollections.Models;

public class Home
{
    public string Name { get; set; }
    public string[] Photos =>new string[] { "home.jpg",  "kitchen.jpg" ,"livingroom.jpg", "bedroom.jpg", "bathroom.jpg" };
}