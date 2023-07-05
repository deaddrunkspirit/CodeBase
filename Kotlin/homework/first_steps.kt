// Task 1 return Hello world
fun start(): String {
    return "Hello Word!"
}

// Task 2 bubble sorting
fun bubbleSort(inputList: List<String>): IntArray {
    val arr = IntArray(inputList.size)
    for (i in inputList.indices) {
        arr[i] = inputList[i].toInt()
    }
    var swap = true
    while (swap) {
        swap = false
        for (i in 0 until arr.size - 1) {
            if (arr[i] > arr[i + 1]) {
                val temp = arr[i]
                arr[i] = arr[i + 1]
                arr[i + 1] = temp
                swap = true
            }
        }
    }
    return arr
}

fun main() {
    // Task 1
    println(start())
    // Task 2
    val array = bubbleSort(listOf("5", "4", "10", "22", "2"));
    for (item in array) print("$item ")
    println()
    // Task 6
    val str = readLine()
    println(encode(str))
    // Task 9
    //val binary = readLine()
    //if (binary != null) {
    //    println(binaryToHex(binary))
    //}
    pascalTriangle(5)
}

// Task 6
fun encode(str: String?): String {
    var current = str?.get(0)
    var count = 0
    var res = ""
    if (str != null) {
        for (item in str) {
            if (item == current) {
                count++
            } else {
                res += "$current$count"
                count = 1
                current = item
            }
        }
        res += "$current$count"
    }
    return res
}

// Task 7 Convert Java Code to Kotlin
class JavaCode {
    fun toJSON(collection: Collection<Int?>): String {
        val sb = StringBuilder()
        sb.append("[")
        val iterator = collection.iterator()
        while (iterator.hasNext()) {
            val element = iterator.next()
            sb.append(element)
            if (iterator.hasNext()) {
                sb.append(", ")
            }
        }
        sb.append("]")
        return sb.toString()
    }
}

// Task 9
//fun binaryToHex(bin: String): String {
//    var hex: String = ""
//    var binary = bin
//    var hexCount = binary.length / 4
//    if (binary.length % 4 != 0) {
//        hexCount++
//        for (i in binary.length % 4)){
//            binary = "0$binary"
//        }
//    }
//    var i = 0
//    var length = 0
//    while (length < hexCount){
//        when (binary.substring(i, i + 3)) {
//            "0000" -> hex += "0";
//            "0001" -> hex += "1";
//            "0010" -> hex += "2";
//            "0011" -> hex += "3";
//            "0100" -> hex += "4";
//            "0101" -> hex += "5";
//            "0110" -> hex += "6";
//            "0111" -> hex += "7";
//            "1000" -> hex += "8";
//            "1001" -> hex += "9";
//            "1010" -> hex += "A";
//            "1011" -> hex += "B";
//            "1100" -> hex += "C";
//            "1101" -> hex += "D";
//            "1110" -> hex += "E";
//            "1111" -> hex += "F";
//        }
//        binary.removeRange(i, i + 3)
//        length++
//        i += 4
//    }
//    return hex
//}


fun pascalTriangle(ubound: Int){
    var triangle = Array(ubound + 1) { LongArray(ubound + 1) }
    for (n in 0..ubound) {
        triangle[n][n] = 1
        triangle[n][0] = triangle[n][n]
        for (k in 1 until n) {
            triangle[n][k] = triangle[n - 1][k - 1] + triangle[n - 1][k]
        }
    }
    var res = ""
    for (n in 0 until ubound) {
        for (k in 0..n) {
            res += "." + triangle[n][k].toString()
        }
        res.removeRange(0, 1)
        res += "\n"
    }
    println(res)
}