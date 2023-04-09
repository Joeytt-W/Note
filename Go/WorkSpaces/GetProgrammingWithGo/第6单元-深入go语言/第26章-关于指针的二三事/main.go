package main

import "fmt"

func main() {
	answer := 42
	address := &answer

	fmt.Printf("answer is %v\n", answer)
	fmt.Printf("address is %v\n", address)

	fmt.Printf("answer is a %T\n", answer)
	fmt.Printf("address is a %T\n", address)
}
