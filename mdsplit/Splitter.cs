// Run using this in custom config:      /Users/paulmalone/Documents/Journal/test.md
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mdsplit {
    public class Splitter {
        // Splitter is going to have a list to store the results of the split.
        private string[] articles;
        private FileReader fileReader;

        // Replace ^ with \n so it's easier to parse \n
        
        private string pattern = "(\n# .*)"; // Matches lines with one # at the beginning

        public Splitter(FileReader fileReader) {
            this.fileReader = fileReader;
            string lineStart = "^";
            string replacedContents = Regex.Replace(this.fileReader.contents, lineStart, "\n");
            
            //Console.WriteLine(fileReader.contents);
            this.articles = Regex.Split(replacedContents, pattern);
        }

        // Function that actually splits everything
        public string articleByIndex(int i) {
            return articles[i];
        }

        public string[] getArticles() {
            return articles;
        }
    }
}
