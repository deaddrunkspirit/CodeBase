fun main() {
    println("++++++++++++++++++++++++\nTask1\n-----------------------")
    medianAndAverage("2.0 10.0 22.0")
    println("++++++++++++++++++++++++\nTask2\n-----------------------")
    deleteCopies(mutableListOf("Itachi", "Naruto", "Sasuke",
        "Naruto", "Kakashi", "Kakashi", "Naruto")).forEach { print("$it ") }
    println()
    println("++++++++++++++++++++++++\nTask3\n-----------------------")
    println(getPattern())
    println("++++++++++++++++++++++++\nTask4\n-----------------------")
    val names = listOf("Smith", "Jones", "Bambury", "Patel",
        "Brown", "Singh", "Williams", "Taylor",
        "Wilson", "Davies", "Evans", "Scott")
    val sortedNames = sortLists(names)
    for (row in sortedNames) {
        row.forEach { print("$it ") }
        println()
    }
    println("++++++++++++++++++++++++\nTask5\n-----------------------")
    findSubstrings("абракадабракадабра", "абракадабра").forEach { print("$it ") }
    println()
    findSubstrings("123456712345", "12").forEach { print("$it ") }
    println()
    findSubstrings("ккк", "к").forEach { print("$it ") }
    println()
    findSubstrings("кукук", "ку").forEach { print("$it ") }
    println()
    println("++++++++++++++++++++++++\nTask6\n-----------------------")
    println(isAnagram("friend", "firend"))
    println(isAnagram("Rail safety", "Fairy tales"))
    println("++++++++++++++++++++++++")
}

// *  Task 1
fun medianAndAverage(input: String?) {
    val numbers: List<Double> = input?.split(" ")?.map { it.toDouble() }!!
    val average = numbers.average()
    val sortNumbers = numbers.sorted()
    val median = if (sortNumbers.size % 2 == 0) {
        (sortNumbers[sortNumbers.size / 2 - 1] + sortNumbers[sortNumbers.size / 2]) / 2
    } else {
        sortNumbers[sortNumbers.size / 2]
    }
    println("$average $median")
}

// *  Task 2
fun deleteCopies(inputList: List<String>): List<String> {
    val knownNames = mutableListOf<String>()
    for (name in inputList) {
        if (!knownNames.contains(name)) {
            knownNames.add(name)
        }
    }
    return knownNames
}

//  * Task 3
const val month = "(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)"

fun getPattern(): String = """[0-3][0-9] $month \d\d\d\d"""

//  * Task 4
fun sortLists(inputList: List<String>): List<List<String>> {
    return inputList
        .groupBy { it.first() }.toList()
        .sortedBy { it.first }
        .map { it.second.sorted() }
}

//  * Task 5
fun findSubstrings(text: String, substring: String): List<Int> {
    var changedText = text
    var index: Int
    var count = 0
    val result = mutableListOf<Int>()
    while (changedText.contains(substring)) {
        index = changedText.indexOf(substring)
        if (index != -1) {
            result.add(index + count * substring.length)
            count++
        }
        changedText = changedText.replaceFirst(substring, "")
    }
    return result
}

//  * Task 6
fun isAnagram(s1: String, s2: String): Boolean {
    val re = Regex("[^a-zа-я]")
    val s1Arr = re.replace(s1.toLowerCase(), "")
        .toCharArray()
        .sorted()
    val s2Arr = re.replace(s2.toLowerCase(), "")
        .toCharArray()
        .sorted()
    return s1Arr == s2Arr
}
