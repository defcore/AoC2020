with open("input.txt") as f:
    content = f.readlines()
    content = [x.strip() for x in content] 

    count = 0
    stepRight = 0

    for index in range (1, len(content)):
        stepRight = (stepRight +  3 ) % len(content[index])
        if content[index][stepRight] == "#":
            count += 1
        
    print(count)