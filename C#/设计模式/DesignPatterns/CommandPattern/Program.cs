using CommandPattern;
/*
 意图：将一个请求封装为一个对象，从而使你可用不同的请求对客户（客户程序，也是行为的请求者）进行参数化；对请求排队或记录请求日志，以及支持可撤销的操作。

 使用场景：
（1）系统需要支持命令的撤销（undo）。命令对象可以把状态存储起来，等到客户端需要撤销命令所产生的效果时，可以调用undo方法把命令所产生的效果撤销掉。命令对象还可以提供redo方法，以供客户端在需要时，再重新实现命令效果。

（2）系统需要在不同的时间指定请求、将请求排队。一个命令对象和原先的请求发出者可以有不同的生命周期。意思为：原来请求的发出者可能已经不存在了，而命令对象本身可能仍是活动的。这时命令的接受者可以在本地，也可以在网络的另一个地址。命令对象可以串行地传送到接受者上去。

（3）如果一个系统要将系统中所有的数据消息更新到日志里，以便在系统崩溃时，可以根据日志里读回所有数据的更新命令，重新调用方法来一条一条地执行这些命令，从而恢复系统在崩溃前所做的数据更新。

（4）系统需要使用命令模式作为“CallBack(回调)”在面向对象系统中的替代。Callback即是先将一个方法注册上，然后再以后调用该方法。

 优点：
（1）命令模式使得新的命令很容易被加入到系统里。

（2）可以设计一个命令队列来实现对请求的Undo和Redo操作。

（3）可以较容易地将命令写入日志。

（4）可以把命令对象聚合在一起，合成为合成命令。合成命令式合成模式的应用。

缺点：使用命令模式可能会导致系统有过多的具体命令类。这会使得命令模式在这样的系统里变得不实际。
 */
Console.Title="Command";

CommandManager commandManager = new CommandManager();

IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();

commandManager.Invoke(
    new AddEmployeeToManagerList(employeeManagerRepository,1,new Employee(111,"Kevin")));
employeeManagerRepository.WriteDataStore();

commandManager.Undo();
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(
    new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(222, "Clara")));
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(
    new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));

employeeManagerRepository.WriteDataStore();

commandManager.Invoke(
    new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));

employeeManagerRepository.WriteDataStore();


commandManager.UndoAll();
employeeManagerRepository.WriteDataStore();

Console.ReadKey();