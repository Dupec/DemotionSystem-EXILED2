using Exiled.API.Interfaces;
using System.ComponentModel;

namespace VotingSystem
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("This broadcasts when someone gets demoted/promoted")]
        public bool promotion_enabled { get; set; } = true;
        public bool demotion_enabled { get; set; } = true;
        public ushort MessagesDuration { get; set; } = 7;
        public string DemotionNTFLieutenant { get; set; } = "<i>You have been Demoted to NTF-Lieutenant.</i>";
        public string PromotionNTFLieutenant { get; set; } = "<i>You have been Promoted to NTF-Lieutenant.</i>";
        public string DemotionNTFCadet { get; set; } = "<i>You have been Demoted to NTF-Cadet.</i>";
        public string PromotionNTFCadet { get; set; } = "<i>You have been Promoted to NTF-Cadet.</i>";
        public string DemotionNTFFG { get; set; } = "<i>You have been Demoted to Facility Guard.</i>";
        [Description("Max Range of the Increase/Decrease Reputation Points [Example: 1 (MinRange) => 37 (MaxRange)]")]
        public int maxRange { get; set; } = 37;
        public int minRange { get; set; } = 1;
        public int MaxReputation { get; set; } = 400;
        public int MinReputation { get; set; } = 0;

    }
}
