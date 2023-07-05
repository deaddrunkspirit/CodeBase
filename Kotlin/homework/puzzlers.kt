//fun main() {
//    Order()
//    print(hello() == false)
//    print(AJunior().a)
//}
//
////* -- Puzzler 1 nullability/theOrder
//class Order {
//    private val c: String
//    init {
//        the()
//        c = ""
//    }
//    private fun the() {
//        println(c.length)
//    }
//}
//// Answer - Code compiles, but throws NullPointerException
//// Explanation
////  When the() function is called 'c' value isn't initialized,
////  but code compiles because c value initialized in init block,
//
//
//
////* -- Puzzler 2 types/manyHelloes
//fun hello(): Boolean {
//    println(print("Hello") == print("World") == return false)
//}
//// Answer - HelloWorld
//// Explanation
////  Hello printed, than World printed, than function return false so boolean value isn't printed
//
//
//
////* -- Puzzler 3 properties/initOpenProperty
//interface A {
//    var a: Int
//}
//
//class AJunior : A {
//    override var a: Int
//
//    init {
//        a = 3
//    }
//}
//// Answer - not Compile
//// Explanation
////  There is no contructor