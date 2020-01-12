using System;
using System.Collections.Generic;

namespace mdsplit {
    public class Splitter {
        // Splitter is going to have a list to store the results of the split.
        private string[] articles;
        private FileReader fileReader;

        public Splitter(FileReader fileReader) {
            this.fileReader = fileReader;
            this.articles = this.fileReader.contents.Split('#');
        }

        // Function that actually splits everything
        public string articleByIndex(int i) {
            return articles[i];
        }
    }
}
