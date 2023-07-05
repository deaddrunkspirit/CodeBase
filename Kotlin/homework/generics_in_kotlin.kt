class Ether : Blockchain(), MoneyGenerator
open class Bitcoin : Blockchain(), MoneyGenerator
interface MoneyGenerator
interface PlanetRider
interface HypeGenerator
abstract class SphericalHorse
abstract class Blockchain : SphericalHorse(), HypeGenerator
abstract class HypeEmperor
open class ElonMusk() : HypeEmperor() {
    val tesla: Tesla = Tesla()
    val rocket: BigRocket = BigRocket()
}
class Tesla : NewRover(), HypeGenerator
class BigRocket : HypeGenerator
open class NewRover : PlanetRider
open class Rover : PlanetRider
