using System;
using System.Collections.Generic;
using GasTag.Database.Entities;

namespace DocumentDevelopment.ViewModels
{
    public class DocumentData
    {
        public string DocumentKey { get; set; }

        public Properties Property { get; set; }
        public Landlord Landlord { get; set; }
        public Companies Company { get; set; }
        public Contractors Contractor { get; set; }
        public EngineerDetailsModel Engineer { get; set; }
        public IEnumerable<ApplianceModel> Appliances { get; set; } = new List<ApplianceModel>();
        public IEnumerable<Tasks> Tasks { get; set; } = new List<Tasks>();
        public IDictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();

        public int? CompanyId { get; set; }

        public DateTimeOffset JobDate { get; set; }
        public ApplianceModel Appliance { get; set; }
        public List<ApplianceModel> Chimneys { get; set; }
        public List<(int Order, string Defect, string Recommendation)> Defects { get; set; }
            = new List<(int Order, string Defect, string Recommendation)>();
        public string TenantSignatureImage { get; set; }
        public string EngineerSignatureImage { get; set; }
    }
}
