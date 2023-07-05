fun main() {
    println("++++++++++++++++++++++++\nTask1\n-----------------------")
    minutesToHourAndDays()
    println("++++++++++++++++++++++++\nTask2\n-----------------------")
    knotsToKmh()
    println("++++++++++++++++++++++++\nTask3\n-----------------------")
    stringToIntList()
    println("++++++++++++++++++++++++\nTask8\n-----------------------")
    autoNumbers("A003AA97")
    print("---------\n")
    autoNumbers("Свидетели ДТП утверждают, что с иномарки сняли номерные знаки A003AA97.A003AA98 A003AA99 AA003AA98 и повесили вместо них знак H005BB178. При этом прибывшие на место сотрудники ГИБДД, как уверяют очевидцы, оформили аварию именно на второй номер.")
}
//  * Task1
fun minutesToHourAndDays() {
    var minutes: Int = readLine()!!.toInt()
    val days: Int
    var hours: Int
    hours = minutes / 60
    minutes %= 60
    if (minutes >= 30) hours++
    days = hours / 24
    hours %= 24
    println("days: $days\nhours: $hours")
}

//  * Task2
fun knotsToKmh() {
    val knots = readLine()!!.toDouble()
    val kmh: Double = knots * 1852 / 1000
    println("$kmh")
}

//  * Task3
fun stringToIntList() {
    var number = readLine()!!.toInt()
    val digits = mutableListOf<Int>()
    while (number != 0) {
        val digit = number % 10
        number /= 10
        digits.add(digit)
    }
    digits.reverse()
    digits.forEach { print("$it ") }
    println()
}


//  * Task7
fun calculator(list: List<String>): Int {
    val index: Int
    val res: Int
    val firstPart: List<String>
    val secondPart: List<String>
    if (list.contains("+") || list.contains("-") || list.contains("/") || list.contains("*")) {
        when {
            list.contains("*") -> {
                index = list.indexOf("*")
                firstPart = list.slice(0 until index);
                secondPart =  list.slice(index + 1 until list.size);
                res = list[index - 1].toInt() * list[index + 1].toInt()
            }
            list.contains("/") -> {
                index = list.indexOf("/")
                firstPart = list.slice(0 until index);
                secondPart =  list.slice(index + 1 until list.size);
                res = list[index - 1].toInt() / list[index + 1].toInt()
            }
            list.contains("+") -> {
                index = list.indexOf("+")
                firstPart = list.slice(0 until index);
                secondPart =  list.slice(index + 1 until list.size);
                res = list[index - 1].toInt() + list[index + 1].toInt()
            }
            else -> {
                index = list.indexOf("-")
                firstPart = list.slice(0 until index);
                secondPart =  list.slice(index + 1 until list.size);
                res = list[index - 1].toInt() - list[index + 1].toInt()
            }
        }
        return when {
            firstPart == null && secondPart != null
            -> calculator(listOf(res.toString()) + secondPart)
            firstPart != null && secondPart == null
            -> calculator(firstPart + listOf(res.toString()))
            firstPart == null && secondPart == null
            -> calculator(listOf(res.toString()))
            else -> calculator(firstPart + res.toString() + secondPart)
        }
    }
    return list[0].toInt();
}

//  * Task8
fun autoNumbers(text: String) {
    var textNew = text
    val l = "(A|B|E|K|M|H|O|P|C|T|Y|X)"
    val regex = Regex("""\s($l\d{3}$l$l\d{2,3})\W""")
    //val matches = regex.findAll(text)
    //var index: Int
    var number: String
    if (textNew.matches(Regex("$l\\d{3}$l$l\\d{2,3}")) || textNew.trim().matches(Regex("$l\\d{3}$l$l\\d{2,3}"))) {
        println(text)
        return
    }
    while (textNew.contains(regex)) {
        number = regex.find(textNew)!!.groupValues[1]
        textNew = textNew.replaceFirst(number, "")
        println(number)
    }
}
