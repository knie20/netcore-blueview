using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace netcore_blueview.Models
{
    public class DAO: DbContext
    {
        public DbSet<SpeechRecognition> SpeechRecognitions { get; set; }
        public DbSet<SpeechRecognitionAlternative> SpeechRecognitionAlternatives { get; set; }
        public DbSet<WordInfo> WordInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=blueview.database.windows.net;Database=blueviewDB;Trusted_Connection=False;User ID=blue;Password=hackOHIO2018");
        }
    }
}
