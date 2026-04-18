using Memento;
/*
 意图：在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态（如果没有这个关键点，其实深拷贝就可以解决问题）。这样以后就可以将该对象恢复到原先保存的状态。

 使用场景：
（1）如果系统需要提供回滚操作时，使用备忘录模式非常合适。例如文本编辑器的Ctrl+Z撤销操作的实现，数据库中事务操作。

（2）保存一个对象在某一个时刻的状态或部分状态，这样以后需要时它能够恢复到先前的状态。

（3）如果用一个接口来让其他对象得到这些状态，将会暴露对象的实现细节并破坏对象的封装性，一个对象不希望外界直接访问其内部状态，通过负责人可以间接访问其内部状态。

（4）有时一些发起人对象的内部信息必须保存在发起人对象以外的地方，但是必须要由发起人对象自己读取，这时，使用备忘录模式可以把复杂的发起人内部信息对其他的对象屏蔽起来，从而可以恰当地保持封装的边界。

 优点：
（1）如果某个操作错误地破坏了数据的完整性，此时可以使用备忘录模式将数据恢复成原来正确的数据。

（2）备份的状态数据保存在发起人角色之外，这样发起人就不需要对各个备份的状态进行管理。而是由备忘录角色进行管理，而备忘录角色又是由管理者角色管理，符合单一职责原则。

（3）提供了一种状态恢复的实现机制，使得用户可以方便地回到一个特定的历史步骤，当新的状态无效或者存在问题时，可以使用先前存储起来的备忘录将状态复原。

（4）实现了信息的封装，一个备忘录对象是一种原发器对象的表示，不会被其他代码改动，这种模式简化了原发器对象，备忘录只保存原发器的状态，采用堆栈来存储备忘录对象可以实现多次撤销操作，可以通过在负责人中定义集合对象来存储多个备忘录。
　　
（5）本模式简化了发起人类。发起人不再需要管理和保存其内部状态的一个个版本，客户端可以自行管理他们所需要的这些状态的版本。
　　
（6）当发起人角色的状态改变的时候，有可能这个状态无效，这时候就可以使用暂时存储起来的备忘录将状态复原。

缺点：
（1）在实际的系统中，可能需要维护多个备份，需要额外的资源，这样对资源的消耗比较严重。资源消耗过大，如果类的成员变量太多，就不可避免占用大量的内存，而且每保存一次对象的状态都需要消耗内存资源，如果知道这一点大家就容易理解为什么一些提供了撤销功能的软件在运行时所需的内存和硬盘空间比较大了。

（2）如果发起人角色的状态需要完整地存储到备忘录对象中，那么在资源消耗上面备忘录对象会很昂贵。

（3）当负责人角色将一个备忘录 存储起来的时候，负责人可能并不知道这个状态会占用多大的存储空间，从而无法提醒用户一个操作是否很昂贵。

（4）当发起人角色的状态改变的时候，有可能这个协议无效。如果状态改变的成功率不高的话，不如采取“假如”协议模式。
 */
Console.Title = "Memento";

CommandManager commandManager = new CommandManager();

IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();

commandManager.Invoke(
    new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(111, "Kevin")));
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