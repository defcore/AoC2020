package main

import "fmt"
import "io/ioutil"
import "strings"
import "strconv"

func main() {
	content, err := ioutil.ReadFile("../input.txt")
	if err != nil {
		fmt.Println("Error on read input")
	}
	lines := strings.Split(string(content), "\n")

	validPasswords := 0;

	for _, row := range lines {
		tmp := strings.Split(row, "-");
		min, _ := strconv.Atoi(tmp[0])
		tmp = strings.Split(tmp[1], " ")
		max, _ := strconv.Atoi(tmp[0])
		key := rune(tmp[1][0])
		password :=  tmp[2]

		count := 0;

		if rune(password[min - 1]) == key {
			count++
		}
		if rune(password[max - 1]) == key {
			count++
		}

		if count == 1 {
			validPasswords++
		}
	}
	fmt.Println("valid passwords:", validPasswords)
}