import Foundation

let path = "/Users/alexu/Development/AoC2020/7/TestConsole/TestConsole/input.txt"

var bag = "shiny gold bag"
var count = 0
var foundLines = [String]()

func find(contents: String, bag: String) -> Int {
    var count = 0;
    contents.enumerateLines { (line, stop) -> () in
        let split = line.components(separatedBy: " contain ")
        
        if (!foundLines.contains(line)) {
            var bagToFind = bag.replacingOccurrences(of: "bags", with: "")
            bagToFind = bagToFind.replacingOccurrences(of: "bag", with: "")
            if (split[1].contains(bagToFind)) {
                foundLines.append(line)
                count = count + 1
                count = count + find(contents: contents, bag: split[0]);
            }
        }
        
       
    }
    return count;
}

do {
    let contents = try String(contentsOfFile: path, encoding: .utf8)

    count = count + find(contents: contents, bag: bag);
    
    print(count)
}
catch let error as NSError {
    print("Ooops! Something went wrong: \(error)")
}
