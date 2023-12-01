using System;
using System.Collections.Generic;

namespace GameMania.DataAcccessLayer.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Platform { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Summary { get; set; }
        public int? UserReview { get; set; }
    }
}
