using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Xml.Linq;

namespace Court_Application.Models
{
    public class Suit_Document
    {
        public string Plaintiffs_Address { get; set; } = "";

        public string Defendants_Address { get; set; } = "";
        public string First_Plaintiffs_Name { get; set; } = "";

        public string FirstDefendants_Name {get; set;} = "";

        public string Court_Name { get; set; } = "";
        public string verification { get; set; } = "";

        public string DateFilling { get; set; } = "";
        public string Counsel_Name_Address { get; set; } = "";
        public string Counsel_Name { get; set; } = "";
        public string SelectedCategory { get; set; } = "";
        public string Place { get; set; } = "";
        public string Year { get; set; } = "";
    }
}
