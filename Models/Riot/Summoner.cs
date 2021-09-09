using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace LoLPA.Database.Models.Riot
{
    [Index(nameof(Name), IsUnique = false)]
    public class Summoner
    {
        [Key]
        public string Puuid { get; set; }

        public string Region { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public DateTime RevisionDate { get; set; }
        public long Level { get; set; }
        public ProfileIcon ProfileIcon { get; }

        public static Summoner FromApi(RiotSharp.Endpoints.SummonerEndpoint.Summoner apiSummoner, Summoner existingSummoner = null)
        {
            var returnSummoner = existingSummoner ?? new Summoner();

            returnSummoner.Region = apiSummoner.Region.ToString();
            returnSummoner.AccountId = apiSummoner.AccountId;
            returnSummoner.Name = apiSummoner.Name;
            returnSummoner.Puuid = apiSummoner.Puuid;
            returnSummoner.RevisionDate = apiSummoner.RevisionDate;
            returnSummoner.Level = apiSummoner.Level;

            return returnSummoner;
        }
    }
}