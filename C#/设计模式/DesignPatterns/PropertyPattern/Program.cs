using PropertypePattern;
/*
意图：使用原型实例指定创建对象的种类，然后通过拷贝这些原型来创建新的对象

主要解决：在软件系统中，经常面临着“某些结构复杂的对象”的创建工作；由于需求的变化，这些对象经常面临着剧烈的变化，但是它们却拥有比较稳定一致的接口。

使用场景：
（1）资源优化场景

类初始化需要消化非常多的资源，这个资源包括数据、硬件资源等。

（2）性能和安全要求的场景

通过new产生一个对象需要非常繁琐的数据准备或访问权限，则可以使用原型模式。

（3）一个对象多个修改者的场景

一个对象需要提供给其他对象访问，而且各个调用者可能都需要修改其值时，可以考虑使用原型模式拷贝多个对象供调用者使用。

在实际项目中，原型模式很少单独出现，一般是和工厂方法模式一起出现，通过clone的方法创建一个对象，然后由工厂方法提供给调用者。

优点：
（1）原型模式向客户隐藏了创建新实例的复杂性

（2）原型模式允许动态增加或较少产品类。

（3）原型模式简化了实例的创建结构，工厂方法模式需要有一个与产品类等级结构相同的等级结构，而原型模式不需要这样。

（4）产品类不需要事先确定产品的等级结构，因为原型模式适用于任何的等级结构

缺点：
（1）每个类必须配备一个克隆方法

（2）配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。
 */
Console.Title = "Propertype";

var manager = new Manager("Cindy");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Kevin", managerClone);
var employeeClone = (Employee)employee.Clone(true);
Console.WriteLine($"Employee was cloned: {employeeClone.Name},with manager {employeeClone.Manager.Name}");

managerClone.Name = "Karen";
Console.WriteLine($"Employee was cloned: {employeeClone.Name},with manager {employeeClone.Manager.Name}");
Console.WriteLine(manager.Name);

Console.ReadKey();