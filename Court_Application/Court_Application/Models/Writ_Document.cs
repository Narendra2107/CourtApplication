using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Court_Application.Models
{
    public class Writ_Document
    {
        public string Petitioner_Address { get; set; } = "";
        public string Respondents_Address { get; set; } = "";
        public string Main_Prayer { get; set; } = ""; 
        public string Interfm_Prayer { get; set; } = "";
        public string First_petioner_Name { get; set; } = "";
        public string First_Respondents_Name { get; set; } = "";
        public string District_Name { get; set; } = "";
        public string Date_of_Filling { get; set; } = "";
        public string verification { get; set; } = "";
        public string Lower_Court_Name { get; set; } = "";
        public string Lower_Court_Case_Number { get; set; } = "";
        public string Lower_Court_Order_Date { get; set; } = "";
        public string counsel_Address{ get; set; } = "";
        public string counsel_Name { get; set; } = "";

        
        public string SelectedCategory { get; set; } = "";

        // This will be used to populate the dropdown list
        



        public string year { get; set; } = "";
        


    }

}
