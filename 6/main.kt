import java.io.File;

fun main() {
    var answers = ArrayList<Char>() 
    var result = 0;

    File("input.txt").forEachLine { 

        if (!it.isEmpty()) {
            for (i in 0 until it.length) {
                if (!answers.contains(it[i])) {
                    answers.add(it[i])
                }
            }
        } else {
            result += answers.size
            answers.clear()
        }
    }

    result += answers.size
    println(result)
}