using System;
using System.Collections.Generic;

namespace DocumentDevelopment.ViewModels
{
    public class ApplianceModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string ApplianceLocation { get; set; }
        public string FlueType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime NextServiceDate { get; set; }
        public DateTime NextSweepDate { get; set; }
        public bool FireAssessmentCarriedOut { get; set; }

        public AppliancePayload Payload { get; set; }
        public IDictionary<string, object> Answers { get; set; } = new Dictionary<string, object>();
    }

    public class AppliancePayload
    {
        public string Size { get; set; }
        public string Location { get; set; }
        public string Output { get; set; }
        public string VentilationType { get; set; }
        public string FuelType { get; set; }
        public string SystemType { get; set; }
        public string ApplianceCondition { get; set; }
        public bool LandlordsAppliance { get; set; }
        public int Capacity { get; set; }
        public string ControlSystemType { get; set; }
        public string HeatSourceType { get; set; }

        public string CollectorMake { get; set; }
        public string CollectorModel { get; set; }
        public string CollectorSerialNumber { get; set; }
        public string CollectorType { get; set; }
        public string NumberOfCollectors { get; set; }

        public string CylinderMake { get; set; }
        public string CylinderModel { get; set; }
        public string CylinderSerialNumber { get; set; }
        public string CylinderType { get; set; }
        public string CylinderSize { get; set; }
        public string DHWCylinderManufacturer { get; set; }

        public string OilBurnerMake { get; set; }
        public string OilBurnerModel { get; set; }
        public string OilBurnerType { get; set; }

        public string PumpStationMake { get; set; }
        public string PumpStationModel { get; set; }
        public string PumpStationSerialNumber { get; set; }
        public string NumberOfPumps { get; set; }

        public string TankMake { get; set; }
        public string TankType { get; set; }

        public string DrainBackTankMake { get; set; }
        public string DrainBackTankModel { get; set; }
        public string DrainBackTankSerialNumber { get; set; }

        public string ExpansionVesselSize { get; set; }
        public string ExVesselPreChargeSetting { get; set; }
    }
}
