import java.util.*
import kotlin.collections.sortedByDescending as sortedByDescending

//  * Task 1
interface Quackable {
    fun quack(): String
}

interface Swimable {
    fun swim() = "Буль-буль"
}

interface Gnawable {
    fun gnaw(): String
}

class Duck : Quackable, Swimable {
    override fun quack() = "Кря-кря"
}

class Goose : Gnawable, Swimable {

    override fun gnaw() = "Щип-щип"
}

//  * Task 2
data class Book (
    val title: String,
    val authors: List<String>,
    val editors: List<String>,
    val translator: String,
    val publishingHouse: String,
    val year: Int,
    val publishPlace: String,
    val countOfPages: Int,
    val genre: Genre,
    val cover: Cover,
    val isbn: String
) {
    init {
        require(Regex("\t[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*").matches(isbn))
        require(year < 2020)
        require(authors.isNotEmpty())
        require(editors.isNotEmpty())
        require(countOfPages != 0)
    }
}

enum class Genre {
    FICTION,
    SCIENCE_FICTION,
    FANTASY,
    JOURNALISM,
    SCIENTIFIC_LITERATURE,
}

enum class Cover {
    SOFTCOVER,
    HARDCOVER,
    POCKETBOOK,
    ALBUM,
}

//  * Task 3
data class Bookcase (
    val shelves: Bookshelf,
    val color: String
)

data class Bookshelf (
    val capacity: Int,
    val type: Genre,
    val newBooks: List<Book> = listOf()
) {
    private val books: MutableList<Book> = mutableListOf()
    init {
        require(capacity > 1)
        newBooks.forEach { require(it.genre == type) }
    }

    fun addBook(book: Book) {
        books.add(book)
    }
}

//  * Task 4
class HydraGoose(var innerMatrix: Array<IntArray>) {

    val declareOneself: String
        get() = """
            |░░░░░░░░░░░░░░░░░░░░
            |░░░░▄▀▀▀▄░░░░░░░░░░░
            |▄███▀░◐░▄▀▀▀▄░░░░░░
            |░░▄███▀░◐░░░░▌░░░░░
            |░░░▐░▄▀▀▀▄░░░▌░░░░░░
            |▄███▀░◐░░░▌░░▌░░░░
            |░░░░▌░░░░░▐▄▄▌░░░░░
            |░░░░▌░░░░▄▀▒▒▀▀▀▀▄
            |░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
            |░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
            |░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
            |░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
            |░░░░░░░░░░░▌▌░▌▌░░░░░
            |░░░░░░░░░░░▌▌░▌▌░░░░░
            |░░░░░░░░░▄▄▌▌▄▌▌░░░░░
        """.trimMargin("|")
    fun squeak() = "пипипи"
    fun whistle() = "*свистит как гусь"
    fun quack() = "крякрякря"
    fun transpose() {
        val newMatrix: Array<IntArray> = Array(innerMatrix[0].size) { IntArray(innerMatrix.size) }
        for (i in innerMatrix.indices) {
            for (j in innerMatrix[0].indices) {
                newMatrix[j][i] = innerMatrix[i][j]
            }
        }
        innerMatrix = newMatrix
    }
}

//  * Task 5
class DateRange(val start: MyDate, val end: MyDate): Iterable<MyDate> {
    override fun iterator(): Iterator<MyDate> {
        return DateRangeIterator(start, end)
    }

    class DateRangeIterator(start: MyDate, end: MyDate): Iterator<MyDate> {
        var curr = start
        var last = end

        override fun hasNext(): Boolean = curr.nextDay() <= last.nextDay()

        override fun next(): MyDate {
            val save = curr
            curr = save.nextDay()
            return save
        }
    }

    operator fun contains(other: MyDate) = start <= other && other <= end
}

fun iterateOverDateRange(firstDate: MyDate, secondDate: MyDate, handler: (MyDate) -> Unit) {
    for (date in firstDate..secondDate) {
        handler(date)
    }
}

data class MyDate(val year: Int, val month: Int, val dayOfMonth: Int) : Comparable<MyDate> {
    override fun compareTo(other: MyDate): Int {
        if (year != other.year) return year - other.year
        if (month != other.month) return month - other.month
        return dayOfMonth - other.dayOfMonth
    }
}

operator fun MyDate.rangeTo(other: MyDate) = DateRange(this, other)

fun MyDate.nextDay() = addTimeIntervals(TimeInterval.DAY, 1)

enum class TimeInterval {
    DAY,
    WEEK,
    YEAR
}

fun MyDate.addTimeIntervals(timeInterval: TimeInterval, number: Int): MyDate {
    val c = Calendar.getInstance()
    c.set(year + if (timeInterval == TimeInterval.YEAR) number else 0, month, dayOfMonth)
    var timeInMillis = c.getTimeInMillis()
    val millisecondsInADay = 24 * 60 * 60 * 1000L
    timeInMillis += number * when (timeInterval) {
        TimeInterval.DAY -> millisecondsInADay
        TimeInterval.WEEK -> 7 * millisecondsInADay
        TimeInterval.YEAR -> 0L
    }
    val result = Calendar.getInstance()
    result.setTimeInMillis(timeInMillis)
    return MyDate(result.get(Calendar.YEAR), result.get(Calendar.MONTH), result.get(Calendar.DATE))
}

fun getList(): List<Int> {
    return listOf(1, 5, 2).sortedDescending()

}
class Invokable {
    var numberOfInvocations: Int = 0
        private set
    operator fun invoke(): Invokable {
        numberOfInvocations++
        return this
    }
}

fun invokeTwice(invokable: Invokable) = invokable()()
fun main() {

}