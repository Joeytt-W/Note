
package main

import "fmt"

func main() {
	year:=2023
	fmt.Printf("%v的类型是%T\n",year,year)

	a:="text"
	fmt.Printf("%[1]v的类型是%T\n",a,a)

	b:=42
	fmt.Printf("%[1]v的类型是%T\n",b,b)

	c:=3.14
	fmt.Printf("%[1]v的类型是%T\n",c,c)

	d:=true
	fmt.Printf("%[1]v的类型是%T\n",d,d)
}