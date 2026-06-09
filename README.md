# Object-Oriented Programming Fundamentals Demonstrated in Code

## Abstraction
Expose simple public actions while hiding the internal steps.
* The CoffeeMachine class exposes MakeEspresso and MakeLatte.
* Program calls those public methods without knowing how the coffee is made.
* Private methods such as GrindBeans, HeatWater, BrewCoffee, and SteamMilk contain the implementation details.
* The caller depends on what the object does, not how it does it.

## Encapsulation

Private setters, validation, controlled state changes.
* A dedicated Temperature class instead of static helper methods.
* A stateful property (Celsius) with a private set.
* Conversion methods that modify the internal state and details unknown to external classes.
* Validation inside the class.
* A simple console UI that consumes the class.
* Explicit comments explaining why things are done.

## Inheritance
Reuse shared data and behavior from a base class.
* Employee defines the common data: Name and Department.
* Employee also defines the shared behavior: PrintInfo.
* Developer inherits from Employee and adds ProgrammingLanguage and WriteCode.
* Manager inherits from Employee and adds TeamSize and RunMeeting.
* Derived classes call base(...) to initialize the inherited state.

## Polimorphism
Use the same operation name with different forms.
* Program calls Print with an int, a string, and a decimal.
* Each Print method has the same name but a different parameter type.
* C# chooses the correct method based on the argument passed.
* This is method overloading, also called compile-time polymorphism.
