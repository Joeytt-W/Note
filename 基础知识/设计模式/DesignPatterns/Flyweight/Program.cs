using Flyweight;
/*
 意图：运用共享技术有效地支持大量细粒度的对象

 使用场景：
 （1）一个系统中有大量的对象；

 （2）这些对象耗费大量的内存；

 （3）这些对象中的状态大部分都可以被外部化

 （4）这些对象可以按照内部状态分成很多的组

 优点：
 （1）享元模式的优点在于它能够极大的减少系统中对象的个数。

 （2）享元模式由于使用了外部状态，外部状态相对独立，不会影响到内部状态，所以享元模式使得享元对象能够在不同的环境被共享。

 缺点：
 （1）由于享元模式需要区分外部状态和内部状态，使得应用程序在某种程度上来说更加复杂化了。

 （2）为了使对象可以共享，享元模式需要将享元对象的状态外部化，而读取外部状态使得运行时间变长。
 
 */
Console.Title = "Flyweight";


var aBunchOfCharacters = "abba";

var characterFactory = new CharacterFactory();

var characterObject = characterFactory.GetCharacter(aBunchOfCharacters[0]);

characterObject?.Draw("Arial", 12);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[1]);

characterObject?.Draw("Trebuchet MS", 14);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[2]);

characterObject?.Draw("Times New Roman", 16);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[3]);

characterObject?.Draw("Comic Sans", 18);


var paragraph = characterFactory.CreateParagraph(new List<ICharacter>() { characterObject }, 1);

paragraph.Draw("Lucinda", 12);


Console.ReadKey();