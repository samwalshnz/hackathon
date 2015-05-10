using System.Collections.Generic;
using Newtonsoft.Json;

namespace hackathon.droid.Models.Cards
{
    public class RuleModel
    {
        [JsonProperty("id")]
        public int RuleId { get; set; }

        [JsonProperty("name")]
        public string RuleName { get; set; }

        [JsonProperty("description")]
        public string CardDescription { get; set; }
    }

    public class CardModel
    {
        [JsonProperty("id")]
        public int CardId { get; set; }

        [JsonProperty("name")]
        public string CardName { get; set; }

        [JsonProperty("letter")]
        public string CardLetter { get; set; }

        [JsonProperty("rank")]
        public int CardRank { get; set; }
    }

    public class RuleMatchModel
    {
        [JsonProperty("id")]
        public int RuleMatchId { get; set; }

        [JsonProperty("rule")]
        public RuleModel Rule { get; set; }

        [JsonProperty("card")]
        public CardModel Card { get; set; }
    }

    public class RuleSetModel
    {
        [JsonProperty("id")]
        public int RuleSetId { get; set; }

        [JsonProperty("rule_matches")]
        public List<RuleMatchModel> RuleMatches { get; set; }
    }

    public class GamePlayModel
    {
        [JsonProperty("id")]
        public int GamePlayId { get; set; }

        [JsonProperty("ruleset")]
        public RuleSetModel RuleSet { get; set; }
    }

    public class GamePlayRoot
    {
        [JsonProperty("gameplay")]
        public GamePlayModel GamePlay { get; set; }
    }


}
