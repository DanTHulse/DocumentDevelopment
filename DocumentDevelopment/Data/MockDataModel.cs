using System;
using System.Collections.Generic;
using DocumentDevelopment.ViewModels;
using GasTag.Database.Entities;

namespace DocumentDevelopment.Data
{
    public class MockDataModel
    {
        public static DataModel Build
        {
            get
            {
                return new DataModel
                {
                    JobDate = DateTime.Now,
                    Contractor = new Contractors
                    {
                        BusinessRegId = "12343",
                        Name = "Test Contractor",
                        Address = BuildAddress,
                        TelephoneNum = "01512219889"
                    },
                    Company = new Companies
                    {
                        CompanyName = "Test Contractor",
                        Address = BuildAddress
                    },
                    Engineer = new EngineerDetailsModel
                    {
                        FirstName = "Test",
                        LastName = "Engineer",
                        TelephoneNum = "015122187785",
                        EngineerSignature = "636619011151517000.png",
                        GasSafeId = 12343823
                    },
                    Property = new Properties
                    {
                        Id = 12343,
                        NextServiceDate = DateTime.Now,
                        TenantName = "Test Tenant",
                        TenantNumber = "012214554845",
                        TenantEmail = "test@test.com",
                        Address = BuildAddress,
                        Uprn = "Test UPRN"
                    },
                    Landlord = new Landlord
                    {
                        Address = BuildAddress,
                        Name = "Jane Lords"
                    },
                    Appliance = new ApplianceModel
                    {
                        Make = "Test Make",
                        Model = "Test Model",
                        NextServiceDate = DateTime.Now,
                        SerialNumber = "DN:1234382",
                        FlueType = "CF - Conventional Flue",
                        Payload = BuildAppliancePayload,
                        FireAssessmentCarriedOut = true,
                    },
                    Answers = BuildAnswers,
                    Chimneys = new List<ApplianceModel>
                    {
                        BuildChimney,
                        BuildChimney,
                        BuildChimney,
                        BuildChimney
                    },
                    TenantSignatureImage = _sigImage1,
                    EngineerSignatureImage = _sigImage2,
                    Defects = new List<(int Order, string Defect, string Recommendation)>
                    {
                        (1, "Appliance Defect 1", "this is the recommendation for Appliance Defect 1"),
                        (2, "Appliance Defect 2", "this is the recommendation for Appliance Defect 2"),
                        (3, "Appliance Defect 3", "this is the recommendation for Appliance Defect 3"),
                        (4, "Appliance Defect 4", "this is the recommendation for Appliance Defect 4"),
                        (5, "Appliance Defect 5", "this is the recommendation for Appliance Defect 5")
                    }
                };
            }
        }

        private static Address BuildAddress
        {
            get
            {
                return new Address
                {
                    AddressOne = "6th Floor",
                    AddressTwo = "4 St. Pauls Square",
                    City = "Liverpool",
                    County = "Merseyside",
                    Postcode = "L39AG"
                };
            }
        }

        private static AppliancePayload BuildAppliancePayload
        {
            get
            {
                return new AppliancePayload
                {
                    Size = "234",
                    Location = "Kitchen",
                    Output = "234",
                    VentilationType = "Type 1",
                    FuelType = "Oil",
                    SystemType = "TS-T",
                    ApplianceCondition = "Very Good",
                    LandlordsAppliance = true,
                    Capacity = 1000,
                    ControlSystemType = "Test",
                    HeatSourceType = "Oil",
                    CollectorMake = "Test Collector",
                    CollectorModel = "Collector Model",
                    CollectorSerialNumber = "CS-123432",
                    CollectorType = "Internal",
                    NumberOfCollectors = "2",
                    CylinderMake = "Test Cylinder",
                    CylinderModel = "Cylinder Model",
                    CylinderSerialNumber = "Cy-12ds",
                    CylinderType = "Fluted",
                    CylinderSize = "200l",
                    DHWCylinderManufacturer = "Clyde",
                    OilBurnerMake = "Test Oil Burner",
                    OilBurnerModel = "Oil Burner Model",
                    OilBurnerType = "Open",
                    PumpStationMake = "Test Pump Station",
                    PumpStationModel = "Pump Station Model",
                    PumpStationSerialNumber = "PS-2RT2",
                    NumberOfPumps = "4",
                    TankMake = "Test Tank",
                    TankType = "Open",
                    DrainBackTankMake = "Test Drain Back",
                    DrainBackTankModel = "Drain Back Model",
                    DrainBackTankSerialNumber = "DBT-3f",
                    ExpansionVesselSize = "2000l",
                    ExVesselPreChargeSetting = "243",
                };
            }
        }

        private static ApplianceModel BuildChimney
        {
            get
            {
                return new ApplianceModel
                {
                    Make = "Test Make",
                    Model = "Test Model",
                    Answers = new Dictionary<string, object>
                    {
                        // ChimneySweeping
                        { "E_FlueResult", "Pass" },
                        { "E_StackResult", "Pass" },
                        { "E_PotResult", "Pass" },
                        { "E_CowlResult", "Pass" },
                        { "E_DepositRemoved", "Soot" },
                        { "E_DepositDetail", "Soot in Flue" },
                        { "E_FireRiskResult", "Yes" },
                        { "E_SmokeTestTypeTwoResult", "Pass" },
                        { "E_VentilationResult", "Yes" },
                        { "E_CCTVInspectionResult", "Pass" },
                        { "E_PressureTest", "Tested" },
                        { "E_SweepMethod", "Montgandy" },
                        { "E_MaintenanceDemonstratedResult", "Yes" },
                    }
                };
            }
        }

        private static Dictionary<string, object> BuildAnswers
        {
            get
            {
                return new Dictionary<string, object>
                {
                    #region ASHP
                    { "E_ExpansionVesselChargeCheckedResult", "Yes" },
                    { "E_MagneticFilterCleanedResult", "Yes" },
                    { "E_GlycolConcentration", "20" },
                    { "E_GlycolConcetrationMeetsSpecsResult", "Yes" },
                    { "E_VisualInspectionOfPipeworkResult", "Yes" },
                    { "E_CompressorRunningCurrent", "1234" },
                    { "E_OperationChecksResult", "Yes" },
                    { "E_MotorisedValvesCheckedResult", "Yes" },
                    { "E_HeatExchangerInspectedResult", "Yes" },
                    { "E_YStrainerInspectedResult", "Yes" },
                    { "E_ElectricalConnectionsCheckedResult", "Yes" },
                    { "E_IntegrityOfWaterPiperworkResult", "Yes" },
                    { "E_OperationVoltageCheckedResult", "Yes" },
                    { "E_InspectedForSignsOfLeaksResult", "Yes" },
                    { "E_FuseRating", "12" },
                    #endregion

                    #region SolidFuelServicing
                    { "E_SuitableHearthResult", "Yes" },
                    { "E_VentilationSufficientResult", "Yes" },
                    { "E_ChimneyConditionSoundResult", "Yes" },
                    { "E_COAlarmFittedResult", "Yes" },
                    { "E_TerminationHeightResult", "Yes" },
                    { "E_InformationAvailableResult", "Yes" },
                    { "E_ChimneySweptResult", "Yes" },
                    { "E_ClearOfCombustiblesResult", "Yes" },
                    { "E_AllSealsAirtightResult", "Yes" },
                    { "E_ControlsWorkingResult", "Yes" },
                    { "E_CustomerAwareResult", "Yes" },
                    { "E_BurningSuitableResult", "Yes" },
                    { "E_SmokeDrawTestResult", "Pass" },
                    { "E_SmokeDrawTestNotes", "smoke draw tested" },
                    { "E_FlueDraughtExtractionTestResult", "Pass" },
                    { "E_FlueDraughtExtractionTestNotes", "flue draught tested" },
                    { "E_SpillageTestResult", "Pass" },
                    { "E_SpillageTestNotes", "spillage tested" },
                    { "E_GeneralChecksUndertakenResult", "Yes" },
                    { "E_BoilerConnectionsResult", "Yes" },
                    { "E_StorageTypeResult", "Yes" },
                    { "E_StorageLocationResult", "Yes" },
                    { "E_FETankTypeResult", "Yes" },
                    { "E_SystemControlsResult", "Yes" },
                    { "E_SystemCheckedResult", "Yes" },
                    { "E_ServicePassedResult", "Yes" },
                    { "E_WetSystemChecksResult", "Yes" },
                    #endregion

                    #region CD12
                    
                    { "E_OilSupplyResult", "Pass" },
                    { "E_OilSupplyComments", "Oil supply comments" },
                    { "E_SuitableAirSupplyResult", "Pass" },
                    { "E_AirSupplyComments", "Air supply Pass" },
                    { "E_ChimneyFlueInstalledResult", "Pass" },
                    { "E_ChimneyFlueComments", "Chimney comments" },
                    { "E_BurnerInstalledResult", "Pass" },
                    { "E_BurnerComments", "Burner Comments" },
                    { "E_SafetyControlsInstalledResult", "Pass" },
                    { "E_SafetyControlsComments", "Pass comments" },
                    { "E_WarningLabelAffixedResult", "Yes" },
                    { "E_UrgentFaultsResult", "Yes" },
                    { "E_ShouldEquipmentBeUsedResult", "Yes" },
                    { "E_SpillageFireAssessmentFormCompleted", "Yes" },
                    #endregion

                    #region CD11
                    { "E_CallType", "Service" },
                    { "E_OilSupplyDefectsResult", "Yes" },
                    { "E_AdequateVentilationResult", "Yes" },
                    { "E_FlueInstalledToInstructionResult", "Yes" },
                    { "E_ApplianceFuseRating", "23" },
                    { "E_FuseRatingWithinManufacturerRangeResult", "Yes" },
                    { "E_CheckedApplianceSafetyControlsResult", "Yes" },
                    { "E_CombustionChamberCleanedToInstructionResult", "Yes" },
                    { "E_AreAppliancesElectricallySafeResult", "Yes" },
                    { "E_HeatExchangerCleanedToInstructionResult", "Yes" },
                    { "E_PressureJetCleanedToInstructionResult", "Yes" },
                    { "E_VaporisingWallflameChecksResult", "Yes" },
                    { "E_WallflameFurtherChecksResult", "Yes" },
                    { "E_CheckedControlsResult", "Yes" },
                    { "E_HotWaterChecksPerformedResult", "Yes" },
                    { "E_WarmAirChecksPerformedResult", "Yes" },
                    { "E_NozzleSize", "200" },
                    { "E_NozzleAngle", "20" },
                    { "E_NozzlePattern", "Flat" },
                    { "E_FlowRateOilLow", "360" },
                    { "E_FlowRateOilHigh", "380" },
                    { "E_FlowRateDHWCold", "520" },
                    { "E_FlowRateDHWHot", "550" },
                    { "E_COCO2Ratio", "1:2500" },
                    { "E_ExcessAir", "15" },
                    #endregion

                    #region CD10T
                    { "E_RemoteFillSystemTestedResult", "Yes" },
                    { "E_OverfillAlarmFittedResult", "Yes" },
                    { "E_OilSupplyLineOD", "550" },
                    { "E_OilSupplyType", "Metal" },
                    { "E_PressureTestedResult", "Yes" },
                    { "E_RemoteSensingFireValveFittedResult", "Yes" },
                    { "E_OilPipeMeetsStandardsResult", "Yes" },
                    #endregion

                    #region TI133D
                    { "E_TankLocatedInJerseyGuernseyResult", "Yes" },
                    { "E_TankLocationInWalesResult", "Yes" },
                    { "E_TankCapacityOver2500Result", "Yes" },
                    { "E_TankCloseToControlledWaterResult", "Yes" },
                    { "E_TankLocatedNearDrainResult", "Yes" },
                    { "E_TankCloseToBoreholeResult", "Yes" },
                    { "E_TankOverHardGroundResult", "Yes" },
                    { "E_VentPipeNotVisibleFromFillPointResult", "Yes" },
                    { "E_TankSupplyNonSingleFamilyDwellingResult", "Yes" },
                    { "E_OtherPotentialFireHazardResult", "Yes" },
                    { "E_TankLocatedInFloodHighWindRiskResult", "Yes" },
                    { "E_TankRestraintProvdedResult", "Yes" },
                    { "E_TankCloseToNonFireWallResult", "Yes" },
                    { "E_TankCloseToNonFireBoundaryResult", "Yes" },
                    { "E_TankCloseToNonFireEavesResult", "Yes" },
                    { "E_TankCloseToConstructionOpeningResult", "Yes" },
                    { "E_TankCloseToFlueTerminationResult", "Yes" },
                    { "E_HasBase300mmAroundTankResult", "Yes" },
                    { "E_FireProtectionProvidedResult", "Yes" },
                    #endregion

                    #region Solar
                    { "E_InitialSystemPressure", "1234" },
                    { "E_InitialSystemPressureCorrectResult", "Yes" },
                    { "E_CollectorsVisualConditionResult", "Yes" },
                    { "E_SolarFluidFrostProtectionResult", "Yes" },
                    { "E_SolarFluidRefractometerReading", "12345" },
                    { "E_PressureReliefValveRatedResult", "Yes" },
                    { "E_PressureReliefValveOperationalResult", "Yes" },
                    { "E_SuitablySizedDischargeContainerResult", "Yes" },
                    { "E_CheckedDischargeContainerFluidResult", "Yes" },
                    { "E_AutoAirVentsServiceableResult", "Yes" },
                    { "E_SuitableFillingPointResult", "Yes" },
                    { "E_SuitableDrainPointFittedResult", "Yes" },
                    { "E_IsolationValvesFittedCorrectlyResult", "Yes" },
                    { "E_PressureGaugeFittedResult", "Yes" },
                    { "E_SolarPipeworkSoundSupportedResult", "Yes" },
                    { "E_SolarPipeworkProtectedResult", "Yes" },
                    { "E_ComponentsSteamSolarRatedResult", "Yes" },
                    { "E_CollectorSensorsSecureResult", "Yes" },
                    { "E_VesselSensorsSecureResult", "Yes" },
                    { "E_ChargePressureExVessel", "123" },
                    { "E_ToppedUpSolarFluidResult", "Yes" },
                    { "E_SystemPressure", "123" },
                    { "E_SolarPumpCorrectSpeedResult", "Yes" },
                    { "E_SolarFlowRate", "123" },
                    { "E_NTCOperatingCorrectlyResult", "Yes" },
                    { "E_ControlsWithinManufacturerSpecResult", "Yes" },
                    { "E_CollectorsCorrectlySizedResult", "Yes" },
                    { "E_DHWBlendingValveInstalledResult", "Yes" },
                    { "E_DHWOutletTemp", "12" },
                    { "E_DHWOutletTempAcceptableResult", "Yes" },
                    { "E_SecondaryHeatSourceInterlockedResult", "Yes" },
                    { "E_ConnectionsSoundAndProtectedResult", "Yes" },
                    { "E_SolarConditionResult", "Yes" },
                    { "E_SolarSafeToUseResult", "Yes" },
                    { "E_IsolatedPumpStationResult", "Yes" },
                    #endregion

                    #region Unvented
                    { "E_SolarRenewablesCompatibleResult", "Yes" },
                    { "E_PrimaryHeatsource", "Sealed" },
                    { "E_HeatsourceTypeResult", "Direct" },
                    { "E_GasBoilerResult", "Yes" },
                    { "E_OilBoilerResult", "Yes" },
                    { "E_SolarResult", "Yes" },
                    { "E_ImmersionHeaterResult", "Yes" },
                    { "E_MaximumFlowTemp", "12" },
                    { "E_InletWaterPressure", "123" },
                    { "E_PressureValveSetting", "123" },
                    { "E_ServiceValveWorkingResult", "Yes" },
                    { "E_ProvisionForExpansionResult", "Yes" },
                    { "E_ExpansionType", "Open Vented" },
                    { "E_ExpansionVesselSize", "123" },
                    { "E_VesselSuitableForPotableWaterResult", "Yes" },
                    { "E_ExpansionCorrectChargeResult", "Yes" },
                    { "E_ExpansionRechargedResult", "Yes" },
                    { "E_ReliefValveServiceabilityResult", "Yes" },
                    { "E_TemperatureReliefValvePressentResult", "Yes" },
                    { "E_TemperatureReliefValveOperationResult", "Yes" },
                    { "E_DischargePipesResult", "Yes" },
                    { "E_WaterInletFilterCleanedResult", "Yes" },
                    { "E_OverheatInterlockResult", "Yes" },
                    { "E_ControlsWorkingResult", "Yes" },
                    { "E_FittedWithCutOutDeviceResult", "Yes" },
                    { "E_DirectlyFiredThermostatResult", "Yes" },
                    { "E_IndirectlyFiredThermostatResult", "Yes" },
                    { "E_ColdWaterTeeFittedResult", "Yes" },
                    { "E_D1D2MaterialSuitableResult", "Yes" },
                    { "E_D1FittedToStandardsResult", "Yes" },
                    { "E_TundishFittedCorrectlyResult", "Yes" },
                    { "E_D2FittedToStandardsResult", "Yes" },
                    { "E_D2PipeworkCorrectlyTerminatedResult", "Yes" },
                    { "E_ElectricalConnectionsSoundResult", "Yes" },
                    { "E_MaxDHWFlowRate", "123" },
                    { "E_HotWaterThermostatTemp", "55" },
                    { "E_DHWMixingValveFittedResult", "Yes" },
                    { "E_DHWMixingValveTemp", "55" },
                    { "E_HotWaterTempAtOutlet", "55" },
                    { "E_StoreTempAchievable", "75" },
                    { "E_MaxHotWaterTemp", "75" },
                    { "E_HotAndColdSuppliesBalancedResult", "Yes" },
                    { "E_PipeworkSupportedResult", "Yes" },
                    { "E_PipeworkLaggedResult", "Yes" },
                    { "E_CylinderSupportedResult", "Yes" },
                    { "E_InstallersDetailsDisplayedResult", "Yes" },
                    { "E_NumberOfImmersionHeatersResult", "1" },
                    { "E_ImmersionHeatersOperableResult", "Yes" },
                    { "E_ReasonImmersionHeatersInoperableResult", "Reasons" },
                    { "E_OverheatThermostatOperationalResult", "Yes" },
                    { "E_RefilledVentedAndCheckedLeaksResult", "Yes" },
                    { "E_ApplianceSafeToUseResult", "Yes" },
                    { "E_CheckMotorisedValveResult", "Yes" },
                    #endregion

                    #region General
                    { "E_PrintName", "John Doe" },
                    { "E_AdditionalNotes", "Called gas" },
                    { "E_ApplianceCondition", "Very Good" },
                    { "E_WarningNoticeRequiredResult", "Yes" },
                    { "E_SmokeNumber", "2" },
                    { "E_Draught", "65" },
                    { "E_DraughtItem", "inWG" },
                    { "E_CO", "0.001" },
                    { "E_CO2", "25.1" },
                    { "E_FlueGasTemp", "45" },
                    { "E_PumpPressure", "100" },
                    { "E_PumpPressureItem", "psi" },
                    { "E_PumpVacuum", "202" },
                    { "E_PumpVacuumItem", "psi" },
                    { "E_EfficiencyNett", "89" },
                    { "E_EfficiencyGross", "85" },
                    { "E_SafeToUseResult", "Yes" },
                    { "E_LandlordsApplianceResult", "Yes" },
                    #endregion
                };
            }
        }

        private const string _sigImage1 = "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";
        private const string _sigImage2 = "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";
    }
}
