﻿using Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Teams.Data.Entities
{
    public class Team : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        public decimal Revenue { get; set; }

        public ICollection<Player> Players { get; set; }

        public int GetPoints()
        {
            if (!Players.Any())
                return 0;

            return Players
                .OrderBy(p => p.Points)
                .Take(3)
                .Sum(p => p.Points);
        }
    }
}