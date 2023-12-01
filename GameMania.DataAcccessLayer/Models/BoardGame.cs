using System;
using System.Collections.Generic;

namespace GameMania.DataAcccessLayer.Models
{
    public partial class BoardGame
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? YearPublished { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public int? PlayTime { get; set; }
        public int? MinAge { get; set; }
        public int? UsersRated { get; set; }
        public string? RatingAverage { get; set; }
        public int? BggRank { get; set; }
        public string? ComplexityAverage { get; set; }
        public int? OwnedUsers { get; set; }
        public string? Mechanics { get; set; }
        public string? Domains { get; set; }
    }
}
