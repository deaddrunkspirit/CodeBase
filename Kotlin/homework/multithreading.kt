import java.util.concurrent.ConcurrentLinkedQueue
import java.util.concurrent.Executors
import java.util.concurrent.locks.ReentrantLock
import kotlin.concurrent.thread

fun main() {
    task1()
    task2()
    task3()
    task4()
    task5()
    task6()
    task7()
}

class MyThread: Thread() {
    override fun run() { print('.') }
}

class MyThread1: Thread() {
    override fun run() { print(name) }
}

fun task1() {
    for (i in 1..1000) {
        thread { print('.')}
    }
}

fun task2() {
    for (i in 1..1000) {
        MyThread().start()
    }
}

fun task3() {
    MyThread1().start()
}

fun task4() {
    val pool = Executors.newFixedThreadPool(10)
    for (i in 1..1000) {
        pool.execute(Runnable { print('.') })
    }
    pool.shutdown()
}

fun task5() {
    val thread1 = thread { print("one") }
    val thread2 = thread { print("two") }
    thread1.join()
    thread2.join()
}

fun task6() {
    val lock = ReentrantLock()
    var str = ""
    for (i in 1..10) {
        thread {
            for (j in 1..100) {
                lock.withLock {
                    str += "."
                }
            }
        }.join()
    }
    print(str)
}

fun task7() {
    val queue = ConcurrentLinkedQueue<String>()
    thread {
        for (i in 1..1000) {
            queue.add(".")
        }
    }.join()
    thread {
        for (i in 1..1000) {
            print(queue.poll())
        }
    }.join()
}
