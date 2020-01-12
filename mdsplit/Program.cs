using System;

namespace mdsplit {
    class MainClass {
        public static void Main(string[] args) {
            // Make a new file reader and read in the file
            if (args.Length > 0) {
                FileReader fr = new FileReader(args[0]);
                Splitter sp = new Splitter(fr);
                Console.WriteLine(sp.articleByIndex(0));
            } else {
                Console.WriteLine("Could not read file");
            }
        }
    }
}
