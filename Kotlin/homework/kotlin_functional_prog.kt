//import java.util.*
//// Additional data classes for tasks
//data class Shop(val name: String, val customers: List<Customer>)
//
//data class Customer(val name: String, val city: City, val orders: List<Order>)
//
//data class Order(val products: List<Product>, val isDelivered: Boolean)
//
//data class Product(val name: String, val price: Double)
//
//data class City(val name: String)
//
//// Task 1
//// Lambdas in Kotlin
//fun containsEven(collection: Collection<Int>): Boolean =
//    collection.any { it % 2 == 0 }
//
//// Task 2
//// SAM constructors
//
//fun getList(): List<Int> {
//    val arrayList = arrayListOf(1, 5, 2)
//    Collections.sort(arrayList, { x, y -> y.compareTo(x) })
//    return arrayList
//}
//
////* Task 3
//// filter and map functions
//
//// Return the set of cities the customers are from
//fun Shop.getCitiesCustomersAreFrom(): Set<City> =
//    customers.map { it.city }.toSet()
//
//// Return a list of the customers who live in the given city
//fun Shop.getCustomersFrom(city: City): List<Customer> =
//    customers.filter { it.city == city }.toList()
//
////* Task 4
//// all, any, count, find predicates
//
//// Return true if all customers are from the given city
//fun Shop.checkAllCustomersAreFrom(city: City): Boolean =
//    customers.all { it.city == city }
//
//// Return true if there is at least one customer from the given city
//fun Shop.hasCustomerFrom(city: City): Boolean =
//    customers.any { it.city == city }
//
//// Return the number of customers from the given city
//fun Shop.countCustomersFrom(city: City): Int =
//    customers
//        .filter { it.city == city }
//        .toList()
//        .count()
//
//// Return a customer who lives in the given city, or null if there is none
//fun Shop.findAnyCustomerFrom(city: City): Customer? =
//    customers
//        .filter { it.city == city }
//        .toList()
//        .firstOrNull()
//
////* Task 5
//// flatMap function
//
//// Return all products this customer has ordered
//fun Customer.getOrderedProducts(): Set<Product> =
//    orders
//        .flatMap { it.products }
//        .toSet()
//
//// Return all products that were ordered by at least one customer
//fun Shop.getAllOrderedProducts(): Set<Product> =
//    customers
//        .flatMap { it.getOrderedProducts() }
//        .toSet()
//
////* Task 6
//// max and min, maxBy and minBy functions
//
//// Return a customer whose order count is the highest among all customers
//fun Shop.getCustomerWithMaximumNumberOfOrders(): Customer? =
//    customers.maxBy { it.orders.count() }
//
//// Return the most expensive product which has been ordered
//fun Customer.getMostExpensiveOrderedProduct(): Product? =
//    orders
//        .map { it.products.maxBy { it.price } }
//        .firstOrNull()
//
////* Task 7
//// Sorting (sorted, sortedBy)
//
//// Return a list of customers, sorted by the ascending number of orders they made
//fun Shop.getCustomersSortedByNumberOfOrders(): List<Customer> =
//    customers.sortedBy { it.orders.count() }
//
////* Task 8
//// Sum (sum, sumBy)
//
//// Return the sum of prices of all products that a customer has ordered.
//// Note: the customer may order the same product for several times.
//fun Customer.getTotalOrderPrice(): Double =
//    orders
//        .flatMap { it.products }
//        .map { it.price }
//        .sum()
//
////* Task 9
//// GroupBy
//
//// Return a map of the customers living in each city
//fun Shop.groupCustomersByCity(): Map<City, List<Customer>> =
//    customers.groupBy { it.city }
//
////* Task 10
//// Partition
//
//// Return customers who have more undelivered orders than delivered
//fun Shop.getCustomersWithMoreUndeliveredOrdersThanDelivered(): Set<Customer> =
//    customers.filter {
//        it.orders
//            .filter { it.isDelivered }
//            .count() < it.orders
//            .filter { !it.isDelivered }
//            .count()
//    }.toSet()
//
////* Task 11
//// Mixed task
//
//// Return the most expensive product among all delivered products
//// (use the Order.isDelivered flag)
//fun Customer.getMostExpensiveDeliveredProduct(): Product? {
//    return orders
//        .filter { it.isDelivered }
//        .flatMap { it.products }
//        .maxBy { it.price }
//}
//
//// Return how many times the given product was ordered.
//// Note: a customer may order the same product for several times.
//fun Shop.getNumberOfTimesProductWasOrdered(product: Product): Int {
//    return customers
//        .map { it.orders
//            .sumBy { it.products
//                .filter { it == product }
//                .count() } }
//        .sum()
//}
//
