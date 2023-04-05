package main

import (
	"fmt"
)

type planet string

func main() {
	var planets = [...]planet{
		"Mercury",
		"Venus",
		"Earth",
		"Mars",
		"Jupiter",
		"Sturn",
		"Uranus",
		"Neptune",
	}
	// for i, dwarf := range planets {
	// 	fmt.Println(i, dwarf)
	// }
	fmt.Printf("planets length:%d\n", len(planets)) // "planets length: 12"
	planetsMarkII := planets
	planets[2] = "whoops"
	fmt.Println(planets)
	fmt.Println(planetsMarkII)

	var test [4]string
	test[0] = "foo"
	test[1] = "bar"
	fmt.Println(test[2] == "")
}
