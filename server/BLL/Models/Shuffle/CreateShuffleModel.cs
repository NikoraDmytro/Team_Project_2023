﻿using BLL.Mappings;

namespace BLL.Models.Shuffle
{
    public class CreateShuffleModel: IMapTo<Core.Entities.Shuffle>
    {
        public int LapNum { get; set; }
        public int PairSerialNum { get; set; }

        public int CompetitorInBlueId { get; set; }
        public Core.Entities.Competitor? CompetitorInBlue { get; set; }

        public int? CompetitorInRedId { get; set; }
        public Core.Entities.Competitor? CompetitorInRed { get; set; }
    }
}
