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
            string[] splitH1s = Regex.Split(replacedContents, pattern);

            // TODO - append H1s back onto their bodies
            // 1. If first letter is #
            // 2. append i+1 to i
            // Find next #
            for (int i = 0; i < splitH1s.Length; i++) {
                if (splitH1s[i] != "") {
                    if (splitH1s[i].StartsWith("\n#")) {
                        splitH1s[i] += splitH1s[i + 1];
                        splitH1s[i + 1] = "";
                    }
                }
            }

            this.articles = splitH1s;
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
