using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningRoom.Infrastructure.Entities
{
    public class Story : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Origin { get; set; }
        public TimeSpan Length { get; set; }
        public float Rating { get; set; }
        public DateTime AiringDate { get; set; }
    }
}
