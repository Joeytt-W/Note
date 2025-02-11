package main

import (
	"fmt"
	"unicode/utf8"
)

func raw() {
	fmt.Println("原始字符串字面量：")
	fmt.Println("peace be upon you\n upon you be peace")
	fmt.Println(`strings can span multiple lines with the \n escape sequence`)
}
func rawLines() {
	fmt.Println(`
	peace be upon you
	upon you be peace
	`)
}
func rawType() {
	fmt.Printf("%v is a %[1]T\n", "literal string")
	fmt.Printf("%v is a %[1]T\n", "raw string literal")
}
func testRune() {
	var pi rune = 960
	var alpha rune = 940
	var omega rune = 969
	var bang rune = 33
	//打印值 960 940 969 33
	fmt.Printf("%v %v %v %v\n", pi, alpha, omega, bang)
	//打印字符 πάω!
	fmt.Printf("%c%c%c%c\n", pi, alpha, omega, bang)

	var grade rune = 'A'
	fmt.Printf("%v %[1]T %[1]c\n", grade) //65 int32 A
}
func index() {
	message := "shalom"
	for i := 0; i < 6; i++ {
		c := message[i]
		fmt.Printf("%c\n", c)
	}
}
func caesar() {
	message := "L fdph, L vdz, L frqtxhuhg."
	for i := 0; i < len(message)-1; i++ {
		c := message[i]
		if c >= 'a' && c <= 'z' {
			c = c - 3
			if c < 'a' {
				c = c + 26
			}
		}
		if c >= 'A' && c <= 'Z' {
			c = c - 3
			if c < 'A' {
				c = c + 26
			}
		}
		fmt.Printf("%c", c)
	}
	fmt.Printf(".\n")
}
func rot13() {
	message := "uv vagreangvbany fcnpr fgngvba"
	for i := 0; i < len(message); i++ {
		c := message[i]
		if c >= 'a' && c <= 'z' {
			c = c + 13
			if c > 'z' {
				c = c - 26
			}
		}
		fmt.Printf("%c", c)
	}
	fmt.Printf("\n")
}
func spanish() {
	question := "¿Te quieres? Correcto"
	fmt.Println(len(question), "bytes") //len返回的是字节长度
	fmt.Println(utf8.RuneCountInString(question), "runes")

	c, size := utf8.DecodeRuneInString(question)
	fmt.Printf("First rune: %c %v bytes", c, size)
}
func spanishRange() {
	question := "¿Te quieres? Correcto"

	//range遍历，返回索引和值
	//_丢弃标识符，不需要的返回值
	for _, c := range question {
		fmt.Printf(" %c", c)
	}

}

func main() {
	spanishRange()
}
