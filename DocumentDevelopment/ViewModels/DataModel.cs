using System;
using System.Collections.Generic;
using DocumentDevelopment.Utils.Models;
using GasTag.Database.Entities;

namespace DocumentDevelopment.ViewModels
{
    public class DataModel : BaseTemplateModel
    {
        public PaperworkType DocumentKey { get; set; }
        public DateTimeOffset JobDate { get; set; }
        public string TenantSignatureImage { get; set; }
        public string EngineerSignatureImage { get; set; }
        public Contractors Contractor { get; set; }
        public Companies Company { get; set; }
        public Properties Property { get; set; }
        public EngineerDetailsModel Engineer { get; set; }
        public Landlord Landlord { get; set; }

        public IEnumerable<ApplianceModel> Appliances { get; set; } = new List<ApplianceModel>();
        public ApplianceModel Appliance { get; set; }
        public ApplianceModel Burner { get; set; }
        public ApplianceModel OilTank { get; set; }
        public List<ApplianceModel> Chimneys { get; set; } = new List<ApplianceModel>();

        public IEnumerable<Tasks> Tasks { get; set; } = new List<Tasks>();
        public IDictionary<string, object> Answers { get; set; } = new Dictionary<string, object>();

        public List<(int Order, string Defect, string Recommendation)> Defects { get; set; }
            = new List<(int Order, string Defect, string Recommendation)>();
    }
}
