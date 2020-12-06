import java.io.File;

fun count(answers: ArrayList<String>): Int {
    for (i in 1 until answers.size) {
        var firstAnswer = answers[0];
        for (j in 0 until answers[0].length ) { 
            if (!answers[i].contains(answers[0][j])) {
                firstAnswer = firstAnswer.replace(Character.toString(answers[0][j]), "")
            }
        }
        answers[0] = firstAnswer
    }
    return answers[0].length;
}

fun main() {
    var answers = ArrayList<String>() 
    var result = 0;

    File("input.txt").forEachLine { 
        if (!it.isEmpty()) {
            answers.add(it)
        } else {
            result += count(answers)
            answers.clear()
        }
    }
    result += count(answers)
    println(result)
}