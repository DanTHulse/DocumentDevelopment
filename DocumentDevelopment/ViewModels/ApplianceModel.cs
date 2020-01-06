using System;
using System.Collections.Generic;

namespace DocumentDevelopment.ViewModels
{
    public class ApplianceModel
    {
        public string ApplianceId { get; set; }
        public string Location { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ApplianceLocation { get; set; }
        public string FlueType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime NextServiceDate { get; set; }
        public DateTime? NextSweepDate { get; set; }
        public bool FireAssessmentCarriedOut { get; set; }

        public string PayloadString { get; set; }
        //public IDictionary<string, string> Payload
        //{
        //    get => PayloadString.DeserialiseJsonBody<Dictionary<string, string>>();
        //    set { }
        //}
        public IDictionary<string, string> Payload { get; set; } = new Dictionary<string, string>();
        public IDictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();
    }
}
