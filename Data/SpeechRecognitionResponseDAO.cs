using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using netcore_blueview.Models;

namespace netcore_blueview.Data
{
    public class SpeechRecognitionResponseDAO: DbContext
    {
        public SpeechRecognitionResponseDAO(DbContextOptions<SpeechRecognitionResponseDAO> options): base(options) { }

        
    }
}
