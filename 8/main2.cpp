#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <list>

int main()
{

    std::ifstream infile("example.txt");
    std::list<std::string> input;
    std::list<int> positions;
    std::list<int> changedValues;

    for (std::string line; getline(infile, line);)
    {
        input.push_back(line);
    }

    int value = 0;
    int currentOperation = 0;
    std::list<std::string>::iterator it = input.begin();

    while (currentOperation != input.size())
    {
        // check if endless loop
        std ::list<int>::iterator pos;
        pos = find(positions.begin(), positions.end(), currentOperation);
        if (pos != positions.end())
        {

            // std::cout << "endless" << std::endl;
            // undo modification
            input.clear();
            for (std::string line; getline(infile, line);)
            {
                input.push_back(line);
            }

            for (int position : positions)
            {

                std ::list<int>::iterator p = find(changedValues.begin(), changedValues.end(), position);
                if (p == changedValues.end())
                {
                    // std::cout << position << std::endl;
                    std::list<std::string>::iterator it = input.begin();
                    std::advance(it, position);

                    std::cout << *it << std::endl;

                    if ((*it).rfind("nop", 0) == 0)
                    {
                        std::cout << "not changed before" << std::endl;
                        std::cout << (*it) << std::endl;
                        (*it).replace((*it).find("nop"), sizeof("nop") - 1, "jmp");
                        std::cout << (*it) << std::endl;
                        it = input.begin();
                        positions.clear();
                        currentOperation = 0;
                        changedValues.push_back(position);

                        // for (std::list<std::string>::iterator i = input.begin(); i != input.end(); ++i)
                        //     std::cout << *i << std::endl;

                        break;
                    }
                    else if ((*it).rfind("jmp", 0) == 0)
                    {
                        std::cout << "not changed before" << std::endl;
                        std::cout << (*it) << std::endl;
                        (*it).replace((*it).find("jmp"), sizeof("jmp") - 1, "nop");
                        std::cout << (*it) << std::endl;
                        it = input.begin();
                        positions.clear();
                        currentOperation = 0;
                        changedValues.push_back(position);

                        // for (std::list<std::string>::iterator i = input.begin(); i != input.end(); ++i)
                        //     std::cout << *i << std::endl;

                        break;
                    }
                }
            }
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