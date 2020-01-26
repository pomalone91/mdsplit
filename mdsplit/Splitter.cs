// Run using this in custom config:      /Users/paulmalone/Documents/Journal/test.md
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mdsplit {
    public class Splitter {
        // Splitter is going to have a list to store the results of the split.
        private List<string> articles;
        private FileReader fileReader;

        // Replace ^ with \n so it's easier to parse \n
        
        private string pattern = "(\n# .*)"; // Matches lines with one # at the beginning

        public Splitter(FileReader fileReader) {
            this.fileReader = fileReader;
            string lineStart = "^";
            string replacedContents = Regex.Replace(this.fileReader.contents, lineStart, "\n");

            //Console.WriteLine(fileReader.contents);
            List<string> h1List = new List<string>(Regex.Split(replacedContents, pattern));

            // 1. If first letter is #
            // 2. append i+1 to i
            // Find next #
            for (int i = 0; i < h1List.Count; i++) {
                if (h1List[i] != "") {
                    if (h1List[i].StartsWith("\n#")) {
                        h1List[i] += h1List[i + 1];
                        h1List[i + 1] = "";
                    }
                }
            }

            // Loop through list to remove blank entries
            for (int i = 0; i < h1List.Count; i++) {
                if (h1List[i] == "") {
                    h1List.RemoveAt(i);
                }
            }

            this.articles = h1List;
        }

        // Function that actually splits everything
        public string articleByIndex(int i) {
            return articles[i];
        }

        public List<string> getArticles() {
            return articles;
        }
    }
}
