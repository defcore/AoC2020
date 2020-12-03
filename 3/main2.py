with open("input.txt") as f:
    content = f.readlines()
    content = [x.strip() for x in content] 

    count1 = 0
    count2 = 0
    count3 = 0
    count4 = 0
    count5 = 0
    stepRight1 = 0
    stepRight2 = 0
    stepRight3 = 0
    stepRight4 = 0
    stepRight5 = 0

    for index in range (1, len(content)):
        stepRight1 = (stepRight1 +  1 ) % len(content[index])
        if content[index][stepRight1] == "#":
            count1 += 1

        stepRight2 = (stepRight2 +  3 ) % len(content[index])
        if content[index][stepRight2] == "#":
            count2 += 1

        stepRight3 = (stepRight3 +  5 ) % len(content[index])
        if content[index][stepRight3] == "#":
            count3 += 1
        
        stepRight4 = (stepRight4 +  7 ) % len(content[index])
        if content[index][stepRight4] == "#":
            count4 += 1

        if (index * 2) < len(content) :
            stepRight5 = (stepRight5 + 1 ) % len(content[index])
            if content[index * 2][stepRight5] == "#":
                count5 += 1


    print(count1 * count2 * count3 * count4 * count5)