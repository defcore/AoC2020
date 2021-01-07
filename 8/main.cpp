#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <list>

int main()
{

    std::ifstream infile("input.txt");
    std::list<std::string> input;
    std::list<int> positions;

    for (std::string line; getline(infile, line);)
    {
        input.push_back(line);
    }

    int value = 0;
    int currentOperation = 0;
    std::list<std::string>::iterator it = input.begin();

    while (true)
    {
        std ::list<int>::iterator pos;
        pos = find(positions.begin(), positions.end(), currentOperation);
        if (pos != positions.end())
        {
            break;
        }
        else
        {
            positions.push_back(currentOperation);
        }

        if ((*it).rfind("nop", 0) == 0)
        {
            it++;
            currentOperation++;
        }
        else if ((*it).rfind("acc", 0) == 0)
        {
            std::string::size_type sz;
            int number = std::stoi((*it).substr(4, (*it).length()), &sz);
            value += number;
            it++;
            currentOperation++;
        }
        else if ((*it).rfind("jmp", 0) == 0)
        {
            std::string::size_type sz;
            int number = std::stoi((*it).substr(4, (*it).length()), &sz);

            std::advance(it, number);
            currentOperation += number;
        }
    }

    std::cout << value;
    return 0;
}