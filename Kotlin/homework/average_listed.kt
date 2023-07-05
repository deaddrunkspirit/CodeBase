fun main(args : Array<String>) {
    val numbers: List<Int> = readLine()?.split(" ")!!.map { it.toInt() }
    val n: Short = readLine()!!.toShort()
    println("${numbers.average()} ${numbers.average()}")
}