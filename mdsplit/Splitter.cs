// Run using this in custom config:      /Users/paulmalone/Documents/Journal/test.md
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mdsplit {
    public class Splitter {
        // Splitter is going to have a list to store the results of the split.
        private List<File> fileList;
        private File file;

        // Replace ^ with \n so it's easier to parse \n
        
        private string pattern = "(\n# .*)"; // Matches lines with one # at the beginning

        public Splitter(File file) {
            this.file = file;
            string lineStart = "^";
            string replacedContents = Regex.Replace(this.file.contents, lineStart, "\n");

            //Console.WriteLine(fileReader.contents);
            List<string> h1List = new List<string>(Regex.Split(replacedContents, pattern));
            this.fileList = new List<File>();

            // 1. If first letter is #
            // 2. append i+1 to i
            // Find next #
            for (int i = 0; i < h1List.Count; i++) {
                if (h1List[i] != "") {
                    if (h1List[i].StartsWith("\n#")) {
                        fileList.Add(new File(h1List[i].Substring(3), h1List[i+1]));
                        h1List[i] += h1List[i + 1];
                        h1List[i + 1] = "";
                    }
                }
            }
        }

        // Function that actually splits everything
        public File articleByIndex(int i) {
            return fileList[i];
        }

        public List<File> getArticles() {
            return fileList;
        }
    }
}
