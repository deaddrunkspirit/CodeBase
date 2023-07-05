fun <T> Collection<T>.powerset(): Set<Set<T>> =
    if (isEmpty()) setOf(emptySet())
    else drop(1)
        .powerset()
        .let { it + it.map { it + first() } }

fun main(args: Array<String>) {
    var myset = readLine()!!.split(' ').map { it.toInt() }.toSet().powerset()
    println(myset.size)
    println(myset.joinToString("\n"){it.joinToString(" ")})
}
